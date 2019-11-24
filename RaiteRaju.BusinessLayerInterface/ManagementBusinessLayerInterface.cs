using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;

namespace RaiteRaju.BusinessLayerInterface
{
   public interface ManagementBusinessLayerInterface
    {
       int InsertAddUserDetails(UserDetailsEntity Obj);
       UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj);
       void DeleteUserAd(int AdId);
       int UpdateUserDetails(UserDetailsEntity Obj);
       int UPDATEOTP(UserDetailsEntity Obj);
       int VerifySelectedAds(string AdsToVerify);
       int DeleteUserAccount(Int64 BigIntPhoneNumber);
       int InsertReview(Int64 PhoneNumber, String reviewDescription);
       int insertContactUs(ContactUsEntity ENTITY);
       int DeleteSelectedUserAccounts(string SelectedUserIds);
       int DeleteAdsByAdmin(string SelectedAds);
      void ExceptionLoggin(string ControllerName,string ActionName,string ErrorMessage);
      int VerifyUsersByAdmin(string SelectedPhoneNumbers);
      int InsertPromotions(string Name, Int64 PhoneNumber, string Description);

        #region ManaBandi
        int BookRide(RideEntity ride);
        int UpateRideDetailsForAdmin(RideEntity ride);
        int VehicleOwnerRegistration(OwnerEntity owner);

        string AddVehicle(VehicleEntity entity);

        #endregion


         string UpdateVehicleDetails(VehicleEntity entity);

         void DeleteVehicle(int VehicleID, Int64 PhoneNumber);
        int UpdateVehicleOwnerDetailsByAdmin(OwnerEntity owner);

    }
}
