using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.DAL.DALUtility
{
   public class StoredProcedures
    {
      public const string SPINSERTADDDETAILS = "SPRRInsertAddDetails";
      public const string SPINSERTUSERDETAILS= "SPRRInsertUserDetails";
      public const string SPUPDATEOTP = "SPRRUpdateOTP";
      public const string SPGETUSERDETAILSWITHPASSWORD = "SPRRGetUSERDetailsWithPassword";
      public const string SPGETUSERDETAILSWITHOTP = "SPRRGetUserDetailsWithOTP";
      public const string SPLOGINCHECK = "SPRRLoginCheck";
      public const string SPGETADDETAILS = "SPRRGetAdDetails";
      public const string SPUPDATEADDETAILS = "SPRRUpdateAdDetails";
      public const string SPDELETEUSERAD = "SPRRDeletUserAd";
      public const string SPLOGINCHECKWITHOTP = "SPRRLOGINWithOTP";
      public const string SPVERIFYMOBILENUMBER = "SPRRVerifyMobilerNumber";
      public const string SPMOBILERNUMBERVALIDATION = "SPRRMobileValidation";
      public const string SPUPDAGEUSERDETAILS = "SPRRUpdateUserDetails";
      public const string SPUPLOADIMAGE= "SPRRUploadImages";
      public const string SPGETIMAGE = "SPRRGETmages";
      public const string SPGetUSERAds = "SPRRGetUserAds";

      public const string SPGETDistrictList = "SPRRGETDistrictList";
      public const string SPGETMandalList = "SPRRGETMandalList";

      public const string SPFETCHSTATESLIST = "SPRRFetchStates";
      public const string SPFETCHDISTRICTSOFSTATE = "SPRRFetchDestrictOfState";
      public const string SPFETCHMANDALSOFDISTRICT = "SPRRFetchMandalsOfDistrict";
      public const string SPGETCATEGORIES = "SPRRGetCategories";

      public const string SPGetADbyCategory = "SPRRGetADbyCategory";
      public const string SPGETADDISPLAYDETAILS = "SPRRGetAdDisplayDetails";
      public const string SPGETFILTEREDADS = "SPRRGETFILTEREDAds";
      public const string SPDELETEUSERACCOUNT = "SPRRDeleteUserAccount";
      public const string SPInsertContactUs = "SPRRInsertContactUs";
      public const string SPInsertReview = "SPRRInsertReview";
      public const string SPFetchReviews = "SPRRFetchReviews";
      public const string SPgetAdIdswithUserid = "SPRRgetAdIdswithUserid";
      public const string SPInsertAdViewsStatistics="SPRRInsertAdViewsStatistics";
      public const string SPFetchAdsForHomePage = "SPRRFetchAdsForHomePage";
      public const string SPINSERTPROMOTIONS = "SPRRInsertPromotions";
      public const string SPEXCEPTIONLOGGING="SPRRExceptionLogging";


#region admin
      public const string SPGetAdminLoginCheck = "SPRRGetAdminLoginCheck";
      public const string SPFetchUnverifiedAds = "SPRRFetchUnverifiedAds";
      public const string SPVerifyAds = "SPRRVerifyAds";
      public const string SRUserAccountDeletionByAdmin = "SPRRUserAccountDeletionByAdmin";
      public const string SPFetchUserDetailsForAdminManagement="SPRRFetchUserDetailsForAdminManagement";
      public const string SPFetchAdDetailsForAdminPage = "SPRRFetchAdDetailsForAdminPage";
      public const string SPDeleteAdsByAdmin= "SPRRDeleteAdsByAdmin";
      public const string SPFetchAdViewsStatistis = "SPRRFetchAdViewsStatistis";
      public const string SPFetchContactDestails = "SPRRFetchContactDestails";
      public const string SPFetchReviewsForAdmin = "SPRRFetchReviewsForAdmin";
      public const string SPFetchExceptionDetailsForAdmin = "SPRRFetchExceptionDetailsForAdmin";
      public const string SPFetchUnverifiedUsersForAdmin = "SPRRFetchUnverifiedUsersForAdmin";
      public const string SPVerifyUsersByAdmin = "SPRRVerifyUsersByAdmin";
      public const string SPAdPostByAdmin = "SPRRAdPostByAdmin";
#endregion

    }
}
