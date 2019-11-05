using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.ServiceLayerInterface;
using RaiteRaju.BusinessLayerInterface;
using RaiteRaju.Entities;
using System.ServiceModel;

namespace RaiteRaju.ServiceLayer
{
    public class InformationService : InformationServiceInterface
    {

        #region Manabandi
        public List<GDictionary> FetchStates() {
           InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
           return obj.FetchStates();
       }
       public List<GDictionary> FetDistrictsOfState(int StateId) {
           InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
           return obj.FetDistrictsOfState(StateId);
       }
       public List<GDictionary> FetMandalsOfDistrct(int DistrictId) {
           InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
           return obj.FetMandalsOfDistrct(DistrictId);
       }
       public List<GDictionary> GetVehicleTypes()
       {
           InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
           return obj.GetVehicleTypes();
       }
        public UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserDetailsWithOTP(OTP, PhoneNumber);
        }
        public UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserDetailsWithPassword(PhoneNumber, Password);
        }
        public List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserRides(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
        }
        public UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetLoginCheck(PhoneNumber, Password);
        }

        public List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicleDetails(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
        }
        #endregion
        public AdDetailsEntity FetchAdDetails(int AdId)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.FetchAdDetails(AdId);
        }
        public DropDrownWrapper GetDropDownValues()
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetDropDownValues();
        }
        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.MobileNuberExistsOrNot(MobileNumber, userType);

        }
        //public AdDetailsEntity GetImage(AdDetailsEntity obj)
        //{
        //    InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
        //    return BusObj.GetImage(obj);

        //}
        public List<AdDetailsEntity> SPRRGetADbyCategory(Int32 CategoryID, Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.SPRRGetADbyCategory(CategoryID, PAGENUMBER, out TotalPageNumber);

        }
        public AdDetailsEntity SPRRGetAdDisplayDetails(Int32 AdId, out int outputparam)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.SPRRGetAdDisplayDetails(AdId,out outputparam);

        }
        public List<AdDetailsEntity> GetFilteredAds(AdFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetFilteredAds(Entity, out TotalPageNumber);

        }
        public List<AdDetailsEntity> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchAdDetailsToVerify(PAGENUMBER, out TotalPageNumber);

        }
        public List<GDictionary> FetchReviews()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchReviews();

        }
        public List<Int32> getAdIdsWithUserid(Int32 userid)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.getAdIdsWithUserid(userid);
        }
        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.AdminLoginCheck(PhoneNumber, Password);
        }
        public List<UserDetailsEntity> FetchUserDetailsForAdminPage(AdFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchUserDetailsForAdminPage(Entity, out TotalPageNumber);
        }
        public List<AdDetailsEntity> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetAdDetailsForAdminPageVerifiedAds(PAGENUMBER, out TotalPageNumber);
        }
        public List<AdViewsStatisticsEntity> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchAdViewsStatistics(PAGENUMBER, out TotalPageNumber);
        }
        public List<AdDetailsEntity> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchAdsForHomePage(PAGENUMBER, out TotalPageNumber);
        }
        public List<ContactUsEntity> FetchContactUsDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchContactUsDetailsForAdmin();
        }

        public List<ReviewEntity> FetchReviewDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchReviewDetailsForAdmin();
        }
        public List<ExceptionEntity> FetchExceptionDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchExceptionDetailsForAdmin();
        }
        public List<UserDetailsEntity> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchUnverifiedUsers(PAGENUMBER,out TotalPageNumber);

        }
    }


}
