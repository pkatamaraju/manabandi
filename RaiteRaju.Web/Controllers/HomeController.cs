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

namespace RaiteRaju.Web.Controllers
{
    public class HomeController : ErrorController
    {
                
        public static int PageNumber;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {

            
            return View();
        }
        
        [HttpPost]
        public ActionResult FetchDistricts(int StateId)
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.FetDistrictsOfState(StateId),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FetchMandals(int DistrictId)
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.FetMandalsOfDistrct(DistrictId),JsonRequestBehavior.AllowGet);
        }

    }
}
