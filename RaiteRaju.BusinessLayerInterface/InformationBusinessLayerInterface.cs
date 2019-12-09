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
        List<GDictionary> FetDistrictsOfState(int StateId);
        List<GDictionary> FetMandalsOfDistrct(int DistrictId);
        List<GDictionary> GetVehicleTypes();
        UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber);
        UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password);
        List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);
        UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password);
        List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber);

        VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber);

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



        GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType);

        List<GDictionary> FetchReviews();

        UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password);

        List<ContactUsEntity> FetchContactUsDetailsForAdmin();

        List<ReviewEntity> FetchReviewDetailsForAdmin();

        List<ExceptionEntity> FetchExceptionDetailsForAdmin();

        List<VehicleTypesEntity> GetVehicleTypesForAdmin();

        VehicleTypesEntity GetVehicleTypeByIDForAdmin(int vehicleTypeID);

        #endregion
    }

}
