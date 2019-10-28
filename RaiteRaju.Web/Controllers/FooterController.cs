using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaiteRaju.ServiceMapper;
using RaiteRaju.Web.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace RaiteRaju.Web.Controllers
{
    public class FooterController : ErrorController
    {
        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Careers()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(FormCollection ContUs)
        {
            ContactUsModel ModelObj = new ContactUsModel();
            int success = 0;

            ModelObj.PhoneNumber = Convert.ToInt64(ContUs["txtPhoneNumber"]);
            ModelObj.Subject = ContUs["txtSubject"];
            ModelObj.Description = ContUs["txtContactUsDescription"];
            int count = 0;
            if (System.Text.RegularExpressions.Regex.Match(ModelObj.PhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
            {
                count = count + 1;
            }
            string s = "[^<>'\"/`%-]";
            if (System.Text.RegularExpressions.Regex.IsMatch(ModelObj.Subject, s))
            {
                count = count + 1;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(ModelObj.Description, s))
            {
                count = count + 1;
            }
            ManagementServiceWrapper manobj = new ManagementServiceWrapper();
            if (count == 3)
            {
                success = manobj.insertContactUs(ModelObj);
            }
           return Json(success,JsonRequestBehavior.AllowGet) ;
        }
        public ActionResult ReportIssue()
        {
            return View();
        }
        
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            List<GDictionaryModel> list = new List<GDictionaryModel>();
            InformationServiceWrapper InforObj = new InformationServiceWrapper();
            list = InforObj.FetchReviews();
            ViewBag.ReviewList = list;
            return View();
        }
        [HttpPost]
        public ActionResult Reviews(FormCollection RVCollection)
        {
            int success = 0;
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];

            if (UserIdCookie != null)
            {
                Utility en = new Utility();
                    string ReviewDescription = RVCollection["txtReviewDescription"];
                    Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                    ManagementServiceWrapper wrapobj = new ManagementServiceWrapper();
                    success = wrapobj.InsertReview(PhoneNumber, ReviewDescription);
                }
                else
                {
                    success = 0;
                }
            return Json(success,JsonRequestBehavior.AllowGet);
                
        }
        public ActionResult TermsAndConditions()
        {
            return View();
        }
        public ActionResult TermsOfUse()
        {
            return View();
        }
        public ActionResult FeaturedAds()
        {
            return View();
        }
        public ActionResult HowToRegister()
        {
            return View();

        }
        public ActionResult HowToBook()
        {
            return View();
        }
        public ActionResult Partner()
        {
            return View();
        }
        public ActionResult Promotions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Promotions(FormCollection Promote)
        {
            ContactUsModel ModelObj = new ContactUsModel();
            int success = 0;

            Int64 PhoneNumber = Convert.ToInt64(Promote["txtPhoneNumber"]);
            string Name = Promote["txtName"];
            string Description = Promote["txtContactUsDescription"];
            int count = 0;

            if (System.Text.RegularExpressions.Regex.Match(PhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
            {
                count = count + 1;
            }
            string s = "[^<>'\"/`%-]";
            if (System.Text.RegularExpressions.Regex.IsMatch(Name, s))
            {
                count = count + 1;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(Description, s))
            {
                count = count + 1;
            }
            ManagementServiceWrapper manobj = new ManagementServiceWrapper();
            if (count == 3)
            {
                success = manobj.InsertPromotions(Name, PhoneNumber, Description);
            }
            return Json(success, JsonRequestBehavior.AllowGet);
        }
    }
}