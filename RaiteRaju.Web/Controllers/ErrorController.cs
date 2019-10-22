using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaiteRaju.ServiceMapper;

namespace RaiteRaju.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        public ActionResult NotFound()
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var Exception = filterContext.Exception.Message;
            ManagementServiceWrapper objwrap = new ManagementServiceWrapper();
            objwrap.ExceptionLoggin((string)controllerName, (string)actionName, (string)Exception);
            base.OnException(filterContext);
        }
    }
}