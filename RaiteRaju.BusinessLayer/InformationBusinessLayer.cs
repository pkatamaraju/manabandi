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

        public List<RideEntity> GetAssignedRideDetails(Int64 phoneNumber, int intPageNumber, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetAssignedRideDetails(phoneNumber, intPageNumber, out TotalPageNumber);
        }
        #endregion

        #region manabandi admin
        public List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetVehicleDetailsForAdmin(Entity, out TotalPageNumber);
        }

        public List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetOwnerDetailsForAdminPage(Entity, out TotalPageNumber);
        }

        public List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            return new DAL.InformationDAL().GetRidesForAdmin(Entity, out TotalPageNumber);
        }

        public int GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType, out int cost)
        {
            return new DAL.InformationDAL().GetPriceForRide(KM, VehicleTypeId, TravelRequestType, out cost);
        }

        public RideEntity GetRideDetailsByID(int rideID)
        {
            return new DAL.InformationDAL().GetRideDetailsByID(rideID);
        }

        public OwnerEntity GetOwnerDetailsByIDForAdmin(int ownerID)
        {
            return new DAL.InformationDAL().GetOwnerDetailsByIDForAdmin(ownerID);
        }

        public Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber)
        {
            return new DAL.InformationDAL().GetOwnerDetailsByPhoneNumberForAdmin(phoneNumber);
        }

        #endregion

        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            return new DAL.InformationDAL().MobileNuberExistsOrNot(MobileNumber,userType);
        }

        public List<GDictionary> FetchReviews()
        {
            return new DAL.InformationDAL().FetchReviews();
        }

      
        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            return new DAL.InformationDAL().AdminLoginCheck(PhoneNumber, Password);
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
       
    }

}
