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
        //
        // GET: /Home/
        public static int PageNumber;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {

            //InformationServiceWrapper objservice = new InformationServiceWrapper();
            //DropDownWrapperModel ModelObj = new DropDownWrapperModel();
            //ModelObj = objservice.GetDropDownValues();
            //ViewBag.DistrictLIst = ModelObj.District;
            //ViewBag.MandalList = ModelObj.Mandal;
            return View();
        }
        //public ActionResult _HomeAds(int PageNumber)
        //{
        //    int outTotalPageNumber = 0;
        //    ViewBag.CurrentPageNumber = PageNumber;
        //    InformationServiceWrapper objservice = new InformationServiceWrapper();
        //    List<AdDetailsModel> LisModelObj = new List<AdDetailsModel>();
        //    LisModelObj = objservice.FetchAdsForHomePage(PageNumber, out outTotalPageNumber);
        //    ViewBag.TotalPageNumber = outTotalPageNumber;
        //    ViewBag.Adlist = LisModelObj;
        //    return PartialView("_HomeAds");
        //}
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
        public ActionResult GetCategories()
        {
            InformationServiceWrapper objservice = new InformationServiceWrapper();
            return Json(objservice.GetCategories(), JsonRequestBehavior.AllowGet);

        }
    }
}
