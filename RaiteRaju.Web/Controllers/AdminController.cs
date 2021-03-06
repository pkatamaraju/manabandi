﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaiteRaju.ServiceMapper;
using RaiteRaju.Web.Models;
using System.IO;
using System.Text.RegularExpressions;
using RaiteRaju.ApplicationUtility;
using System.Drawing;
using System.Drawing.Drawing2D;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using QRCoder;

namespace RaiteRaju.Web.Controllers
{
    public class AdminController : ErrorController
    {
        // GET: Admin

        [HandleError]
        public ActionResult AdminMain()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                List<GDictionaryModel> modelList = new List<GDictionaryModel>();
                InformationServiceWrapper inforObj = new InformationServiceWrapper();
                modelList=inforObj.GetSummaryForAdmin();
                ViewBag.summaryList = modelList;
                return View("AdminMain");
            }
            else
            {
                return View("AdminLogin");
            }
        }

        public ActionResult Login()
        {

            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                return RedirectToAction("AdminMain", "Admin");
            }
            else
            {
                return View("AdminLogin");
            }

        }

        [HttpPost]
        public ActionResult Login(FormCollection fnLogin)
        {

            Int64 PhoneNumber = Convert.ToInt64(fnLogin["txtPhoneNumber"]);
            Utility en = new Utility();
            string PassWord = en.Encrypt(fnLogin["txtPassword"]);
            // string PassWord = fnLogin["txtPassword"];

            InformationServiceWrapper Obj = new InformationServiceWrapper();
            UserDetailsModel ModelObj = new UserDetailsModel();
            ModelObj = Obj.AdminLoginCheck(PhoneNumber, PassWord);

            //Create a Cookie with a suitable Key.


            if (ModelObj.txtUserName != null)
            {
                HttpCookie UserNameCookie = new HttpCookie("_RRAUN");

                HttpCookie RoleCookie = new HttpCookie("_RRROLE");
                RoleCookie.Values["_RRROLE"] = ModelObj.Role.ToString().ToUpper();
                RoleCookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(RoleCookie);


                HttpCookie PhoneNumberCookie = new HttpCookie("_RRAPn");
                HttpCookie KeyCookie = new HttpCookie("_RRAPS");

                //Set the Expiry date.
                UserNameCookie.Expires = DateTime.Now.AddDays(365);

                if (ModelObj.txtUserName.Length <= 10)
                {
                    //Set the Cookie value.
                    UserNameCookie.Values["_RRAUN"] = ModelObj.txtUserName;
                    ViewBag.UserName = ModelObj.txtUserName;

                    //Add the Cookie to Browser.
                    Response.Cookies.Add(UserNameCookie);

                }
                else
                {
                    //Session["LOGGEDONUSER"] = ModelObj.txtUserName.Substring(0, 10) + "..";
                    UserNameCookie.Values["_RRAUN"] = ModelObj.txtUserName.Substring(0, 10) + "..";
                    //Add the Cookie to Browser.
                    Response.Cookies.Add(UserNameCookie);
                }

                if (!string.IsNullOrEmpty((string)UserNameCookie.Value))
                {
                    PhoneNumberCookie["_RRAPn"] = fnLogin["txtPhoneNumber"];
                    KeyCookie["_RRAPS"] = PassWord;
                }
                else
                {
                    ViewBag.ErrorMessage = "Please enter correct credentials";
                }
                return Json(Convert.ToString(UserNameCookie.Value), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ContactUs()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                InformationServiceWrapper inforObj = new InformationServiceWrapper();
                List<ContactUsModel> ModelList = new List<ContactUsModel>();
                ModelList = inforObj.FetchContactForAdmin();
                ViewBag.ContactusList = ModelList;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ReviewsForAdmin()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                InformationServiceWrapper inforObj = new InformationServiceWrapper();
                List<ReviewModel> ModelList = new List<ReviewModel>();
                ModelList = inforObj.FetchReviewsForAdmin();
                ViewBag.ReviewsList = ModelList;
                return View("Reviews");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }

        public ActionResult Exceptions()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                InformationServiceWrapper inforObj = new InformationServiceWrapper();
                List<ExceptionModel> ModelList = new List<ExceptionModel>();
                ModelList = inforObj.FetchExceptionsForAdmin();
                ViewBag.ExceptionList = ModelList;
                return View("Exceptions");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult Registration(FormCollection fnRegistration)
        {

            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int count = 0;
                int UserId; //=(Int32)Session["_RRUID"];
                UserDetailsModel objModel = new UserDetailsModel();

                objModel.txtUserName = fnRegistration["txtUserName"];
                objModel.txtPhoneNumber = Convert.ToInt64(fnRegistration["txtPhoneNumber"]);

                Utility en = new Utility();
                objModel.txtPassword = en.Encrypt(fnRegistration["txtPassword"]);
                objModel.ddlState = fnRegistration["ddlStateText"];
                objModel.ddlDistrict = fnRegistration["ddlDistrict"];
                objModel.ddlMandal = fnRegistration["ddlMandal"];
                objModel.txtVillage = fnRegistration["txtVillage"];
                // objModel.txtMailId = fnRegistration["txtMailId"];
                objModel.OTP = fnRegistration[""];
                objModel.KeyForUserSettings = "ADMIN";
                string s = "[^<>'\"/`%-]";
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtUserName, s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlState, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlDistrict, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlMandal, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(en.Decrypt(objModel.txtPassword), s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.Match(objModel.txtPhoneNumber.ToString(), "[5-9]{1}[0-9]{9}").Success)
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtVillage, s))
                {
                    count = count + 1;
                }


                GDictionaryModel GDOBJ = new GDictionaryModel();
                if (count == 7)
                {
                    ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                    InformationServiceWrapper infoObj = new InformationServiceWrapper();
                    GDOBJ = infoObj.MobileNuberExistsOrNot(objModel.txtPhoneNumber, UserType.user.ToString());
                    if (GDOBJ.ID == 1)
                    {
                        UserId = ObjService.InsertAddUserDetails(objModel);
                        if (UserId != 0)
                        {
                            HttpCookie KeyCookie = new HttpCookie("_RRPS");
                            KeyCookie.Values["_RRPS"] = en.Encrypt(objModel.txtPassword);
                            KeyCookie.Expires = DateTime.Now.AddDays(365);
                            Response.Cookies.Add(KeyCookie);
                        }
                        return Json(UserId, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ViewBag.MobileError = "Entered Mobiler Number is already registered";
                        return Json(GDOBJ.ID, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    GDOBJ.ID = -1;
                    return Json(GDOBJ.ID, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        //[HttpPost]
        //public ActionResult FileUpload(HttpPostedFileBase image, Int32 AdId)
        //{
        //    HttpCookie nameCookie = Request.Cookies["_RRAUN"];

        //    if (nameCookie != null)
        //    {
        //        HttpPostedFileBase file = Request.Files["ImageData"];

        //        if (file != null)
        //        {

        //            var LENGTH = (file.ContentLength / 1024);
        //            var ext = Path.GetExtension(file.FileName);
        //            Stream strm = file.InputStream;

        //            var ActualImagePath = Path.Combine(Server.MapPath("~/PhotoManagement/Actual/"), Convert.ToString(AdId) + ".jpg");
        //            var CompressedImagePath = Path.Combine(Server.MapPath("~/PhotoManagement/Compressed/"), Convert.ToString(AdId) + ".jpg");

        //            var CompressedDelPath = Path.Combine(Server.MapPath("~/PhotoManagement/Deleted/"), Convert.ToString(AdId) + "_Compressed_Deleted.jpg");
        //            var ActualDelPath = Path.Combine(Server.MapPath("~/PhotoManagement/Deleted/"), Convert.ToString(AdId) + "_Actual_Deleted.jpg");

        //            if (System.IO.File.Exists(CompressedImagePath))
        //            {
        //                System.IO.File.Delete(CompressedDelPath);
        //                System.IO.File.Move(CompressedImagePath, CompressedDelPath);

        //                if (System.IO.File.Exists(ActualImagePath))
        //                {
        //                    System.IO.File.Delete(ActualDelPath);
        //                    System.IO.File.Move(ActualImagePath, ActualDelPath);
        //                }

        //                ReduceImageSize(strm, CompressedImagePath);
        //                ReduceImageSizeForActualImage(strm, ActualImagePath, LENGTH);
        //            }
        //            else
        //            {
        //                ReduceImageSize(strm, CompressedImagePath);
        //                ReduceImageSizeForActualImage(strm, ActualImagePath, LENGTH);
        //            }

        //            return Json(AdId, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(AdId, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(AdId, JsonRequestBehavior.AllowGet);
        //    }
        //}

        ////public byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    byte[] imageBytes = null;
        //    BinaryReader reader = new BinaryReader(image.InputStream);
        //    imageBytes = reader.ReadBytes((int)image.ContentLength);
        //    return imageBytes;
        //}

        //private void ReduceImageSize(Stream sourcePath, string targetPath)
        //{
        //    using (var image = System.Drawing.Image.FromStream(sourcePath))
        //    {
        //        if (image.PropertyIdList.Contains(0x0112))
        //        {
        //            int rotationValue = image.GetPropertyItem(0x0112).Value[0];
        //            switch (rotationValue)
        //            {
        //                case 1: // landscape, do nothing
        //                    break;

        //                case 8: // rotated 90 right
        //                    // de-rotate:
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
        //                    break;

        //                case 3: // bottoms up
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
        //                    break;

        //                case 6: // rotated 90 left
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
        //                    break;
        //            }
        //        }

        //        // image.RotateFlip(RotateFlipType.Rotate90FlipNone); 
        //        //var scaleFactor = 0.5;
        //        var newWidth = 155;// (int)(image.Width * scaleFactor);
        //        var newHeight = 110;// (int)(image.Height * scaleFactor);
        //        var thumbnailImg = new Bitmap(newWidth, newHeight);
        //        var thumbGraph = Graphics.FromImage(thumbnailImg);
        //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        //        thumbGraph.DrawImage(image, imageRectangle);
        //        thumbnailImg.Save(targetPath, image.RawFormat);
        //    }
        //}

        //private void ReduceImageSizeForActualImage(Stream sourcePath, string targetPath, int length)
        //{
        //    using (var image = System.Drawing.Image.FromStream(sourcePath))
        //    {
        //        if (image.PropertyIdList.Contains(0x0112))
        //        {
        //            int rotationValue = image.GetPropertyItem(0x0112).Value[0];
        //            switch (rotationValue)
        //            {
        //                case 1: // landscape, do nothing
        //                    break;

        //                case 8: // rotated 90 right
        //                    // de-rotate:
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
        //                    break;

        //                case 3: // bottoms up
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
        //                    break;

        //                case 6: // rotated 90 left
        //                    image.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
        //                    break;
        //            }
        //        }


        //        var scaleFactor = 1.0;
        //        if (length >= 350)
        //        {
        //            scaleFactor = 0.5;
        //        }
        //        var newHeight = (int)(image.Width * scaleFactor);
        //        var newWidth = (int)(image.Height * scaleFactor);

        //        var thumbnailImg = new Bitmap(newWidth, newHeight);
        //        var thumbGraph = Graphics.FromImage(thumbnailImg);
        //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        //        thumbGraph.DrawImage(image, imageRectangle);
        //        thumbnailImg.Save(targetPath, image.RawFormat);
        //    }
        //}

        [HttpPost]
        public ActionResult FetchDistricts(int StateId)
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.FetDistrictsOfState(StateId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FetchMandals(int DistrictId)
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.FetMandalsOfDistrct(DistrictId), JsonRequestBehavior.AllowGet);

        }

        #region OwnerDetails

        public ActionResult AddOwner()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddOwner(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {

                Owner model = new Owner();
                Utility en = new Utility();

                Int32 ownerID = 0;

                model.txtOwnerName = form["txtUserName"];
                model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                model.txtPassword = en.Encrypt(form["txtPhoneNumber"]);
                model.intStateId = Convert.ToInt32(form["ddlStateID"]);
                model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
                model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
                model.txtPlace = form["txtVillage"];
                model.OTP = 0;

                string errorMessage = "";

                string s = "[^<>'\"/`%-]";
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtOwnerName, s))
                {
                    errorMessage = errorMessage + "Special character are not allowed in Name.\n";
                }

                if (!System.Text.RegularExpressions.Regex.Match(model.BigIntPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                {
                    errorMessage = errorMessage + "Enter valid Phone Number.\n";
                }

                if (!Regex.Match(model.intStateId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid State.\n";
                }

                if (!Regex.Match(model.intDistrictId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid District.\n";
                }

                if (!Regex.Match(model.intManadalID.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid Mandal.\n";
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtPlace, s))
                {
                    errorMessage = errorMessage + "special characters are not allowed in Place.\n";
                }


                GDictionaryModel GDOBJ = new GDictionaryModel();
                if (errorMessage == "")
                {
                    ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                    InformationServiceWrapper infoObj = new InformationServiceWrapper();
                    GDOBJ = infoObj.MobileNuberExistsOrNot(model.BigIntPhoneNumber, UserType.owner.ToString());
                    if (GDOBJ.ID == 1)
                    {
                        ManagementServiceWrapper serviceObj = new ManagementServiceWrapper();

                        ownerID = serviceObj.VehicleOwnerRegistration(model);

                        return Json("success", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        errorMessage = "Entered mobiler number is already registered with us.\n";
                        return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult OwnerDetails(Int32 intStateID, Int32 intDistrictID, Int32 intManadalID, Int32 VehicleTypeID, Int32 PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                VehicleFilterModel Model = new VehicleFilterModel();
                Model.intStateId = intStateID;
                Model.intDistrictId = intDistrictID;
                Model.intManadalID = intManadalID;
                Model.VehicleTypeID = VehicleTypeID;
                Model.IntPageNumber = PageNumber;
                Model.IntPageSize = 50;

                List<VehicleFilterModel> ownerList = new List<VehicleFilterModel>();
                ownerList = objservice.GetOwnerDetailsForAdminPage(Model, out TotalPageNumber);
                ViewBag.ownerList = ownerList;
                ViewBag.TotalPageNumber = TotalPageNumber;

                ViewBag.selectedStateID = intStateID;
                ViewBag.selectedDistrictID = intDistrictID;
                ViewBag.selectedMandalID = intManadalID;
                ViewBag.selectedVehicleTypeID = VehicleTypeID;
                ViewBag.pageNumber = PageNumber;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult EditOwnerDetails(Int32 ownerID)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                Owner Model = objservice.GetOwnerDetailsByIDForAdmin(ownerID);
                ViewBag.existingMobileNumber = Model.BigIntPhoneNumber;
                ViewBag.ownerID = Model.intOwnerID;
                ViewBag.owner = Model;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult EditOwnerDetails(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                Owner model = new Owner();

                model.txtOwnerName = form["txtUserName"];
                model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                model.intStateId = Convert.ToInt32(form["ddlStateID"]);
                model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
                model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
                model.intOwnerID = Convert.ToInt32(form["ownerID"]);
                model.txtPlace = form["txtVillage"];
                string mobileNumberChangedOrNOT = form["changedOrNot"];
                string errorMessage = "";

                string s = "[^<>'\"/`%-]";
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtOwnerName, s))
                {
                    errorMessage = errorMessage + "Special character are not allowed in Name.\n";
                }

                if (!System.Text.RegularExpressions.Regex.Match(model.BigIntPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                {
                    errorMessage = errorMessage + "Enter valid Phone Number.\n";
                }

                if (!Regex.Match(model.intStateId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid State.\n";
                }

                if (!Regex.Match(model.intDistrictId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid District.\n";
                }

                if (!Regex.Match(model.intManadalID.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid Mandal.\n";
                }


                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtPlace, s))
                {
                    errorMessage = errorMessage + "special characters are not allowed in Place.\n";
                }

                ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                InformationServiceWrapper infoObj = new InformationServiceWrapper();
                GDictionaryModel GDOBJ = new GDictionaryModel();

                if (mobileNumberChangedOrNOT == "changed")
                {
                    GDOBJ = infoObj.MobileNuberExistsOrNot(model.BigIntPhoneNumber, UserType.owner.ToString());
                }
                if (mobileNumberChangedOrNOT == "changed" & GDOBJ.ID != 1)
                {
                    errorMessage = errorMessage + "Entered mobiler number is already registered with us.\n";
                }

                if (errorMessage == "")
                {

                    ManagementServiceWrapper serviceObj = new ManagementServiceWrapper();

                    serviceObj.UpdateVehicleOwnerDetailsByAdmin(model);

                    return Json("success", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        #endregion

        public ActionResult DeleteAccount(Int64 BigIntPhoneNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int succuss = 0;

                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                succuss = obj.DeleteUserAccount(BigIntPhoneNumber);
                return Json(succuss, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }


        #region RideDetails

        public ActionResult RideDetails(Int32 intRideStatusID, Int32 VehicleTypeID, Int32 PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                VehicleFilterModel Model = new VehicleFilterModel();
                Model.intRideStatusID = intRideStatusID;
                Model.VehicleTypeID = VehicleTypeID;
                Model.IntPageNumber = PageNumber;
                Model.IntPageSize = 50;


                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                List<Ride> listObj = new List<Ride>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                listObj = Obj.GetRidesForAdmin(Model, out TotalPageNumber);
                ViewBag.rideList = listObj;

                ViewBag.TotalPageNumber = TotalPageNumber;
                ViewBag.intRideStatusID = intRideStatusID;
                ViewBag.selectedVehicleTypeID = VehicleTypeID;
                ViewBag.pageNumber = PageNumber;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult AddRide(int vehicleTypeId)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                ViewBag.VehicleTypeId = vehicleTypeId;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddRide(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                Ride ridesObj = new Ride();
                Utility en = new Utility();


                ridesObj.PhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                ridesObj.Name = form["txtUserName"];
                ridesObj.OTP = 0;
                ridesObj.DropLocation = form["txtDropLocation"];
                ridesObj.PickUpLocation = form["txtPickUpLocation"];
                ridesObj.VehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
                ridesObj.Password = en.Encrypt(ridesObj.PhoneNumber.ToString());


                ManagementServiceWrapper manageObj = new ManagementServiceWrapper();
                int returnValue = manageObj.BookNow(ridesObj);

                return Json(returnValue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult EditRideDetails(Int32 rideID)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                InformationServiceWrapper serviceObj = new InformationServiceWrapper();
                Ride model = serviceObj.GetRideDetailsByID(rideID);
                if (model != null)
                {
                    ViewBag.rideDetails = model;
                    ViewBag.rideID = model.intRideID;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult EditRideDetails(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                Ride ridesObj = new Ride();
                Utility en = new Utility();
                ridesObj.intRideID = Convert.ToInt32(form["rideID"]);
                ridesObj.DropLocation = form["txtDropLocation"];
                ridesObj.PickUpLocation = form["txtPickUpLocation"];
                ridesObj.VehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
                ridesObj.dtScheduledDate = form["txtScheduledDate"];
                ridesObj.txtScheduledTime = Convert.ToString(form["txtScheduledTime"]);
                ridesObj.txtVehicleNumber = form["txtAssignedVehicle"];
                ridesObj.txtRideStatus = form["intRideStatusID"];
                ridesObj.intRideAmount = Convert.ToDecimal(form["intRideAmount"]);
                ridesObj.intRideCommision = Convert.ToDecimal(form["intRideCommision"]);
                ridesObj.intRideKM = Convert.ToDecimal(form["intRideKM"]);

                ManagementServiceWrapper manageObj = new ManagementServiceWrapper();
                int returnValue = manageObj.UpateRideDetailsForAdmin(ridesObj);

                return Json(returnValue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult GetRideStatus()
        {
            List<GDictionaryModel> modelList = new List<GDictionaryModel>();
            InformationServiceWrapper inforObj = new InformationServiceWrapper();
            modelList = inforObj.GetRideStatus();
           // ViewBag.summaryList = modelList;
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PriceCheck

        public ActionResult APICheckPrice()
        {
            return View();
        }

        public ActionResult PriceCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PriceCalculator(FormCollection form)
        {
            int Kilometers = Convert.ToInt32(form["txtKilometers"]);
            int vehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
            string TravelRequestType = Convert.ToString(form["TravelRequestType"]);
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            
           PriceModel model = objservice.GetPriceForRide(Kilometers, vehicleTypeID, TravelRequestType);
            return Json(new { model }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region TrnVehicleDetails
         
        public ActionResult VehicleDetails(Int32 intStateID, Int32 intDistrictID, Int32 intManadalID, Int32 VehicleTypeID, Int32 PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                VehicleFilterModel Model = new VehicleFilterModel();
                Model.intStateId = intStateID;
                Model.intDistrictId = intDistrictID;
                Model.intManadalID = intManadalID;
                Model.VehicleTypeID = VehicleTypeID;
                Model.IntPageNumber = PageNumber;
                Model.IntPageSize = 50;

                List<VehicleFilterModel> VehList = new List<VehicleFilterModel>();
                VehList = objservice.GetVehicleDetailsForAdmin(Model, out TotalPageNumber);
                ViewBag.VehList = VehList;
                ViewBag.TotalPageNumber = TotalPageNumber;

                ViewBag.selectedStateID = intStateID;
                ViewBag.selectedDistrictID = intDistrictID;
                ViewBag.selectedMandalID = intManadalID;
                ViewBag.selectedVehicleTypeID = VehicleTypeID;
                ViewBag.pageNumber = PageNumber;

                return View("VehicleDetails");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult AddVehicle(Int64 phoneNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                ViewBag.phoneNumber = phoneNumber;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddVehicle(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            string returnvalue = "";
            if (nameCookie != null)
            {
                Vehicle model = new Vehicle();
                model.BigIntPhoneNumber = Convert.ToInt64(form["phoneNumber"]);
                model.intVehicleTypeID = Convert.ToInt32(form["ddlVehicleTypeID"]);
                model.txtVehicleName = form["txtVehicleModel"];
                model.txtVehicleNumber = form["txtVehicleNumber"].ToUpper();
                model.intOwnerID = form["ownerID"];
                ManagementServiceWrapper mangeObj = new ManagementServiceWrapper();
                returnvalue = mangeObj.AddVehicle(model);
                return Json(returnvalue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(returnvalue, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult DeteleVehicle(Int32 VehicleID, Int64 phoneNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                ManagementServiceWrapper objservice = new ManagementServiceWrapper();
                objservice.DeleteVehicle(VehicleID, phoneNumber);
                return Json(JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult EditVehicleDetails(int VehicleID, Int64 phoneNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                InformationServiceWrapper obj = new InformationServiceWrapper();
                Vehicle model = new Vehicle();

                model = obj.GetVehicledDetailsByID(VehicleID, phoneNumber);
                ViewBag.VehicleTypeID = model.intVehicleTypeID;
                ViewBag.VehicleName = model.txtVehicleName;
                ViewBag.VehicleNumber = model.txtVehicleNumber;
                ViewBag.VehicleId = model.intVehicleID;
                ViewBag.phoneNumber = phoneNumber;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult UpdateVehicleDetails(FormCollection form)
        {

            string returnvalue = "";

            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                Vehicle model = new Vehicle
                {
                    BigIntPhoneNumber = Convert.ToInt64(form["phoneNumber"]),
                    intVehicleTypeID = Convert.ToInt32(form["ddlVehicleTypeID"]),
                    txtVehicleName = form["txtVehicleModel"],
                    txtVehicleNumber = form["txtVehicleNumber"],
                    intVehicleID = Convert.ToInt32(form["intVehicleID"])
                };

                ManagementServiceWrapper mangeObj = new ManagementServiceWrapper();
                returnvalue = mangeObj.UpdateVehicleDetails(model);

                return Json(returnvalue, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        #endregion

        #region OwnerSearch

        public ActionResult OwnerSearch(){
            ViewBag.phoneNumber = "";
            ViewBag.ownerDetails =null;
            ViewBag.vehicleList = null;
            return View();
        }

        public ActionResult OwnerSearchWithPhoneNumber(Int64 phoneNumber)
        {
            ViewBag.phoneNumber = phoneNumber;
            InformationServiceWrapper obj = new InformationServiceWrapper();
            Tuple<VehicleFilterModel, List<VehicleFilterModel>> tupel = obj.GetOwnerDetailsByPhoneNumberForAdmin(phoneNumber);
            List<VehicleFilterModel> vehicles = tupel.Item2;
            VehicleFilterModel owner = tupel.Item1;

            ViewBag.ownerDetails = owner;
            ViewBag.vehicleList = vehicles;

            return View("OwnerSearch");

        }

        public ActionResult OwnerSearchWithPhoneOrVehicleNumber(string phoneorVehicleNumber)
        {
            ViewBag.phoneNumber = phoneorVehicleNumber;
            InformationServiceWrapper obj = new InformationServiceWrapper();
            Tuple<VehicleFilterModel, List<VehicleFilterModel>> tupel = obj.GetOwnerDetailsByPhoneOrVehicleNumberForAdmin(phoneorVehicleNumber);
            List<VehicleFilterModel> vehicles = tupel.Item2;
            VehicleFilterModel owner = tupel.Item1;

            ViewBag.ownerDetails = owner;
            ViewBag.vehicleList = vehicles;

            return View("OwnerSearch");

        }

        #endregion

        #region MasterVehicleTypes

        public ActionResult VehicleTypesForAdmin()
        {
            InformationServiceWrapper obj = new InformationServiceWrapper();
            List<VehicleTypesModel> modelList = new List<VehicleTypesModel>();
            modelList = obj.VehicleTypeForAdmin();
            if (modelList != null)
            {
                ViewBag.vehicleList = modelList;
            }
            return View("VehicleTypes");
        }

        public ActionResult UpdateVehicleTypes(Int32 vehicleTypeID)
        {
            ViewBag.vehicleTypeID = vehicleTypeID;
            InformationServiceWrapper obj = new InformationServiceWrapper();
            VehicleTypesModel model = new VehicleTypesModel();
            model = obj.GetVehicleTypeByIDForAdmin(vehicleTypeID);
            ViewBag.VehicleTypes = model;

            return View("EditVehicleTypes");
        }

        [HttpPost]
        public ActionResult UpdateVehicleTypes(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                VehicleTypesModel model = new VehicleTypesModel();
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                model.intVehicleTypeId = Convert.ToInt32(form["intVehicleTypeId"]);
                model.intMileage = Convert.ToInt32(form["intMileage"]);
                model.intAverageFuelPrice = Convert.ToDecimal(form["intAverageFuelPrice"]);
                model.intDriverSalary = Convert.ToDecimal(form["intDriverSalary"]);
                model.intAvgTollPrice = Convert.ToDecimal(form["intAvgTollPrice"]);
                model.intAverageSpeed = Convert.ToInt32(form["intAverageSpeed"]);
                model.intAvgWorkingHours = Convert.ToInt32(form["intAvgWorkingHours"]);
                model.BaseFare = Convert.ToDecimal(form["BaseFare"]);

                string success = obj.UpdateVehicleTypes(model);

                return Json(success, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        #endregion

        #region DriverRelated

        public ActionResult AddDriver()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
       
        [HttpPost]
        public ActionResult AddDriver(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {

                DriverModel model = new DriverModel();
                Utility en = new Utility();

                Int32 driverID = 0;

                model.txtDriverName = form["txtUserName"];
                model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                model.txtPassword = en.Encrypt(form["txtPhoneNumber"]);
                model.intStateId = Convert.ToInt32(form["ddlStateID"]);
                model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
                model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
                model.txtPlace = form["txtVillage"];
                model.OTP = 0;

                string errorMessage = "";

                string s = "[^<>'\"/`%-]";
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtDriverName, s))
                {
                    errorMessage = errorMessage + "Special character are not allowed in Name.\n";
                }

                if (!System.Text.RegularExpressions.Regex.Match(model.BigIntPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                {
                    errorMessage = errorMessage + "Enter valid Phone Number.\n";
                }

                if (!Regex.Match(model.intStateId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid State.\n";
                }

                if (!Regex.Match(model.intDistrictId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid District.\n";
                }

                if (!Regex.Match(model.intManadalID.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid Mandal.\n";
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtPlace, s))
                {
                    errorMessage = errorMessage + "special characters are not allowed in Place.\n";
                }


                GDictionaryModel GDOBJ = new GDictionaryModel();
                if (errorMessage == "")
                {
                    ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                    InformationServiceWrapper infoObj = new InformationServiceWrapper();
                    GDOBJ = infoObj.MobileNuberExistsOrNot(model.BigIntPhoneNumber, UserType.driver.ToString());
                    if (GDOBJ.ID == 1)
                    {
                        ManagementServiceWrapper serviceObj = new ManagementServiceWrapper();

                        driverID = serviceObj.DriverRegistration(model);

                        return Json("success", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        errorMessage = "Entered mobiler number is already registered with us.\n";
                        return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DriverDetails(Int32 intStateID, Int32 intDistrictID, Int32 intManadalID, Int32 PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                VehicleFilterModel Model = new VehicleFilterModel();
                Model.intStateId = intStateID;
                Model.intDistrictId = intDistrictID;
                Model.intManadalID = intManadalID;
                Model.IntPageNumber = PageNumber;
                Model.IntPageSize = 50;

                List<VehicleFilterModel> driverList = new List<VehicleFilterModel>();
                driverList = objservice.GetDriverDetailsForAdmin(Model, out TotalPageNumber);
                ViewBag.driverList = driverList;
                ViewBag.TotalPageNumber = TotalPageNumber;

                ViewBag.selectedStateID = intStateID;
                ViewBag.selectedDistrictID = intDistrictID;
                ViewBag.selectedMandalID = intManadalID;
                ViewBag.pageNumber = PageNumber;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult EditDriverDetails(Int32 driverID)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                DriverModel Model = objservice.GetDriverDetailsByIDForAdmin(driverID);
                ViewBag.existingMobileNumber = Model.BigIntPhoneNumber;
                ViewBag.intDriverID = Model.intDriverID;
                ViewBag.driver = Model;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult EditDriverDetails(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                DriverModel model = new DriverModel();

                model.txtDriverName = form["txtUserName"];
                model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                model.intStateId = Convert.ToInt32(form["ddlStateID"]);
                model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
                model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
                model.intDriverID = Convert.ToInt32(form["DriverID"]);
                model.txtPlace = form["txtVillage"];
                string mobileNumberChangedOrNOT = form["changedOrNot"];
                string errorMessage = "";

                string s = "[^<>'\"/`%-]";
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtDriverName, s))
                {
                    errorMessage = errorMessage + "Special character are not allowed in Name.\n";
                }

                if (!System.Text.RegularExpressions.Regex.Match(model.BigIntPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                {
                    errorMessage = errorMessage + "Enter valid Phone Number.\n";
                }

                if (!Regex.Match(model.intStateId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid State.\n";
                }

                if (!Regex.Match(model.intDistrictId.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid District.\n";
                }

                if (!Regex.Match(model.intManadalID.ToString(), "[1-9]").Success)
                {
                    errorMessage = errorMessage + "Select valid Mandal.\n";
                }


                if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtPlace, s))
                {
                    errorMessage = errorMessage + "special characters are not allowed in Place.\n";
                }

                ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                InformationServiceWrapper infoObj = new InformationServiceWrapper();
                GDictionaryModel GDOBJ = new GDictionaryModel();

                if (mobileNumberChangedOrNOT == "changed")
                {
                    GDOBJ = infoObj.MobileNuberExistsOrNot(model.BigIntPhoneNumber, UserType.driver.ToString());
                }
                if (mobileNumberChangedOrNOT == "changed" & GDOBJ.ID != 1)
                {
                    errorMessage = errorMessage + "Entered mobiler number is already registered with us.\n";
                }

                if (errorMessage == "")
                {

                    ManagementServiceWrapper serviceObj = new ManagementServiceWrapper();

                    serviceObj.UpdateDriverDetailsByAdmin(model);

                    return Json("success", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        #endregion

        #region PriceMultiple

        public ActionResult GetPriceMultiple()
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                List<PriceMultipleModel> listModel = new List<PriceMultipleModel>();
                InformationServiceWrapper wrapper = new InformationServiceWrapper();
                listModel = wrapper.GetPriceMultiple();
                ViewBag.priceMultipleList = listModel;
                return View("PriceMultiple");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult UpdatePriceMultiple(int pricePK)
        {
            InformationServiceWrapper wrapper = new InformationServiceWrapper();
            PriceMultipleModel model = wrapper.GetPriceMultipleByIDForAdmin(pricePK);
            if (model != null)
            {
                ViewBag.pricePK = pricePK;
                ViewBag.priceMultiple = model.intPriceMultiple;
                ViewBag.vehicleType = model.txtVehicleType;
                ViewBag.vehicleTypeID = model.intVehicleTypeID;
                ViewBag.KMRange = model.intKMRange;
                ViewBag.intPricePerKM = model.intPricePerKM;

                
            }
            return View("EditPriceMultiple");
        }

        [HttpPost]
        public ActionResult UpdatePriceMultiple(FormCollection form)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                PriceMultipleModel model = new PriceMultipleModel();
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                model.intVehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
                model.intPriceMultiple = Convert.ToDecimal(form["intPriceMultiple"]);
                model.IntPricePK = Convert.ToInt32(form["IntPricePK"]);
                model.intPricePerKM = Convert.ToDecimal(form["intPricePerKM"]);


                string success = obj.UpdatePriceMultiple(model);

                return Json(success, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        #endregion

        #region BillGeneration

        public void DownloadPDF(int rideID)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
            
                //Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(@"..\images\logo.jpg"));


                string HTMLContent = @"<table style=""width:100%""><tr style=""color:green""><td>Bill for completed ride with BellaCabs.in</td></tr></table><br />";
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(GetPDF(HTMLContent, rideID));
                Response.End();
            }
        }

        public byte[] GetPDF(string pHTML, int rideID)
        {
            InformationServiceWrapper serviceObj = new InformationServiceWrapper();
            Ride model = serviceObj.GetRideDetailsByID(rideID);


            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file  
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document  
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document  
            doc.Open();
            htmlWorker.StartDocument();

            PdfPTable tblLogo = new PdfPTable(2);
            tblLogo.TotalWidth = 570f;
            //tblLogo.LockedWidth = true;
            tblLogo.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right

            iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/images/BellaCabsLogo.jpg"));
            imgLogo.ScaleToFit(50f, 40f);
            //imgLogo.SpacingBefore = 1f;
            //imgLogo.SpacingAfter = 10f;
            //imgLogo.Alignment = Element.ALIGN_LEFT;

            PdfPCell logoImageCell = new PdfPCell(imgLogo);
            logoImageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            logoImageCell.Border = 0;
            logoImageCell.PaddingRight = 5f;
            logoImageCell.PaddingBottom = 10f;
            tblLogo.AddCell(logoImageCell);


            //TextReader logotext = new StringReader(@"<span style=""font-weigth:bold;color:green""> BellaCabs.in </span>\n <span style="";color:blue"" > Just Call us to book any vehicle</span>"));
            BaseColor darkGreen = new BaseColor(Color.DarkGreen);
            BaseColor ForestGreen = new BaseColor(Color.ForestGreen);

            Paragraph LogoPara = new Paragraph();
            Phrase phrase2 = new Phrase("BellaCabs.in \n", FontFactory.GetFont("Calibri", 22f, iTextSharp.text.Font.BOLD, darkGreen));
          
            Phrase Phrase1 = new Phrase("Just call us to book any vehicle", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLUE));
            LogoPara.Add(phrase2);
            LogoPara.Add(Phrase1);


            PdfPCell logoCell1 = new PdfPCell(LogoPara);
            logoCell1.Border = 0;
            logoCell1.PaddingBottom = 10f;
            tblLogo.AddCell(logoCell1);

            doc.Add(tblLogo);

            PdfPTable tblSecondRow = new PdfPTable(1);
            tblSecondRow.TotalWidth = 570f;
            tblSecondRow.LockedWidth = true;
            tblSecondRow.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            PdfPCell SecondRow = new PdfPCell(new Phrase("Bill for completed ride with BellaCabs.in",FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
            SecondRow.Border = 0;
            SecondRow.PaddingTop =4f;
            SecondRow.PaddingBottom = 6f;
            SecondRow.BackgroundColor = ForestGreen;
            SecondRow.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

            tblSecondRow.AddCell(SecondRow);
            doc.Add(tblSecondRow);
            //Chunk c1 = new Chunk("BellaCabs.in");
            //doc.Add(c1);

            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 400f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            Paragraph pricePara = new Paragraph();
            Phrase amountP = new Phrase("Bill Amount is \n Rs. " + model.intRideAmount + " /- \n", FontFactory.GetFont("Calibri", 16f, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase kmsP = new Phrase("\nTotal Ride Kms: " + model.intRideKM * 2 + " Kms \n\n Bill ID: " + rideID, FontFactory.GetFont("Calibri", 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            pricePara.Add(amountP);
            pricePara.Add(kmsP);


            PdfPCell points = new PdfPCell(pricePara);
            points.Colspan = 1;
            points.Border = 0;
            points.PaddingTop = 30f;
            points.PaddingBottom = 20f;

            points.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

            table.AddCell(points);

            //string BillAmount = "500";
            //string MainTableContent = @"<table style=""width:100%""><tr style=""font-weigth:bold""><td style=""height:200px"">Bill Amount Rs. " + BillAmount + "/- <br /> Total Ride Kms: " + 100 + "KMS <br /> Bill ID: " + 1001 + "</td><td>"+ jpg + "</td></tr></table>";
            //TextReader txtReaderMainTableContent = new StringReader(MainTableContent);
            //Resize image depend upon your need

            string folderPath = "~/Content/QRCode/";
            string imagePath = "~/Content/QRCode/QRCode_" + rideID + ".jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("PhoneNumber: "+model.PhoneNumber+", RideID: "+rideID+", User Name: "+model.Name, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitMap = qrCode.GetGraphic(20);
            string barcodePath = Server.MapPath(imagePath);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    bitMap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }


            iTextSharp.text.Image QRCode = iTextSharp.text.Image.GetInstance(Path.Combine(Server.MapPath("~/Content/QRCode/QRCode_" + rideID + ".jpg")));
            QRCode.ScaleToFit(120f, 120f);

            QRCode.SpacingBefore = 1f;
            QRCode.SpacingAfter = 10f;

            //QRCode.Alignment = Element.ALIGN_LEFT;

            PdfPCell imageCell = new PdfPCell(QRCode);
            imageCell.Colspan =1; // either 1 if you need to insert one cell
            imageCell.Border = 0;
            imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
            imageCell.PaddingTop = 20f;
            imageCell.PaddingBottom = 20f;

            table.AddCell(imageCell);
            doc.Add(table);
            // 5: parse the html into the document  
            //htmlWorker.Parse(txtReader);

            //htmlWorker.Parse(txtReaderMainTableContent);

            PdfPTable HeadingBookingDetails = new PdfPTable(1);
            HeadingBookingDetails.TotalWidth = 570f;
            HeadingBookingDetails.LockedWidth = true;
            //HeadingBookingDetails.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            
            PdfPCell secondHeading = new PdfPCell(new Phrase("Booking Details", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
            secondHeading.Border = 0;
            secondHeading.PaddingTop = 4f;
            secondHeading.PaddingBottom = 4f;
            secondHeading.BackgroundColor = BaseColor.GRAY;
            secondHeading.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

            HeadingBookingDetails.AddCell(secondHeading);
            doc.Add(HeadingBookingDetails);


            PdfPTable BookingDetails = new PdfPTable(2);
            BookingDetails.TotalWidth = 570f;
            BookingDetails.PaddingTop = 20f;
            BookingDetails.LockedWidth = true;
            BookingDetails.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right

            PdfPCell Cell11 = new PdfPCell(new Phrase("Vehicle Type :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell11.Border = 0;
            Cell11.PaddingRight = 20f;
            Cell11.PaddingTop = 15f;
            Cell11.HorizontalAlignment = 2;//0=Left, 1=Centre, 2=Right

            BookingDetails.AddCell(Cell11);

            PdfPCell Cell12 = new PdfPCell(new Phrase(model.VehicleType, FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell12.Border = 0;
            Cell12.PaddingTop = 15f;
            Cell12.HorizontalAlignment = 0;//0=Left, 1=Centre, 2=Right

            BookingDetails.AddCell(Cell12);

            PdfPCell Cell21 = new PdfPCell(new Phrase("Pick Up Location :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell21.Border = 0;
            Cell21.PaddingRight = 20f;
            Cell21.PaddingTop = 15f;
            Cell21.HorizontalAlignment = 2;//0=Left, 1=Centre, 2=Right
            BookingDetails.AddCell(Cell21);

            PdfPCell Cell22 = new PdfPCell(new Phrase(model.PickUpLocation, FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell22.Border = 0;
            Cell22.PaddingTop = 15f;
            Cell22.HorizontalAlignment = 0;//0=Left, 1=Centre, 2=Right
            BookingDetails.AddCell(Cell22);

            PdfPCell Cell31 = new PdfPCell(new Phrase("Drop Location :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell31.Border = 0;
            Cell31.PaddingRight = 20f;
            Cell31.PaddingTop = 15f;
            Cell31.HorizontalAlignment = 2;//0=Left, 1=Centre, 2=Right
            BookingDetails.AddCell(Cell31);

            PdfPCell Cell32 = new PdfPCell(new Phrase(model.DropLocation, FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell32.Border = 0;
            Cell32.PaddingTop = 15f;
            Cell32.HorizontalAlignment = 0;
            BookingDetails.AddCell(Cell32);

            PdfPCell Cell61 = new PdfPCell(new Phrase("Ride requested by :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell61.Border = 0;
            Cell61.PaddingRight = 20f;
            Cell61.PaddingTop = 15f;
            Cell61.HorizontalAlignment = 2;
            BookingDetails.AddCell(Cell61);

            PdfPCell Cell62 = new PdfPCell(new Phrase(model.Name.ToString(), FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell62.Border = 0;
            Cell62.HorizontalAlignment = 0;
            Cell62.PaddingTop = 15f;
            BookingDetails.AddCell(Cell62);

            
            PdfPCell Cell41 = new PdfPCell(new Phrase("Phone Number :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell41.Border = 0;
            Cell41.PaddingRight = 20f;
            Cell41.PaddingTop = 15f;
            Cell41.HorizontalAlignment = 2;
            BookingDetails.AddCell(Cell41);

            PdfPCell Cell42 = new PdfPCell(new Phrase(model.PhoneNumber.ToString(), FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell42.Border = 0;
            Cell42.HorizontalAlignment = 0;
            Cell42.PaddingTop = 15f;
            BookingDetails.AddCell(Cell42);

            PdfPCell Cell71 = new PdfPCell(new Phrase("Ride Requested Date :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell71.Border = 0;
            Cell71.PaddingRight = 20f;
            Cell71.PaddingTop = 15f;
            Cell71.HorizontalAlignment = 2;
            BookingDetails.AddCell(Cell71);

            PdfPCell Cell72 = new PdfPCell(new Phrase(model.DtCreated.ToString(), FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell72.Border = 0;
            Cell72.HorizontalAlignment = 0;
            Cell72.PaddingTop = 15f;
            BookingDetails.AddCell(Cell72);

            PdfPCell Cell51 = new PdfPCell(new Phrase("Vehicle Number :", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell51.Border = 0;
            Cell51.PaddingRight = 20f;
            Cell51.PaddingTop = 15f;
            Cell51.HorizontalAlignment = 2;
            BookingDetails.AddCell(Cell51);

            PdfPCell Cell52 = new PdfPCell(new Phrase(model.txtVehicleNumber.ToString(), FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            Cell52.Border = 0;
            Cell52.HorizontalAlignment = 0;
            Cell52.PaddingTop = 15f;
            BookingDetails.AddCell(Cell52);

            doc.Add(BookingDetails);

            Paragraph Fnote1 = new Paragraph("\nFor queries and complaints please find below mentioned contact details \n\t  Web site: Bellacabs.in \n\t  Email: support@bellacabs.in \n\t  Phone Number: 7731018723.", FontFactory.GetFont("Calibri", 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            doc.Add(Fnote1);


            Paragraph singPara = new Paragraph("\n\n\nBellaCabs.in Employee Signature                                               Customer Signature", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            doc.Add(singPara);

            Paragraph placePara = new Paragraph("\n\nPlace : ", FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            doc.Add(placePara);

            Paragraph DatePara = new Paragraph("\n\nDate : "+ DateTime.Now.ToString("MMMM dd, yyyy"), FontFactory.GetFont("Calibri", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            doc.Add(DatePara);

            // 6: close the document and the worker  
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            var QRCodeFilePath = Path.Combine(Server.MapPath("~/Content/QRCode/QRCode_" + rideID.ToString() + ".jpg"));

            if (System.IO.File.Exists(QRCodeFilePath))
            {
                System.IO.File.Delete(QRCodeFilePath);
            }
                return bPDF;
        }

        #endregion

    }

}
