using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaiteRaju.ServiceMapper;
using RaiteRaju.Web.Models;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using RaiteRaju.ApplicationUtility;

namespace RaiteRaju.Web.Controllers
{
    public class PartnerController : ErrorController
    {
        // GET: Partner

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OwnerRegistration()
        {
                return View();
        }

        [HttpPost]
        public ActionResult OwnerRegistration(FormCollection form)
        {
            Owner model = new Owner();
            Utility en = new Utility();

            Random r = new Random();
            Int32 OTP = r.Next(100000, 999999);

            Int32 ownerID = 0;

            model.txtOwnerName = form["txtUserName"];
            model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
            model.txtPassword = en.Encrypt(form["txtPassword"]);
            model.intStateId = Convert.ToInt32(form["ddlStateID"]);
            model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
            model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
            model.txtPlace = form["txtVillage"];
            model.OTP = OTP;

            string errorMessage = "";

            string s = "[^<>'\"/`%-]";
            if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtOwnerName, s))
            {
                errorMessage = errorMessage + "Special character are not allowed in Name.\n";
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(en.Decrypt(model.txtPassword), s))
            {
                errorMessage = errorMessage + "Special character are not allowed in password.\n";
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

                    if (ownerID != 0)
                    {
                        HttpCookie KeyCookie = new HttpCookie("_RRPS");
                        KeyCookie.Values["_RRPS"] = en.Encrypt(model.txtPassword);
                        KeyCookie.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(KeyCookie);
                    }
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

        public ActionResult _VehicleList(int PageNumber)
        {
            int TotalPageNumber = 0;
            ViewBag.CurrentPageNumber = PageNumber;
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();

            if (UserNameCookie != null && KeyCookie != null)
            {
                Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                string PassWord = en.Decrypt(KeyCookie["_RRPS"].ToString());
                List<Vehicle> ListObj = new List<Vehicle>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                ListObj = Obj.GetVehicleDetails(PhoneNumber, PassWord, PageNumber, out TotalPageNumber);
                if (ListObj != null)
                {
                    ViewBag.vehicleList = ListObj;
                }
            }
            else if (UserNameCookie != null && OTPCookie != null)
            {
                Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                Utility UtilObj = new Utility();
                string OTP = UtilObj.Decrypt(OTPCookie["_ROTP_"]);
                List<Vehicle> ListObj = new List<Vehicle>();
                InformationServiceWrapper Obj = new InformationServiceWrapper();
                ListObj = Obj.GetVehicleDetails(PhoneNumber, OTP, PageNumber, out TotalPageNumber);
                if (ListObj != null)
                {
                    ViewBag.vehicleList = ListObj;
                }
            }
            ViewBag.TotalPageNumber = TotalPageNumber;
            return PartialView("_VehicleList");
        }

        public ActionResult AddVehicle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddVehicle(FormCollection form)
        {
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();
            string returnvalue = "";
            if ((PhoneNumberCookie != null && KeyCookie != null) || (PhoneNumberCookie != null && OTPCookie != null))
            {
                Vehicle model = new Vehicle();
                model.BigIntPhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                model.intVehicleTypeID = Convert.ToInt32(form["ddlVehicleTypeID"]);
                model.txtVehicleName = form["txtVehicleModel"];
                model.txtVehicleNumber = form["txtVehicleNumber"].ToUpper();

                ManagementServiceWrapper mangeObj = new ManagementServiceWrapper();
                returnvalue=mangeObj.AddVehicle(model);
                return Json(returnvalue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(returnvalue, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult DeleteVehicle(int VehicleID)
        {
            int succuss = 0;
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();
            if (PhoneNumberCookie != null)
            {

                ManagementServiceWrapper obj = new ManagementServiceWrapper();
                Int64 BigIntPhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                obj.DeleteVehicle(VehicleID, BigIntPhoneNumber);
                return Json(1, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(succuss, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditVehicleDetails(int VehicleID)
        {
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();

            if ((PhoneNumberCookie != null && KeyCookie != null) || (PhoneNumberCookie != null && OTPCookie != null))
            {
                InformationServiceWrapper obj = new InformationServiceWrapper();
                Vehicle model = new Vehicle();
                Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                model = obj.GetVehicledDetailsByID(VehicleID, PhoneNumber);
                ViewBag.VehicleTypeID = model.intVehicleTypeID;
                ViewBag.VehicleName = model.txtVehicleName;
                ViewBag.VehicleNumber = model.txtVehicleNumber;
                ViewBag.VehicleId = model.intVehicleID;

                    
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateVehicleDetails(FormCollection form)
        {
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();
            string returnvalue = "";

            if ((PhoneNumberCookie != null && KeyCookie != null) || (PhoneNumberCookie != null && OTPCookie != null))
            {
                Vehicle model = new Vehicle();

                model.BigIntPhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                model.intVehicleTypeID = Convert.ToInt32(form["ddlVehicleTypeID"]);
                model.txtVehicleName = form["txtVehicleModel"];
                model.txtVehicleNumber = form["txtVehicleNumber"];
                model.intVehicleID = Convert.ToInt32(form["intVehicleID"]);

                ManagementServiceWrapper mangeObj = new ManagementServiceWrapper();
               returnvalue= mangeObj.UpdateVehicleDetails(model);

                return Json(returnvalue, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(returnvalue, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult DriverRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DriverRegistration(FormCollection form)
        {
            DriverModel model = new DriverModel();
            Utility en = new Utility();

            Random r = new Random();
            Int32 OTP = r.Next(100000, 999999);

            Int32 ownerID = 0;

            model.txtDriverName = form["txtUserName"];
            model.BigIntPhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
            model.txtPassword = en.Encrypt(form["txtPassword"]);
            model.intStateId = Convert.ToInt32(form["ddlStateID"]);
            model.intDistrictId = Convert.ToInt32(form["ddlDistrictID"]);
            model.intManadalID = Convert.ToInt32(form["ddlMandalID"]);
            model.txtPlace = form["txtVillage"];
            model.OTP = OTP;

            string errorMessage = "";

            string s = "[^<>'\"/`%-]";
            if (!System.Text.RegularExpressions.Regex.IsMatch(model.txtDriverName, s))
            {
                errorMessage = errorMessage + "Special character are not allowed in Name.\n";
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(en.Decrypt(model.txtPassword), s))
            {
                errorMessage = errorMessage + "Special character are not allowed in password.\n";
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


                    ownerID = serviceObj.DriverRegistration(model);

                    if (ownerID != 0)
                    {
                        HttpCookie KeyCookie = new HttpCookie("_RRPS");
                        KeyCookie.Values["_RRPS"] = en.Encrypt(model.txtPassword);
                        KeyCookie.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(KeyCookie);
                    }
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



    }

}