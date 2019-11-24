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
    public class UserController : ErrorController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];

            if (UserIdCookie != null && KeyCookie != null)
            {
                return RedirectToAction("UserAccount", "User");
            }
            else
            {
                return View("Login");
            }
        }
        
        [HttpPost]
        public ActionResult Login(FormCollection fnLogin)
        {
            Int64 PhoneNumber =Convert.ToInt64( fnLogin["txtPhoneNumber"]);
            Utility en = new Utility();
            string PassWord  = en.Encrypt(fnLogin["txtPassword"]);

            InformationServiceWrapper Obj = new InformationServiceWrapper();
            UserDetailsModel ModelObj = new UserDetailsModel();
            ModelObj = Obj.GetLoginCheck(PhoneNumber, PassWord);

            if (ModelObj.txtUserName != null)
            {
                HttpCookie KeyCookie = new HttpCookie("_RRPS");
                HttpCookie UserIdCookie = new HttpCookie("_RRUID");
                HttpCookie PhoneNumberCookie = new HttpCookie("_RRUPn");
                HttpCookie UserNameCookie = new HttpCookie("_RRUN");

                KeyCookie.Values["_RRPS"] = en.Encrypt(PassWord);
                UserIdCookie.Values["_RRUID"] = en.Encrypt(ModelObj.intUserId.ToString());
                PhoneNumberCookie.Values["_RRUPn"] = en.Encrypt(fnLogin["txtPhoneNumber"]);

                if (ModelObj.txtUserName.Length <= 10)
                {
                    UserNameCookie.Values["_RRUN"]= ModelObj.txtUserName;
                }
                else
                {
                    UserNameCookie.Values["_RRUN"]= ModelObj.txtUserName.Substring(0, 10) + "..";
                }

                KeyCookie.Expires = DateTime.Now.AddDays(365);
                UserIdCookie.Expires = DateTime.Now.AddDays(365);
                PhoneNumberCookie.Expires = DateTime.Now.AddDays(365);
                UserNameCookie.Expires = DateTime.Now.AddDays(365);

                Response.Cookies.Add(KeyCookie);
                Response.Cookies.Add(UserIdCookie);
                Response.Cookies.Add(PhoneNumberCookie);
                Response.Cookies.Add(UserNameCookie);

                return Json(ModelObj.txtUserName, JsonRequestBehavior.AllowGet);  
            }
            else
            {
                return Json("",JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Registration()
        {
            //InformationServiceWrapper objservice = new InformationServiceWrapper();
            //DropDownWrapperModel ModelObj = new DropDownWrapperModel();
            //ModelObj = objservice.GetDropDownValues();
            //ViewBag.DistrictLIst = ModelObj.District;
            //ViewBag.MandalList = ModelObj.Mandal;
            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormCollection fnRegistration)
        {
            int count = 0;
                int UserId; //=(Int32)Session["_RRUID"];
                UserDetailsModel objModel = new UserDetailsModel();

                objModel.txtUserName = fnRegistration["txtUserName"];
                objModel.txtPhoneNumber = Convert.ToInt64(fnRegistration["txtPhoneNumber"]);

                Utility en = new Utility();
                objModel.txtPassword = en.Encrypt(fnRegistration["txtPassword"]);
                objModel.ddlState = fnRegistration["ddlStateText"];
                objModel.ddlDistrict = fnRegistration["ddlDistrict"];
                objModel.ddlMandal = fnRegistration["ddlMandal"];
                objModel.txtVillage = fnRegistration["txtVillage"];
               // objModel.txtMailId = fnRegistration["txtMailId"];
                objModel.OTP = fnRegistration[""];

                string s ="[^<>'\"/`%-]";
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtUserName, s))
                {
                    count = count+1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlState, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlDistrict, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlMandal, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(en.Decrypt(objModel.txtPassword), s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.Match(objModel.txtPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtVillage, s))
                {
                    count = count + 1;
                }


                GDictionaryModel GDOBJ = new GDictionaryModel();
                if (count == 7)
                {
                    ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                    InformationServiceWrapper infoObj = new InformationServiceWrapper();
                    GDOBJ = infoObj.MobileNuberExistsOrNot(objModel.txtPhoneNumber, UserType.user.ToString());
                    if (GDOBJ.ID == 1)
                    {
                        UserId = ObjService.InsertAddUserDetails(objModel);
                        if (UserId != 0)
                        {
                            HttpCookie KeyCookie = new HttpCookie("_RRPS");
                            KeyCookie.Values["_RRPS"] =en.Encrypt(objModel.txtPassword);
                            KeyCookie.Expires = DateTime.Now.AddDays(365);
                            Response.Cookies.Add(KeyCookie);
                        }
                        return Json(UserId, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ViewBag.MobileError = "Entered Mobiler Number is already registered";
                        return Json(GDOBJ.ID, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    GDOBJ.ID = -1;
                    return Json(GDOBJ.ID, JsonRequestBehavior.AllowGet);
                }
        }

        public ActionResult Verification(string MobileNumber)
        {
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            if (OTPCookie != null || KeyCookie!=null)
            {
                ViewBag.MobileNumber = MobileNumber;
                return View("OTPVerification");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
        }

        [HttpPost]
        public ActionResult Verification(FormCollection fnVer)
        {
            ManagementServiceWrapper obj = new ManagementServiceWrapper();
            UserDetailsModel Model = new UserDetailsModel();

            Model = obj.VerifyMobileNumber(Convert.ToInt32(fnVer["txtOTP"]), Convert.ToInt64(fnVer["BigIntMobileNumber"]));
            Utility en = new Utility();
            if (Model.txtUserName!=null)
            {
                HttpCookie OTPCookie = new HttpCookie("_ROTP_");
                HttpCookie KeyCookie = new HttpCookie("_RRPS");
                HttpCookie UserIdCookie = new HttpCookie("_RRUID");
                HttpCookie PhoneNumberCookie = new HttpCookie("_RRUPn");
                HttpCookie UserNameCookie = new HttpCookie("_RRUN");

                UserIdCookie.Values["_RRUID"] =en.Encrypt( Model.intUserId.ToString());
                PhoneNumberCookie.Values["_RRUPn"] = en.Encrypt(Model.txtPhoneNumber.ToString());
                KeyCookie.Values["_RRPS"] = en.Encrypt(Model.txtPassword.ToString());

                if (Model.txtUserName.Length <= 10)
                {
                    UserNameCookie.Values["_RRUN"] = Model.txtUserName;
                }
                else
                {
                    UserNameCookie.Values["_RRUN"] = Model.txtUserName.Substring(0, 10) + "..";
                }

                UserIdCookie.Expires = DateTime.Now.AddDays(365);
                PhoneNumberCookie.Expires = DateTime.Now.AddDays(365);
                UserNameCookie.Expires = DateTime.Now.AddDays(365);
                KeyCookie.Expires = DateTime.Now.AddDays(365);
 
                Response.Cookies.Add(UserIdCookie);
                Response.Cookies.Add(KeyCookie);
                Response.Cookies.Add(PhoneNumberCookie);
                Response.Cookies.Add(UserNameCookie);
                Utility Utilobj = new Utility();
                OTPCookie.Values["_ROTP_"] = en.Encrypt(fnVer["txtOTP"]);

                OTPCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(OTPCookie);
                return Json(Model.txtUserName, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

            
        }
        
        [HttpPost]
        public ActionResult UpdateUserDetails(FormCollection fnRegistration)
        {
            int UserId;
            Utility en = new Utility();
            UserDetailsModel objModel = new UserDetailsModel();

            
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];

            if (UserIdCookie != null)
            {
                objModel.txtUserName = fnRegistration["txtUserNameDetails"];
                objModel.intUserId = Convert.ToInt32(en.Decrypt(UserIdCookie["_RRUID"]));
                objModel.ddlState = fnRegistration["ddlStateText"];
                objModel.ddlDistrict = fnRegistration["ddlDistrict"];
                objModel.ddlMandal = fnRegistration["ddlMandal"];
                objModel.txtVillage = fnRegistration["txtVillage"];
                objModel.txtPhoneNumber=Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));

                objModel.KeyForUserSettings = Convert.ToString(UserSettings.DETAILS);
                string s = "[^<>'\"/`%-]";

                objModel.OTP = fnRegistration[""];
                int count = 0;
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtUserName, s))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlState, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlDistrict, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.ddlMandal, "^[a-zA-Z0-9 .]{1,50}"))
                {
                    count = count + 1;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtVillage, s))
                {
                    count = count + 1;
                }
                GDictionaryModel GDOBJ = new GDictionaryModel();
                if (count == 5)
                {
                    ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                    UserId = ObjService.UpdateUserDetails(objModel);

                    if (UserId != 0)
                    {
                        if (objModel.txtUserName.Length <= 10)
                        {
                            UserNameCookie.Values["_RRUN"] = objModel.txtUserName;
                            UserNameCookie.Expires = DateTime.Now.AddDays(365);
                            Response.Cookies.Add(UserNameCookie);
                        }
                        else
                        {
                            UserNameCookie.Values["_RRUN"] = objModel.txtUserName.Substring(0, 10) + "..";
                            UserNameCookie.Expires = DateTime.Now.AddDays(365);
                            Response.Cookies.Add(UserNameCookie);
                        }
                    }
                    return Json(UserId, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(-99, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(-99, JsonRequestBehavior.AllowGet);
            }
           
        }

        [HttpPost]
        public ActionResult UpdatePassword(FormCollection fnRegistration)
        {
            int UserId;
           
            UserDetailsModel objModel = new UserDetailsModel();
            Utility en = new Utility();
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];


            if (UserIdCookie != null)
              {
                  objModel.intUserId = Convert.ToInt32(en.Decrypt(UserIdCookie["_RRUID"]));
                  objModel.txtPassword = en.Encrypt(fnRegistration["txtPassword"]);
                  objModel.KeyForUserSettings = Convert.ToString(UserSettings.PASSWORD);

                  if (System.Text.RegularExpressions.Regex.IsMatch(objModel.txtPassword, "[^<>'\"/`%-]"))
                  {
                      ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                      UserId = ObjService.UpdateUserDetails(objModel);
                      if (UserId != 0)
                      {
                          KeyCookie.Values["_RRPS"] = en.Encrypt(objModel.txtPassword);
                          KeyCookie.Expires = DateTime.Now.AddDays(365);
                          Response.Cookies.Add(KeyCookie);
                      }
                      return Json(UserId, JsonRequestBehavior.AllowGet);
                  }
                  else
                  {
                      return Json(-99, JsonRequestBehavior.AllowGet);
                  }
              }
              else
              {
                  return Json(-99, JsonRequestBehavior.AllowGet);
              }
        }

        [HttpPost]
        public ActionResult UpdatePhoneNumber(FormCollection fnRegistration)
         {
             int UserId;
             HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
             HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];

             if (UserIdCookie != null)
             {
                 GDictionaryModel GDModel = new GDictionaryModel();
                 UserDetailsModel objModel = new UserDetailsModel();
                 ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
                 InformationServiceWrapper InfoService = new InformationServiceWrapper();
                 Utility en = new Utility();
                 objModel.intUserId = Convert.ToInt32(en.Decrypt(UserIdCookie["_RRUID"]));
                 objModel.txtPhoneNumber = Convert.ToInt64(fnRegistration["txtPhoneNumber"]);
                 objModel.KeyForUserSettings = Convert.ToString(UserSettings.PHONENUMBER);

                 GDModel = InfoService.MobileNuberExistsOrNot(objModel.txtPhoneNumber, UserType.user.ToString());
                 if (GDModel.ID == 0)
                 {
                     ViewBag.MobileError = "Entered Mobiler Number is already registered";
                     return Json(0, JsonRequestBehavior.AllowGet);

                 }
                 else if (GDModel.ID == 1 && Regex.Match(objModel.txtPhoneNumber.ToString(), @"^[56789]\d{9}$").Success)
                 {
                         UserId = ObjService.UpdateUserDetails(objModel);
                         if (UserId!=0)
                         {
                             PhoneNumberCookie.Values["_RRUPn"] = en.Encrypt(objModel.txtPhoneNumber.ToString());
                             PhoneNumberCookie.Expires = DateTime.Now.AddDays(365);
                             Response.Cookies.Add(PhoneNumberCookie);
                         }
                         return Json(UserId, JsonRequestBehavior.AllowGet);
                 }
                 else
                 {
                     return Json(-99, JsonRequestBehavior.AllowGet);
                 }
             }
             else
             {
                 return Json(-99, JsonRequestBehavior.AllowGet);
             }
         }
     
        [HttpPost]
        public ActionResult UpdateOTP(Int64 PhoneNumber)
        {
           int otp;
           Utility en = new Utility();
            UserDetailsModel objModel = new UserDetailsModel();
            objModel.txtPhoneNumber = PhoneNumber;
            ManagementServiceWrapper ObjService = new ManagementServiceWrapper();
            InformationServiceWrapper infoObj = new InformationServiceWrapper();
            GDictionaryModel GDOBJ = new GDictionaryModel();
            GDOBJ = infoObj.MobileNuberExistsOrNot(PhoneNumber, UserType.user.ToString());

            if (GDOBJ.ID == 0)
            {
                otp = ObjService.UpdateOtp(objModel);
                HttpCookie OTPCookie = new HttpCookie("_ROTP_");
                OTPCookie.Values["_ROTP_"] = en.Encrypt(otp.ToString());
                OTPCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(OTPCookie);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult UserAccount()
        {
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie = Request.Cookies["_ROTP_"];

            Utility en = new Utility();
            if (PhoneNumberCookie != null && KeyCookie != null)
            {
                Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                string PassWord = en.Decrypt(KeyCookie["_RRPS"]);

                UserDetailsModel DetObj = new UserDetailsModel();

                InformationServiceWrapper Obj = new InformationServiceWrapper();
                DetObj = Obj.GetUserDetailsWithPassword(PhoneNumber, PassWord);

                if (DetObj != null)
                {
                    ViewBag.txtUserName = DetObj.txtUserName;
                    ViewBag.txtPhoneNumber = DetObj.txtPhoneNumber;
                    ViewBag.txtVillage = DetObj.txtVillage;
                    ViewBag.ddlState = DetObj.ddlState;
                    ViewBag.ddlMandal = DetObj.ddlMandal;
                    ViewBag.ddlDistrict = DetObj.ddlDistrict;
                }
                if (DetObj.UserType == "OWNER")
                {
                    return View("OwnerAccount");
                }
                else
                {
                    return View("UserAccount");
                }
            }
            else if (PhoneNumberCookie != null && OTPCookie != null)
            {
                Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                Utility UtilOBJ = new Utility();
                int OTP = Convert.ToInt32(UtilOBJ.Decrypt(en.Decrypt(OTPCookie["_ROTP_"])));
                UserDetailsModel DetObj = new UserDetailsModel();

                InformationServiceWrapper Obj = new InformationServiceWrapper();
                DetObj = Obj.GetUserDetailsWithOTP(OTP, PhoneNumber);

                if (DetObj != null)
                {
                    ViewBag.txtUserName = DetObj.txtUserName;
                    ViewBag.txtPhoneNumber = DetObj.txtPhoneNumber;
                    ViewBag.txtVillage = DetObj.txtVillage;
                    ViewBag.ddlState = DetObj.ddlState;
                    ViewBag.ddlMandal = DetObj.ddlMandal;
                    ViewBag.ddlDistrict = DetObj.ddlDistrict;
                }

                if (DetObj.UserType == "OWNER")
                {
                    return View("OwnerAccount");
                }
                else
                {
                    return View("UserAccount");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        
        //[NoCache]
        public ActionResult _RideList(int PageNumber)
        {
            int TotalPageNumber = 0;
            ViewBag.CurrentPageNumber = PageNumber;
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie UserNameCookie = Request.Cookies["_RRUN"];
            HttpCookie PhoneNumberCookie = Request.Cookies["_RRUPn"];
            HttpCookie OTPCookie=Request.Cookies["_ROTP_"];
            Utility en = new Utility();

            if (UserNameCookie!= null && KeyCookie != null)
                {
                    Int64 PhoneNumber = Convert.ToInt64(en.Decrypt (PhoneNumberCookie["_RRUPn"]));
                    string PassWord =en.Decrypt ( KeyCookie["_RRPS"].ToString());
                    List<Ride> ListObj = new List<Ride>();
                    InformationServiceWrapper Obj = new InformationServiceWrapper();
                    ListObj = Obj.GetUserRides(PhoneNumber, PassWord, PageNumber, out  TotalPageNumber);
                    if (ListObj != null)
                    {
                        ViewBag.rideList = ListObj;
                    }
                }
            else if (UserNameCookie != null && OTPCookie != null)
                {
                    Int64 PhoneNumber = Convert.ToInt64(en.Decrypt(PhoneNumberCookie["_RRUPn"]));
                    Utility UtilObj = new Utility();
                    string OTP = UtilObj.Decrypt(OTPCookie["_ROTP_"]);
                    List<Ride> ListObj = new List<Ride>();
                    InformationServiceWrapper Obj = new InformationServiceWrapper();
                    ListObj = Obj.GetUserRides(PhoneNumber, OTP, PageNumber, out  TotalPageNumber);
                    if (ListObj != null)
                    {
                        ViewBag.rideList = ListObj;
                    }
                }
            ViewBag.TotalPageNumber = TotalPageNumber;
            return PartialView("_RideList");
        }

        public ActionResult UserLogout()
        {
           // Session.Clear();

            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                aCookie.Value = null;
                Response.Cookies.Add(aCookie);
            }

            return RedirectToAction("Home","Home");
        }

        public ActionResult _UserSettings()
        {
            return PartialView("_UserSettings");
        }

        public ActionResult _Payments()
        {
            return PartialView("_Payments");
        }

        public ActionResult DeleteAccount(Int64 BigIntPhoneNumber)
        {
            int succuss =0;
            HttpCookie UserIdCookie = Request.Cookies["_RRUID"];
            HttpCookie KeyCookie = Request.Cookies["_RRPS"];
            HttpCookie OTPCookie=Request.Cookies["_ROTP_"];
            if (UserIdCookie != null)
            {
                if ((UserIdCookie!= null && KeyCookie != null) ||(UserIdCookie!=null && OTPCookie!=null))
                {
                    ManagementServiceWrapper obj = new ManagementServiceWrapper();
                    succuss = obj.DeleteUserAccount(BigIntPhoneNumber);
                    return Json(succuss, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(succuss,JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(succuss, JsonRequestBehavior.AllowGet);
            }
        }
      
        //public class NoCache : ActionFilterAttribute
        //{
        //    public override void OnResultExecuting(ResultExecutingContext filterContext)
        //    {
        //        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
        //        filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        filterContext.HttpContext.Response.Cache.SetNoStore();

        //        base.OnResultExecuting(filterContext);
        //    }
        //}
    }
}
