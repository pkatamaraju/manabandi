using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;

namespace RaiteRaju.BusinessLayerInterface
{
    public interface InformationBusinessLayerInterface
    {
        #region Manabandi
        List<GDictionary> FetchStates();
        List<GDictionary> FetDistrictsOfState(int StateId);
        List<GDictionary> FetMandalsOfDistrct(int DistrictId);
        List<GDictionary> GetVehicleTypes();
        UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber);
        UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password);
        List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);
        UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password);
        List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);

        VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber);

        #endregion
        #region manabandi admin
        List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);
        List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber);
        List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);
        int GetPriceForRide(int KM, int VehicleTypeId);
        #endregion


        AdDetailsEntity FetchAdDetails(int AdId);
        DropDrownWrapper GetDropDownValues();
        GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType);
       // AdDetailsEntity GetImage(AdDetailsEntity obj);
        List<AdDetailsEntity> SPRRGetADbyCategory(Int32 CategoryID, Int32 PAGENUMBER, out int TotalPageNumber);
        AdDetailsEntity SPRRGetAdDisplayDetails(Int32 AdId,out int outputparam);

        List<AdDetailsEntity> GetFilteredAds(AdFilterEntity Entity, out int TotalPageNumber);
        List<AdDetailsEntity> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber);
        List<GDictionary> FetchReviews();
        List<Int32> getAdIdsWithUserid(Int32 userid);
        UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password);
        List<UserDetailsEntity> FetchUserDetailsForAdminPage(AdFilterEntity Entity, out int TotalPageNumber);
        List<AdDetailsEntity> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber);
        List<AdViewsStatisticsEntity> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber);
        List<AdDetailsEntity> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber);
        List<ContactUsEntity> FetchContactUsDetailsForAdmin();
        List<ReviewEntity> FetchReviewDetailsForAdmin();
        List<ExceptionEntity> FetchExceptionDetailsForAdmin();
        List<UserDetailsEntity> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber);
    }

}
