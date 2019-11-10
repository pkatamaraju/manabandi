using System;
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
            if (nameCookie.Value != null)
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

                    // Session["LOGGEDONUSER"] = ModelObj.txtUserName;
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
        public ActionResult VerifyAds(int PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            DropDownWrapperModel ModelObj = new DropDownWrapperModel();
            ModelObj = objservice.GetDropDownValues();
            ViewBag.DistrictLIst = ModelObj.District;
            ViewBag.MandalList = ModelObj.Mandal;

            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                List<AdDetailsModel> AdList = new List<AdDetailsModel>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                AdList = Obj.FetchAdDetailsToVerify(PageNumber, out TotalPageNumber);
                ViewBag.Adlist = AdList;
                ViewBag.TotalPageNumber = TotalPageNumber;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult VerifyAds(string AdIdList)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int success = 0;
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                success = obj.VerifySelectedAds(AdIdList);
                return Json(success, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AdManagement(int PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            //InformationServiceWrapper objservice = new InformationServiceWrapper();
            //DropDownWrapperModel ModelObj = new DropDownWrapperModel();
            //ModelObj = objservice.GetDropDownValues();
            //ViewBag.DistrictLIst = ModelObj.District;
            //ViewBag.MandalList = ModelObj.Mandal;

            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                List<AdDetailsModel> AdList = new List<AdDetailsModel>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                AdList = Obj.FetAdDetailsForAdminPageVerifiedAds(PageNumber, out TotalPageNumber);
                ViewBag.Adlist = AdList;
                ViewBag.TotalPageNumber = TotalPageNumber;
                return View("AdManagement");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult AdManagement(string AdIdList)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int success = 0;
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                success = obj.DeleteAdsByAdmin(AdIdList);
                return Json(success, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult UserDetailsManagement(string State, string District, string DistrictId, string Mandal, string MandalId, Int32 PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                AdFilterModel Model = new AdFilterModel();
                Model.txtState = State == "" ? null : State; //form["ddlStateText"];
                Model.txtDistrict = District == "" ? null : District; //form["ddlDistrict"];
                Model.txtMandal = Mandal == "" ? null : Mandal; //form["ddlMandal"];
                Model.INTPAGENUMBER = PageNumber;
                Model.INTPAGESIZE = 50;

                List<UserDetailsModel> UserList = new List<UserDetailsModel>();
                UserList = objservice.FetchUserDetailsForAdminPage(Model, out TotalPageNumber);
                ViewBag.UserList = UserList;
                ViewBag.TotalPageNumber = TotalPageNumber;

                @ViewBag.selectedState = Model.txtState;
                @ViewBag.SelectedDistrictId = DistrictId;
                @ViewBag.selectedMandalId = MandalId;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult UserDetailsManagement(string UserIdList)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int success = 0;
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                success = obj.DeleteSelectedUserAccounts(UserIdList);
                return Json(success, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AdViewStatistics(int PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                List<AdViewStatisticsModel> UserList = new List<AdViewStatisticsModel>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                UserList = Obj.FetchAdViewsStatistics(PageNumber, out TotalPageNumber);
                ViewBag.UserList = UserList;
                ViewBag.TotalPageNumber = TotalPageNumber;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AdDisplay(int AdId)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            int AdViewCount = 0;
            if (nameCookie != null)
            {
                AdDetailsModel model = new AdDetailsModel();
                InformationServiceWrapper objservice = new InformationServiceWrapper();
                model = objservice.SPRRGetAdDisplayDetails(AdId, out AdViewCount);
                ViewBag.IntAdId = model.AdID;
                ViewBag.AdId = model.AdID + ".jpg";
                ViewBag.Title = model.txtAddTitle;
                ViewBag.Description = model.txtAdDescription;
                ViewBag.Category = model.Category;
                ViewBag.Price = model.txtPrice;
                ViewBag.Quantity = model.txtQuantity;
                ViewBag.Unit = model.SellingUnit;
                ViewBag.Name = model.Name;
                ViewBag.MobileNumber = model.MobileNuber.ToString();
                ViewBag.Location = model.Location;
                ViewBag.AdPostedDate = model.PostedDate;
                ViewBag.AdViewCount = AdViewCount;

                if (model.Category == "Fruit" || model.Category == "Pesticide" || model.Category == "Equipment" || model.Category == "Vegetable" || model.Category == "Others" || model.Category == "Fertilizer" || model.Category == "Seed" || model.Category == "Dairy Product")
                {
                    ViewBag.DefinedTitle = model.txtSubCategoryName + " " + model.txtQuantity + " " + model.SellingUnit + " at Price Rs." + model.txtPrice + " Per " + model.SellingUnit.Substring(0, model.SellingUnit.Length - 1);
                }
                else
                {
                    ViewBag.DefinedTitle = model.Category + " " + model.txtQuantity + " " + model.SellingUnit + " at Price Rs." + model.txtPrice + " Per " + model.SellingUnit.Substring(0, model.SellingUnit.Length - 1);
                } ViewBag.DefinedUnit = " /" + model.SellingUnit.Substring(0, model.SellingUnit.Length - 1);
                //searchingData
                //ViewBag.SearchOption = "CATEGORY";
                //ViewBag.PageNumber = PageNumber;
                //ViewBag.CategoryID = CategoryID;


                return View("/Views/AddPost/AdDisplay.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
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
        public ActionResult UserRegistration()
        {

            return View("UserRegistration");
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
        public ActionResult VerifyUsers(int PageNumber)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int TotalPageNumber = 0;
                ViewBag.CurrentPageNumber = PageNumber;
                List<UserDetailsModel> UserList = new List<UserDetailsModel>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                UserList = Obj.FetchUnverifiedUsers(PageNumber, out TotalPageNumber);
                ViewBag.UserList = UserList;
                ViewBag.TotalPageNumber = TotalPageNumber;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult VerifyUsers(string SelectedPhoneNumbers)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                int success = 0;
                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                success = obj.VerifyUsersByAdmin(SelectedPhoneNumbers);
                return Json(success, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

         [HttpPost]
        public ActionResult AdPostByAdmin(FormCollection fnPost)
        {
            int AdId = 0;
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                AdDetailsModel obj = new AdDetailsModel();
                obj.Category = fnPost["ddlCategoryText"];
                obj.txtSubCategoryName = fnPost["txtSubCategoryName"];
                obj.txtAdDescription = fnPost["txtAdDescription"];
                obj.txtPrice = Convert.ToInt32(fnPost["txtPrice"]);
                obj.txtQuantity = Convert.ToInt32(fnPost["txtQuantity"]);
                obj.SellingUnit = fnPost["ddlUnitText"];
                obj.MobileNuber = Convert.ToInt64(fnPost["txtPhoneNumber"]);
                if (obj.Category == "Fruit" || obj.Category == "Handloom" || obj.Category == "Equipment" || obj.Category == "Vegetable" || obj.Category == "Others")
                {
                    obj.txtSubCategoryName = obj.txtSubCategoryName;
                }
                else {
                    obj.txtSubCategoryName = obj.Category;
                }

                string s = "[^<>'\"/`%-]";
                int count = 0;

                if (System.Text.RegularExpressions.Regex.IsMatch(obj.Category, "^[a-zA-Z0-9 .]"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(obj.txtSubCategoryName, s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(obj.txtAdDescription, s))
                {
                    count = count + 1;
                }
                
                if (System.Text.RegularExpressions.Regex.IsMatch(obj.SellingUnit, "^[a-zA-Z0-9 .]"))
                {
                    count = count + 1;
                }
                if (Regex.Match(obj.txtPrice.ToString(), "[1-9]").Success)
                {
                    count = count + 1;
                }
                if (Regex.Match(obj.txtQuantity.ToString(), "[1-9]").Success)
                {
                    count = count + 1;
                }

                if (count == 6)
                {
                    AdId = ObjService.InsertAdPostByAdmin(obj);
                    return Json(AdId, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AdId = -1;
                    return Json(AdId, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase image, Int32 AdId)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];

            if (nameCookie != null)
            {
                HttpPostedFileBase file = Request.Files["ImageData"];

                if (file != null)
                {

                    var LENGTH = (file.ContentLength / 1024);
                    var ext = Path.GetExtension(file.FileName);
                    Stream strm = file.InputStream;

                    var ActualImagePath = Path.Combine(Server.MapPath("~/PhotoManagement/Actual/"), Convert.ToString(AdId) + ".jpg");
                    var CompressedImagePath = Path.Combine(Server.MapPath("~/PhotoManagement/Compressed/"), Convert.ToString(AdId) + ".jpg");

                    var CompressedDelPath = Path.Combine(Server.MapPath("~/PhotoManagement/Deleted/"), Convert.ToString(AdId) + "_Compressed_Deleted.jpg");
                    var ActualDelPath = Path.Combine(Server.MapPath("~/PhotoManagement/Deleted/"), Convert.ToString(AdId) + "_Actual_Deleted.jpg");

                    if (System.IO.File.Exists(CompressedImagePath))
                    {
                        System.IO.File.Delete(CompressedDelPath);
                        System.IO.File.Move(CompressedImagePath, CompressedDelPath);

                        if (System.IO.File.Exists(ActualImagePath))
                        {
                            System.IO.File.Delete(ActualDelPath);
                            System.IO.File.Move(ActualImagePath, ActualDelPath);
                        }

                        ReduceImageSize(strm, CompressedImagePath);
                        ReduceImageSizeForActualImage(strm, ActualImagePath, LENGTH);
                    }
                    else
                    {
                        ReduceImageSize(strm, CompressedImagePath);
                        ReduceImageSizeForActualImage(strm, ActualImagePath, LENGTH);
                    }

                    return Json(AdId, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(AdId, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(AdId, JsonRequestBehavior.AllowGet);
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }


        private void ReduceImageSize(Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                if (image.PropertyIdList.Contains(0x0112))
                {
                    int rotationValue = image.GetPropertyItem(0x0112).Value[0];
                    switch (rotationValue)
                    {
                        case 1: // landscape, do nothing
                            break;

                        case 8: // rotated 90 right
                            // de-rotate:
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                            break;

                        case 3: // bottoms up
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                            break;

                        case 6: // rotated 90 left
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                            break;
                    }
                }

                // image.RotateFlip(RotateFlipType.Rotate90FlipNone); 
                //var scaleFactor = 0.5;
                var newWidth = 155;// (int)(image.Width * scaleFactor);
                var newHeight = 110;// (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
        private void ReduceImageSizeForActualImage(Stream sourcePath, string targetPath, int length)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                if (image.PropertyIdList.Contains(0x0112))
                {
                    int rotationValue = image.GetPropertyItem(0x0112).Value[0];
                    switch (rotationValue)
                    {
                        case 1: // landscape, do nothing
                            break;

                        case 8: // rotated 90 right
                            // de-rotate:
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                            break;

                        case 3: // bottoms up
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                            break;

                        case 6: // rotated 90 left
                            image.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                            break;
                    }
                }


                var scaleFactor = 1.0;
                if (length >= 350)
                {
                    scaleFactor = 0.5;
                }
                var newHeight = (int)(image.Width * scaleFactor);
                var newWidth = (int)(image.Height * scaleFactor);
              
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
        public ActionResult AdDetails(int AdId)
        {
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                AdDetailsModel model = new AdDetailsModel();
                InformationServiceWrapper objservice = new InformationServiceWrapper();

                    model = objservice.FetchAdDetails(AdId);
                    ViewBag.AdId = model.AdID;
                    //ViewBag.Title = model.txtAddTitle;
                    ViewBag.Description = model.txtAdDescription;
                    ViewBag.SubCategoryName = model.txtSubCategoryName;
                    ViewBag.Category = model.Category;
                    ViewBag.Price = model.txtPrice;
                    ViewBag.Quantity = model.txtQuantity;
                    ViewBag.Unit = model.SellingUnit;
                    return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AdDetails(FormCollection fnAd)
        {
            int success = 0;
            HttpCookie nameCookie = Request.Cookies["_RRAUN"];
            if (nameCookie != null)
            {
                ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                AdDetailsModel obj = new AdDetailsModel();
                obj.AdID = Convert.ToInt32(fnAd["AdId"]);
                obj.Category = fnAd["ddlCategoryText"];
                obj.txtSubCategoryName = fnAd["txtSubCategoryName"];
                obj.txtAdDescription = fnAd["txtAdDescription"];
                obj.txtPrice = Convert.ToInt32(fnAd["txtPrice"]);
                obj.txtQuantity = Convert.ToInt32(fnAd["txtQuantity"]);
                obj.SellingUnit = fnAd["ddlUnitText"];
                HttpPostedFileBase file = Request.Files["myImage"];

                if (obj.Category == "Fruit" || obj.Category == "Pesticide" || obj.Category == "Equipment" || obj.Category == "Vegetable" || obj.Category == "Others" || obj.Category == "Fertilizer" || obj.Category == "Seed" || obj.Category == "Dairy Product")
                {
                    obj.txtSubCategoryName = obj.txtSubCategoryName;
                }
                else
                {
                    obj.txtSubCategoryName = obj.Category;
                }

                string s = "[^<>'\"/`%-]";
                int count = 0;

                if (System.Text.RegularExpressions.Regex.IsMatch(obj.Category, "^[a-zA-Z0-9 .]"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(obj.txtSubCategoryName, s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(obj.txtAdDescription, s))
                {
                    count = count + 1;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(obj.SellingUnit, "^[a-zA-Z0-9 .]"))
                {
                    count = count + 1;
                }
                if (Regex.Match(obj.txtPrice.ToString(), "[1-9]").Success)
                {
                    count = count + 1;
                }
                if (Regex.Match(obj.txtQuantity.ToString(), "[1-9]").Success)
                {
                    count = count + 1;
                }

                if (count == 6)
                {
                    ObjService.UpdateAdDetails(obj);
                    success = obj.AdID;
                    return Json(success, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    success = -99;
                    return Json(success, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
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


        #region ManaBandi Admin Methods
        public ActionResult GetVehicleDetailsForAdmin(Int32 intStateID, Int32 intDistrictID, Int32 intManadalID, Int32 VehicleTypeID, Int32 PageNumber)
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

        #endregion
    }
}