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
        public const string INSERT_MBUserDetails = "INSERT_MBUserDetails";
        public const string GET_VehicleTypes = "GET_VehicleTypes";
        public const string INSERT_MBVehicleOwnerDetails = "INSERT_MBVehicleOwnerDetails";
        public const string INSERT_MBExceptionLogging = "INSERT_MBExceptionLogging";
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
        public const string GET_MBAssignedRides = "GET_MBAssignedRides";

        public const string DELETE_MBVehicle = "DELETE_MBVehicle";
        public const string GET_MBVehicleDetailsByID = "GET_MBVehicleDetailsByID";
        public const string UPDATE_MBVehicleDetails = "UPDATE_MBVehicleDetails";
        public const string DELETE_User = "DELETE_User";
        public const string UPDATE_OTP = "UPDATE_OTP";
        public const string INSERT_MBContactUs = "INSERT_MBContactUs";
        public const string INSERT_MBReview = "INSERT_MBReview";
        #endregion


        #region ManaBandi Admin

        public const string Get_AdminLoginCheck = "Get_AdminLoginCheck";
        public const string GET_VehicleDetailsForAdmin = "GET_VehicleDetailsForAdmin";
        public const string DELETE_UserByAdmin = "DELETE_UserByAdmin";
        public const string DELETE_VehiclesByAdmin = "DELETE_VehiclesByAdmin";
        public const string GET_OwnerDetailsForAdmin = "GET_OwnerDetailsForAdmin";
        public const string GET_RideDetailForAdmin = "GET_RideDetailForAdmin";
        public const string GET_MBRideDetailsByID = "GET_MBRideDetailsByID";
        public const string GET_MBOwnerDetailsByIDForAdmin = "GET_MBOwnerDetailsByIDForAdmin";
        public const string UPDATE_MBVehicleOwnerDetailsByAdmin = "UPDATE_MBVehicleOwnerDetailsByAdmin";
        public const string GET_ReviewsForAdmin = "GET_ReviewsForAdmin";
        public const string GET_ContactDestailsForAdmin = "GET_ContactDestailsForAdmin";
        public const string GET_MBReviews = "GET_MBReviews";
        public const string GET_Price = "GET_Price";
        public const string GET_MBExceptionDetailsForAdmin = "GET_MBExceptionDetailsForAdmin";
        public const string GET_MBSummaryDetails = "GET_MBSummaryDetails";
        public const string UPDATE_MBRideDetails = "UPDATE_MBRideDetails";
        public const string GET_OwnerDetailsWithPhoneNumberAdmin = "GET_OwnerDetailsWithPhoneNumberAdmin";
        public const string GET_MBVehicleTypeForAdmin = "GET_MBVehicleTypeForAdmin";
        public const string GET_MBVehicleTypeByIDForAdmin = "GET_MBVehicleTypeByIDForAdmin";
        public const string UPDATE_MBVehicleTypes = "UPDATE_MBVehicleTypes";
        public const string INSERT_MBDriverDetails = "INSERT_MBDriverDetails";
        public const string GET_DriverDetailsForAdmin = "GET_DriverDetailsForAdmin";
        public const string GET_MBDriverDetailsByIDForAdmin = "GET_MBDriverDetailsByIDForAdmin";
        public const string UPDATE_MBDriverDetailsByAdmin = "UPDATE_MBDriverDetailsByAdmin";
        public const string GET_MBSUMMARY = "GET_MBSUMMARY";

        public const string GET_PriceMultiple = "GET_PriceMultiple";
        public const string UPDATE_PriceMultiple = "UPDATE_PriceMultiple";
        public const string GET_PriceMultipleByID = "GET_PriceMultipleByID";
        #endregion

        public const string INSERT_MBInsertPromotions = "INSERT_MBInsertPromotions";


    }
}
