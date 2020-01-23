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

        public List<GDictionary> FetDistrictsOfState(int StateId)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.FetDistrictsOfState(StateId);
        }

        public List<GDictionary> FetMandalsOfDistrct(int DistrictId)
        {
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

        public VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicledDetailsByID(VehicleID, PhoneNumber);
        }

        public List<RideEntity> GetAssignedRideDetails(Int64 phoneNumber, int intPageNumber, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetAssignedRideDetails(phoneNumber, intPageNumber, out TotalPageNumber);
        }

        #endregion

        #region manabandi admin
        public List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicleDetailsForAdmin(Entity, out TotalPageNumber);
        }

        public List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsForAdminPage(Entity, out TotalPageNumber);
        }

        public List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetRidesForAdmin(Entity, out TotalPageNumber);
        }

        public PriceEntity GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetPriceForRide(KM, VehicleTypeId, TravelRequestType);
        }

        public RideEntity GetRideDetailsByID(int rideID)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetRideDetailsByID(rideID);
        }


        public OwnerEntity GetOwnerDetailsByIDForAdmin(int ownerID)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsByIDForAdmin(ownerID);
        }

        public Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsByPhoneNumberForAdmin(phoneNumber);
        }

        public Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneOrVehicleNumberForAdmin(string phoneOrVehicleNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsByPhoneOrVehicleNumberForAdmin(phoneOrVehicleNumber);
        }

        #endregion

        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.MobileNuberExistsOrNot(MobileNumber, userType);

        }


        public List<GDictionary> FetchReviews()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchReviews();

        }

        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.AdminLoginCheck(PhoneNumber, Password);
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

        public List<VehicleTypesEntity> GetVehicleTypesForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetVehicleTypesForAdmin();
        }

        public VehicleTypesEntity GetVehicleTypeByIDForAdmin(int vehicleTypeID)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetVehicleTypeByIDForAdmin(vehicleTypeID);
        }

        public List<VehicleFilterEntity> GetDriverDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetDriverDetailsForAdmin(Entity, out TotalPageNumber);
        }

        public List<GDictionary> GetSummaryForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetSummaryForAdmin();
        }

        public DriverEntity GetDriverDetailsByIDForAdmin(int driver)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetDriverDetailsByIDForAdmin(driver);
        }

        public List<PriceMultipleEntity> GetPriceMultiple()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetPriceMultiple();
        }
       public PriceMultipleEntity GetPriceMultipleByIDForAdmin(int intPricePK)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetPriceMultipleByIDForAdmin(intPricePK);
        }
        public List<GDictionary> GetRideStatus()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.GetRideStatus();
        }

    }



}
