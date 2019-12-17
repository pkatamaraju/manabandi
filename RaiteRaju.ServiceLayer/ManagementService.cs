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
        public int InsertAddUserDetails(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertAddUserDetails(Obj);
        }
        public UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.VerifyMobileNumber(Obj);
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
        public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            ManageObj.ExceptionLoggin(ControllerName, ActionName, ErrorMessage);
        }
        public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.InsertPromotions(Name, PhoneNumber, Description);
        }

        #region ManaBandi

        public int BookRide(RideEntity ride)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.BookRide(ride);
        }
        public int UpateRideDetailsForAdmin(RideEntity ride)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpateRideDetailsForAdmin(ride);
        }
        public int VehicleOwnerRegistration(OwnerEntity owner)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.VehicleOwnerRegistration(owner);
        }
        public string AddVehicle(VehicleEntity entity)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.AddVehicle(entity);
        }
        public void DeleteVehicle(int VehicleID, Int64 PhoneNumber)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            ManageObj.DeleteVehicle(VehicleID, PhoneNumber);
        }
        public string UpdateVehicleDetails(VehicleEntity entity)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpdateVehicleDetails(entity);
        }
        
        public int UpdateVehicleOwnerDetailsByAdmin(OwnerEntity owner)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpdateVehicleOwnerDetailsByAdmin(owner);
        }

        public string UpdateVehicleTypes(VehicleTypesEntity entity)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpdateVehicleTypes(entity);
        }

      public int DriverRegistration(DriverEntity driver)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.DriverRegistration(driver);
        }

       public int UpdateDriverDetailsByAdmin(DriverEntity entity)
        {
            ManagementBusinessLayerInterface ManageObj = new BusinessLayer.ManagementBusinessLayer();
            return ManageObj.UpdateDriverDetailsByAdmin(entity);
        }
        #endregion
    }
}
