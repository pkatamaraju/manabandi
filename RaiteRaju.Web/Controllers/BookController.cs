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
using System.Drawing.Imaging;

namespace RaiteRaju.Web.Controllers
{
    public class BookController : ErrorController
    {
        public ActionResult GetVehicleTypes()
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.GetVehicleTypes(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult BookNow(int vehicleTypeId)
        {
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            Utility en = new Utility();
            ViewBag.VehicleTypeId = vehicleTypeId;

            if (UserNameCookie != null && KeyCookie != null)
            {
                ViewBag.Enable = "DISABLE";
            }
            else if (UserNameCookie != null && OTPCookie != null)
            {
                ViewBag.Enable = "DISABLE";
            }
            else
            {
                ViewBag.Enable = "ENABLE";
            }
            return View();
        }

        [HttpPost]
        public ActionResult BookNow(FormCollection form)
        {
            Ride ridesObj = new Ride();
            Utility en = new Utility();
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];

            Random r = new Random();
            Int32 OTP = 0;

            if (PhoneNumberCookie!=null && UserNameCookie != null)
            {
                ridesObj.PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                ridesObj.Name = Convert.ToString(UserNameCookie["_RRUN"]);
            }
            else
            {
                ridesObj.PhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
                ridesObj.Name = form["txtUserName"];

                OTP = r.Next(100000, 999999);
                ridesObj.OTP = OTP;
            }
            ridesObj.DropLocation = form["txtDropLocation"];
            ridesObj.PickUpLocation = form["txtPickUpLocation"];
            ridesObj.VehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
            ridesObj.Password = en.Encrypt(ridesObj.PhoneNumber.ToString());
            //ridesObj.RefrerredByPhoneNumber = !string.IsNullOrEmpty(form["txtReferredBy"]) ? Convert.ToInt64(form["txtReferredBy"]) : 0;
            
           
            HttpCookie OTPCookie = new HttpCookie("_ROTP_");
            OTPCookie.Values["_ROTP_"] = en.Encrypt(OTP.ToString());
            OTPCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(OTPCookie);

            ManagementServiceWrapper manageObj = new ManagementServiceWrapper();
            int returnValue = manageObj.BookNow(ridesObj);

            return Json(returnValue, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult PriceCalculator(FormCollection form)
        {
            int Kilometers = Convert.ToInt32(form["txtKilometers"]);
            int vehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
            string TravelRequestType = Convert.ToString(form["TravelRequestType"]);
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            PriceModel price = objservice.GetPriceForRide(Kilometers, vehicleTypeID, TravelRequestType);
            return Json(price.FinalPrice, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PriceCalculator()
        {
            return View();
        }


        public ActionResult BookNowAPITesting()
        {
            return View();
        }
    }
}
    
