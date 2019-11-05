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
    public class PartnerController : Controller
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
            model.BigIntPhoneNumber =Convert.ToInt64( form["txtPhoneNumber"]);
            model.txtPassword =en.Encrypt( form["txtPassword"]);
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
            if (errorMessage=="")
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

        [HttpPost]
        public ActionResult AddVehicle(FormCollection form) {


            Vehicle model = new Vehicle();
            Utility en = new Utility();
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
           
            model.BigIntPhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
            model.intVehicleTypeID = Convert.ToInt32(form[""]);
            model.txtVehicleName = form["txtVehicleName"];
            model.txtVehicleNumber = form["txtVehicleNumber"];

            ManagementServiceWrapper mangeObj = new ManagementServiceWrapper();
            mangeObj.AddVehicle(model);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

    }
}