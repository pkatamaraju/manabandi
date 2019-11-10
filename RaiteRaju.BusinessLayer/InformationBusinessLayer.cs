using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.DAL;
using RaiteRaju.BusinessLayerInterface;
using RaiteRaju.Entities;

namespace RaiteRaju.BusinessLayer
{
    public class InformationBusinessLayer : InformationBusinessLayerInterface
    {
        #region Manabandi
        public List<GDictionary> FetchStates()
        {
            return new DAL.InformationDAL().FetchStates();
        }
        public List<GDictionary> FetDistrictsOfState(int StateId)
        {
            return new DAL.InformationDAL().FetDistrictsOfState(StateId);
        }
        public List<GDictionary> FetMandalsOfDistrct(int DistrictId)
        {
            return new DAL.InformationDAL().FetMandalsOfDistrct(DistrictId);
        }
        public List<GDictionary> GetVehicleTypes()
        {
            return new DAL.InformationDAL().GetVehicleTypes();
        }

        public UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            return new DAL.InformationDAL().GetUserDetailsWithOTP(OTP, PhoneNumber);
        }
        public UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password)
        {
            return new DAL.InformationDAL().GetUserDetailsWithPassword(PhoneNumber, Password);
        }
        public List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetUserRides(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
        }

        public UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password)
        {
            return new DAL.InformationDAL().GetLoginCheck(PhoneNumber, Password);
        }
       public List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetVehicleDetails(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);

        }
        public VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber)
        {
            return new DAL.InformationDAL().GetVehicledDetailsByID(VehicleID, PhoneNumber);

        }

        #endregion

        #region manabandi admin
       public List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetVehicleDetailsForAdmin(Entity,out TotalPageNumber);
        }
        #endregion
        public AdDetailsEntity FetchAdDetails(int AdId)
        {
            return new DAL.InformationDAL().FetchAdDetails(AdId);
        }
        public DropDrownWrapper GetDropDownValues()
        {
            return new DAL.InformationDAL().GetDropDownValues();
        }
        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            return new DAL.InformationDAL().MobileNuberExistsOrNot(MobileNumber,userType);
        }
        //public AdDetailsEntity GetImage(AdDetailsEntity obj)
        //{
        //    return new DAL.InformationDAL().GetImage(obj);
        //}
        public List<AdDetailsEntity> SPRRGetADbyCategory(Int32 CategoryID, Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().SPRRGetADbyCategory(CategoryID, PAGENUMBER, out TotalPageNumber);
        }
        public AdDetailsEntity SPRRGetAdDisplayDetails(Int32 AdId, out int outputparam)
        {
            return new DAL.InformationDAL().SPRRGetAdDisplayDetails(AdId,out outputparam);
        }
        public List<AdDetailsEntity> GetFilteredAds(AdFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetFilteredAds(Entity, out TotalPageNumber);
        }
        public List<AdDetailsEntity> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetchAdDetailsToVerify(PAGENUMBER, out TotalPageNumber);
        }
        public List<GDictionary> FetchReviews()
        {
            return new DAL.InformationDAL().FetchReviews();
        }
        public List<Int32> getAdIdsWithUserid(Int32 userid)
        {
            return new DAL.InformationDAL().getAdIdsWithUserid(userid);
        }
        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            return new DAL.InformationDAL().AdminLoginCheck(PhoneNumber, Password);
        }
        public List<UserDetailsEntity> FetchUserDetailsForAdminPage(AdFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetchUserDetailsForAdminPage(Entity, out TotalPageNumber);
        }
        public List<AdDetailsEntity> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetAdDetailsForAdminPageVerifiedAds(PAGENUMBER, out TotalPageNumber);
        }
        public List<AdViewsStatisticsEntity> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetchAdViewsStatistics(PAGENUMBER, out TotalPageNumber);
        }
        public List<AdDetailsEntity> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetchAdsForHomePage(PAGENUMBER, out TotalPageNumber);
        }

        public List<ContactUsEntity> FetchContactUsDetailsForAdmin()
        {
            return new DAL.InformationDAL().FetchContactUsDetailsForAdmin();
        }
        public List<ReviewEntity> FetchReviewDetailsForAdmin()
        {
            return new DAL.InformationDAL().FetchReviewDetailsForAdmin();
        }
        public List<ExceptionEntity> FetchExceptionDetailsForAdmin()
        {
            return new DAL.InformationDAL().FetchExceptionDetailsForAdmin();
        }
        public List<UserDetailsEntity> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().FetchUnverifiedUsers(PAGENUMBER,out TotalPageNumber);
        }
    }

}
