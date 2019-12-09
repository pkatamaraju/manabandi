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
        VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber);

        [OperationContract]
        List<RideEntity> GetAssignedRideDetails(Int64 phoneNumber, int intPageNumber, out int TotalPageNumber);

        #endregion

        #region manabandi admin
        List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);

        List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber);

        List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber);

        PriceEntity GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType);

        RideEntity GetRideDetailsByID(int rideID);

        OwnerEntity GetOwnerDetailsByIDForAdmin(int ownerID);

        Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber);




        [OperationContract]
        GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType);


        [OperationContract]
        List<GDictionary> FetchReviews();

        [OperationContract]
        UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password);

        [OperationContract]
        List<ContactUsEntity> FetchContactUsDetailsForAdmin();

        [OperationContract]
        List<ReviewEntity> FetchReviewDetailsForAdmin();

        [OperationContract]
        List<ExceptionEntity> FetchExceptionDetailsForAdmin();

        [OperationContract]
        List<VehicleTypesEntity> GetVehicleTypesForAdmin();

        [OperationContract]
        VehicleTypesEntity GetVehicleTypeByIDForAdmin(int vehicleTypeID);
        #endregion
    }

}
