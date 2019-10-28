using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaiteRaju.Web.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AttachVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AttachVehicle(FormCollection form)
        {
            return View();

        }
    }
}