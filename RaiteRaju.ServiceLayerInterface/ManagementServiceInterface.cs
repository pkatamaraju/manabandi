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
        int InsertAddPostDetails(AdDetailsEntity obj);

        [OperationContract]
        int UploadImage(AdDetailsEntity obj);

        [OperationContract]
        int InsertAddUserDetails(UserDetailsEntity Obj);

        [OperationContract]
        void UpdateAdDetails(AdDetailsEntity Obj);

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
        int SPInsertAdViewsStatistics(AdDetailsEntity Entity);

        [OperationContract]
        void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage);

        [OperationContract]
        int VerifyUsersByAdmin(string SelectedPhoneNumbers);

        [OperationContract]
        int InsertAdPostByAdmin(AdDetailsEntity Obj);
        [OperationContract]
        int InsertPromotions(string Name, Int64 PhoneNumber, string Description);
    }
         
}
