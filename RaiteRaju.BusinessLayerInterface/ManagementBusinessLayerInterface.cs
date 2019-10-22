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
       int InsertAddPostDetails(AdDetailsEntity Obj);
       int UploadImage(AdDetailsEntity Obj);
       int InsertAddUserDetails(UserDetailsEntity Obj);
       void UpdateAdDetails(AdDetailsEntity Obj);
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
       int SPInsertAdViewsStatistics(AdDetailsEntity Entity);
      void ExceptionLoggin(string ControllerName,string ActionName,string ErrorMessage);
      int VerifyUsersByAdmin(string SelectedPhoneNumbers);
      int InsertAdPostByAdmin(AdDetailsEntity Obj);
      int InsertPromotions(string Name, Int64 PhoneNumber, string Description);
           
    }
}
