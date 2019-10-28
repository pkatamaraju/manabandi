using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RaiteRaju.ServiceLayer;
using RaiteRaju.ServiceLayerInterface;
using RaiteRaju.Web.Models;
using RaiteRaju.ServiceMapper.ObjectMapper;
using RaiteRaju.Entities;

namespace RaiteRaju.ServiceMapper
{
   public class ManagementServiceWrapper
    {
        public int InsertAddPostDetails(AdDetailsModel obj)
        {
           
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            AdDetailsEntity Entity = new AdDetailsEntity();
            Entity = objMapper.MapAddPostModelToAddPostEntity(obj);

            ServiceLayer.ManagementService ManObj = new ManagementService();
           return ManObj.InsertAddPostDetails(Entity);

          }

        public int UploadImage(AdDetailsModel obj)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            AdDetailsEntity Entity = new AdDetailsEntity();
            Entity = objMapper.MapAddPostModelToAddPostEntity(obj);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UploadImage(Entity);

        }
        public int InsertAddUserDetails(UserDetailsModel obj)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            Entity = objMapper.MapUserRegistrationModelToUserRegistrationEntity(obj);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.InsertAddUserDetails(Entity);

        }
        public void UpdateAdDetails(AdDetailsModel Obj)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            AdDetailsEntity Entity = new AdDetailsEntity();
           Entity= objMapper.MapAddPostModelToAddPostEntity(Obj);
            ServiceLayer.ManagementService ManObj = new ManagementService();
            ManObj.UpdateAdDetails(Entity);
        }
        public void DeleteUserAd(int AdId)
        {
            ServiceLayer.ManagementService ManObj = new ManagementService();
            ManObj.DeleteUserAd(AdId);
        }
        public UserDetailsModel VerifyMobileNumber(int otp, Int64 MobileNumber)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            UserDetailsModel Model=new UserDetailsModel();
            Entity.BigIntPhoneNumber = MobileNumber;
            Entity.OTP = otp.ToString();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            Entity= ManObj.VerifyMobileNumber(Entity);
            Model = objMapper.MapUserDetailsModelToEntity(Entity);
            return Model;
        }
        public int UpdateUserDetails(UserDetailsModel Obj)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            Entity = objMapper.MapUserRegistrationModelToUserRegistrationEntity(Obj);
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UpdateUserDetails(Entity);
        }
        public int UpdateOtp(UserDetailsModel Obj)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            Entity = objMapper.MapUserRegistrationModelToUserRegistrationEntity(Obj);
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UPDATEOTP(Entity);

        }
        public int VerifySelectedAds(string SelectedAds)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.VerifySelectedAds(SelectedAds);
        }
        public int DeleteUserAccount(Int64 BigIntPhoneNumber)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.DeleteUserAccount(BigIntPhoneNumber);
        }
        public int InsertReview(Int64 BigIntPhoneNumber,string ReviewDes)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.InsertReview(BigIntPhoneNumber,ReviewDes);
        }
        public int insertContactUs(ContactUsModel Model)
        {
            ContactUsEntity ENTITY = new ContactUsEntity();
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            ENTITY = objMapper.MapContactUsModelToContactUsEntity(Model);
            return ManObj.insertContactUs(ENTITY);
        }
        public int DeleteSelectedUserAccounts(string SelectedUserIds)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.DeleteSelectedUserAccounts(SelectedUserIds);
        }
       public int DeleteAdsByAdmin(string SelectedAds) {
           ManagementObjectMapper objMapper = new ManagementObjectMapper();
           ServiceLayer.ManagementService ManObj = new ManagementService();
           return ManObj.DeleteAdsByAdmin(SelectedAds);
       }
       public int SPInsertAdViewsStatistics(AdDetailsModel Model)
       {
           AdDetailsModel ModelObj = new AdDetailsModel();
           ManagementObjectMapper objMapper = new ManagementObjectMapper();
           ServiceLayer.ManagementService ManObj = new ManagementService();
           return ManObj.SPInsertAdViewsStatistics(objMapper.MapAddPostModelToAddPostEntity(Model));
       }
       public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
       {
           ServiceLayer.ManagementService ManObj = new ManagementService();
           ManObj.ExceptionLoggin(ControllerName,ActionName,ErrorMessage);
       }
       public int VerifyUsersByAdmin(string SelectedPhoneNumbers)
       {
           ManagementObjectMapper objMapper = new ManagementObjectMapper();
           ServiceLayer.ManagementService ManObj = new ManagementService();
           return ManObj.VerifyUsersByAdmin(SelectedPhoneNumbers);
       }
       public int InsertAdPostByAdmin(AdDetailsModel ModelObj)
       {
           ManagementObjectMapper objMapper = new ManagementObjectMapper();
           AdDetailsEntity Entity = new AdDetailsEntity();
           Entity = objMapper.MapAddPostModelToAddPostEntity(ModelObj);

           ServiceLayer.ManagementService ManObj = new ManagementService();
           return ManObj.InsertAdPostByAdmin(Entity);
       }
       public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
       {
           ServiceLayer.ManagementService ManObj = new ManagementService();
          return ManObj.InsertPromotions(Name, PhoneNumber, Description);
       }
    }
}
