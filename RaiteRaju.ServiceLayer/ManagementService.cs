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
    public class ManagementService : ManagementServiceInterface
    {
        public int InsertAddPostDetails(AdDetailsEntity obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertAddPostDetails(obj);

        }

        public int UploadImage(AdDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UploadImage(Obj);
        }
        public int InsertAddUserDetails(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertAddUserDetails(Obj);
        }
        public void UpdateAdDetails(AdDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            ManageObj.UpdateAdDetails(Obj);

        }
        public UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.VerifyMobileNumber(Obj);
        }
        public void DeleteUserAd(int AdId)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            ManageObj.DeleteUserAd(AdId);
        }
        public int UpdateUserDetails(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpdateUserDetails(Obj);
        }
        public int UPDATEOTP(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UPDATEOTP(Obj);
        }
        public int VerifySelectedAds(string adsToVerify)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.VerifySelectedAds(adsToVerify);
        }
        public int DeleteUserAccount(Int64 BigIntPhoneNumber)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.DeleteUserAccount(BigIntPhoneNumber);
        }
        public int InsertReview(Int64 PhoneNumber, String reviewDescription)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertReview(PhoneNumber, reviewDescription);
        }
        public int insertContactUs(ContactUsEntity ENTITY)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.insertContactUs(ENTITY);
        }
        public int DeleteSelectedUserAccounts(string SelectedUserIds)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.DeleteSelectedUserAccounts(SelectedUserIds);
        }
        public int DeleteAdsByAdmin(string SelectedAds){
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.DeleteAdsByAdmin(SelectedAds);
        }
        public int SPInsertAdViewsStatistics(AdDetailsEntity Entity)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.SPInsertAdViewsStatistics(Entity);
        }
        public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            ManageObj.ExceptionLoggin(ControllerName,ActionName,ErrorMessage);
        }
        public int VerifyUsersByAdmin(string SelectedPhoneNumbers)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.VerifyUsersByAdmin(SelectedPhoneNumbers);
        }
        public int InsertAdPostByAdmin(AdDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertAdPostByAdmin(Obj);
        }
        public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertPromotions(Name,PhoneNumber,Description);
        }
    }
}
