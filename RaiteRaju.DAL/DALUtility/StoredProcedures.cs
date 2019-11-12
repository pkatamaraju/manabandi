using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.DAL.DALUtility
{
   public class StoredProcedures
    {

        #region ManaBandi


        public const string GET_DistrictsForStateID= "GET_DistrictsForStateID";
        public const string INSERT_MBRideDetails="INSERT_MBRideDetails";
        public const string GET_VehicleTypes = "GET_VehicleTypes";
        public const string INSERT_MBVehicleOwnerDetails = "INSERT_MBVehicleOwnerDetails";
        public const string INSERT_MBExceptionLogging = "INSERT_MBExceptionLogging";
        public const string INSERT_MBInsertContactUs = "INSERT_MBInsertContactUs";
        public const string UPDATE_UserStatusToVerified = "UPDATE_UserStatusToVerified";
        public const string GET_GetUserDetailsWithPassword = "GET_GetUserDetailsWithPassword";
        public const string GET_GetUserDetailsWithOTP ="GET_GetUserDetailsWithOTP";
        public const string GET_MBLoginCheck = "GET_MBLoginCheck";
        public const string GET_UserRides= "GET_UserRides";
        public const string UPDATE_MBUserDetails = "UPDATE_MBUserDetails";
        public const string GET_MandalsOfDistrict= "GET_MandalsOfDistrict";
        public const string GET_MobileValidation = "GET_MobileValidation";
        public const string INSERT_VehicleDetails = "INSERT_VehicleDetails";
        public const string GET_VehicleDetails = "GET_VehicleDetails";


        public const string DELETE_MBVehicle = "DELETE_MBVehicle";
        public const string GET_MBVehicleDetailsByID = "GET_MBVehicleDetailsByID";
        public const string UPDATE_MBVehicleDetails = "UPDATE_MBVehicleDetails";
        public const string DELETE_User = "DELETE_User";
        public const string UPDATE_OTP = "UPDATE_OTP";


        #endregion


        #region ManaBandi Admin

        public const string Get_AdminLoginCheck = "Get_AdminLoginCheck";
        public const string GET_VehicleDetailsForAdmin = "GET_VehicleDetailsForAdmin";
        public const string DELETE_UserByAdmin = "DELETE_UserByAdmin";
        public const string DELETE_VehiclesByAdmin = "DELETE_VehiclesByAdmin";
        public const string GET_OwnerDetailsForAdmin = "GET_OwnerDetailsForAdmin";
        public const string GET_RideDetailForAdmin = "GET_RideDetailForAdmin";
        public const string GET_ReviewsForAdmin = "GET_ReviewsForAdmin";
        public const string GET_ContactDestailsForAdmin = "GET_ContactDestailsForAdmin";
        public const string GET_MBReviews = "GET_MBReviews";
        public const string GET_Price = "GET_Price";
        #endregion





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
      public const string SPGetUserRides = "SPRRGetUserRides";

      public const string SPGETDistrictList = "SPRRGETDistrictList";
      public const string SPGETMandalList = "SPRRGETMandalList";

      public const string SPFETCHSTATESLIST = "SPRRFetchStates";
      public const string SPFETCHDISTRICTSOFSTATE = "SPRRFetchDestrictOfState";
      public const string SPFETCHMANDALSOFDISTRICT = "SPRRFetchMandalsOfDistrict";


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
