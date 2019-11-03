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
            ViewBag.VehicleTypeId = vehicleTypeId;
            return View();
        }
        [HttpPost]
        public ActionResult BookNow(FormCollection form)
        {
            Ride ridesObj = new Ride();
            Utility en = new Utility();

            ridesObj.DropLocation = form["txtDropLocation"];
            ridesObj.PickUpLocation = form["txtPickUpLocation"];
            ridesObj.Name = form["txtUserName"];
            ridesObj.VehicleTypeID = Convert.ToInt32(form["intVehicleTypeId"]);
            ridesObj.PhoneNumber = Convert.ToInt64(form["txtPhoneNumber"]);
            ridesObj.Password = en.Encrypt(ridesObj.PhoneNumber.ToString());
            Random r = new Random();
            Int32 OTP = r.Next(100000, 999999);
            ridesObj.OTP = OTP;
           
            HttpCookie OTPCookie = new HttpCookie("_ROTP_");
            OTPCookie.Values["_ROTP_"] = en.Encrypt(OTP.ToString());
            OTPCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(OTPCookie);

            ManagementServiceWrapper manageObj = new ManagementServiceWrapper();
            int returnValue = manageObj.BookNow(ridesObj);

            return Json(returnValue, JsonRequestBehavior.AllowGet);

        }
    }
}
    
