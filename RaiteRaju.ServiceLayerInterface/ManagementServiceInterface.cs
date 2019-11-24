using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaiteRaju.ServiceLayerInterface
{
    [ServiceContract]
    public interface ManagementServiceInterface
    {
        
        [OperationContract]
        int InsertAddUserDetails(UserDetailsEntity Obj);

        
        [OperationContract]
        UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj);

        [OperationContract]
        void DeleteUserAd(int AdId);

        [OperationContract]
        int UpdateUserDetails(UserDetailsEntity Obj);

        [OperationContract]
        int UPDATEOTP(UserDetailsEntity Obj);

        [OperationContract]
        int VerifySelectedAds(string SelectedsAds);

        [OperationContract]
        int DeleteUserAccount(Int64 BigIntPhoneNumber);

        [OperationContract]
        int InsertReview(Int64 PhoneNumber, String reviewDescription);

        [OperationContract]
        int insertContactUs(ContactUsEntity ENTITY);

        [OperationContract]
        int DeleteSelectedUserAccounts(string SelectedUserIds);

        [OperationContract]
        int DeleteAdsByAdmin(string SelectedAds);

        [OperationContract]
        void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage);

        [OperationContract]
        int VerifyUsersByAdmin(string SelectedPhoneNumbers);

        [OperationContract]
        int InsertPromotions(string Name, Int64 PhoneNumber, string Description);

        [OperationContract]
        int BookRide(RideEntity ride);

        [OperationContract]
        int UpateRideDetailsForAdmin(RideEntity ride);

        [OperationContract]
        int VehicleOwnerRegistration(OwnerEntity owner);

        [OperationContract]
        string AddVehicle(VehicleEntity entity);

        [OperationContract]
        void DeleteVehicle(int VehicleID, Int64 PhoneNumber);

        [OperationContract]
        string UpdateVehicleDetails(VehicleEntity entity);

        [OperationContract]
        int UpdateVehicleOwnerDetailsByAdmin(OwnerEntity owner);
    }
         
}
