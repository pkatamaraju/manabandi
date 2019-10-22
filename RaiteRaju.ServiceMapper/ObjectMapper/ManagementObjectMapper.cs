using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;
using RaiteRaju.Web.Models;

namespace RaiteRaju.ServiceMapper.ObjectMapper
{
   public class ManagementObjectMapper
    {
        internal AdDetailsEntity MapAddPostModelToAddPostEntity(AdDetailsModel Model)
        {
            AdDetailsEntity Entity = new AdDetailsEntity();
            Entity.AdID = Model.AdID;
            Entity.Title = Model.txtAddTitle;
            Entity.Category = Model.Category;
            Entity.intCategoryId = Model.intCategoryId;
            Entity.txtSubCategoryName = Model.txtSubCategoryName;
            Entity.AdDescription = Model.txtAdDescription;
            Entity.Price = Model.txtPrice;
            Entity.Quantity = Model.txtQuantity;
            Entity.UserID = Model.UserID;
            Entity.SellingUnit = Model.SellingUnit;
            Entity.MobileNumber = Model.MobileNuber;
            Entity.Image = Model.Image;
            return Entity;
        }
     internal UserDetailsEntity MapUserRegistrationModelToUserRegistrationEntity(UserDetailsModel Model){

         UserDetailsEntity Entity=new UserDetailsEntity();
         Entity.intUserId = Model.intUserId;
         Entity.KeyForUserSettings = Model.KeyForUserSettings;
         Entity.txtName=Model.txtUserName;
         Entity.BigIntPhoneNumber=Model.txtPhoneNumber;
         Entity.txtMailId=Model.txtMailId;
         Entity.txtState=Model.ddlState;
         Entity.txtDistrict=Model.ddlDistrict;
         Entity.txtMandal=Model.ddlMandal;
         Entity.txtvillage=Model.txtVillage;
         Entity.txtPassword = Model.txtPassword;
         Random r = new Random();
         string OTP = r.Next(100000, 999999).ToString();
         Entity.OTP = OTP;
       

         return Entity;
     }
     internal ContactUsEntity MapContactUsModelToContactUsEntity(ContactUsModel Model)
     {
         ContactUsEntity Entity = new ContactUsEntity();

         if (Model != null)
         {
             Entity.PhoneNumber = Model.PhoneNumber;
             Entity.Subject = Model.Subject;
             Entity.Description = Model.Description;
         }
         return Entity;
     }
     internal UserDetailsModel MapUserDetailsModelToEntity(UserDetailsEntity Entity)
     {
         UserDetailsModel UserObj = new UserDetailsModel();
         if (Entity != null)
         {
             UserObj.txtUserName = Entity.txtName;
             UserObj.intUserId = Entity.intUserId;
             UserObj.txtPassword = Entity.txtPassword;
             UserObj.txtPhoneNumber = Entity.BigIntPhoneNumber;
             UserObj.ddlState = Entity.txtState;
             UserObj.ddlDistrict = Entity.txtDistrict;
             UserObj.ddlMandal = Entity.txtMandal;
             UserObj.txtVillage = Entity.txtvillage;
             UserObj.txtMailId = Entity.txtMailId;
         }
         return UserObj;

     }
    }
}
