using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using RaiteRaju.Entities;

namespace RaiteRaju.ServiceLayerInterface
{
    [ServiceContract]
    public interface InformationServiceInterface
    {

        #region Manabandi

        [OperationContract]
        List<GDictionary> FetchStates();
        [OperationContract]
        List<GDictionary> FetDistrictsOfState(int StateId);
        [OperationContract]
        List<GDictionary> FetMandalsOfDistrct(int DistrictId);
        [OperationContract]
        List<GDictionary> GetVehicleTypes();
        [OperationContract]
        UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber);

        [OperationContract]
        UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password);
        [OperationContract]
        List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);
        [OperationContract]
        UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password);
        [OperationContract]
        List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);

        [OperationContract]
        VehicleEntity GetVehicledDetailsByID(int VehicleID,Int64 PhoneNumber);


        #endregion

        #region manabandi admin
        List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);
        List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber);
        List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);

        int GetPriceForRide(int KM, int VehicleTypeId);
        #endregion

        [OperationContract]
        AdDetailsEntity FetchAdDetails(int AdId);

        [OperationContract]
        DropDrownWrapper GetDropDownValues();
        [OperationContract]
        GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType);
        //[OperationContract]
        //AdDetailsEntity GetImage(AdDetailsEntity obj);
        [OperationContract]
        List<AdDetailsEntity> SPRRGetADbyCategory(Int32 CategoryID, Int32 PAGENUMBER, out int TotalPageNumber);
        [OperationContract]
        AdDetailsEntity SPRRGetAdDisplayDetails(Int32 AdId, out int outputparam);
        [OperationContract]
        List<AdDetailsEntity> GetFilteredAds(AdFilterEntity Entity, out int TotalPageNumber);
        [OperationContract]
        List<AdDetailsEntity> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber);
        [OperationContract]
        List<GDictionary> FetchReviews();
        [OperationContract]
        List<Int32> getAdIdsWithUserid(Int32 userid);
        [OperationContract]
        UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password);

        [OperationContract]
        List<UserDetailsEntity> FetchUserDetailsForAdminPage(AdFilterEntity Entity, out int TotalPageNumber);

        [OperationContract]
        List<AdDetailsEntity> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber);

        [OperationContract]
        List<AdViewsStatisticsEntity> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber);
        [OperationContract]
        List<AdDetailsEntity> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber);

        [OperationContract]
        List<ContactUsEntity> FetchContactUsDetailsForAdmin();

        [OperationContract]
        List<ReviewEntity> FetchReviewDetailsForAdmin();

        [OperationContract]
        List<ExceptionEntity> FetchExceptionDetailsForAdmin();

        [OperationContract]
        List<UserDetailsEntity> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber);
    }

}
