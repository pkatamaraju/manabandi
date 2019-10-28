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
        
        public ActionResult BookNow(int VehicleTypeId)
        {
            ViewBag.VehicleTypeId = VehicleTypeId;
            return View();
        }
    }
}
    
