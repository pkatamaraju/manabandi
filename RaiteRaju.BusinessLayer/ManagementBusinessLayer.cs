using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;
using RaiteRaju.DAL;
using RaiteRaju.BusinessLayerInterface;

namespace RaiteRaju.BusinessLayer
{
    public class ManagementBusinessLayer : ManagementBusinessLayerInterface
    {
        public int InsertAddUserDetails(UserDetailsEntity Obj)
        {
            return new DAL.ManagementDAL().InsertAddUserDetails(Obj);
        }
        public UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj)
        {
            DAL.ManagementDAL OBJ = new DAL.ManagementDAL();
            return OBJ.VerifyMobileNumber(Obj);
        }
       
        public int UpdateUserDetails(UserDetailsEntity Obj)
        {
            DAL.ManagementDAL OBJ = new DAL.ManagementDAL();
            return OBJ.UpdateUserDetails(Obj);
        }

        public int UPDATEOTP(UserDetailsEntity Obj)
        {
            DAL.ManagementDAL OBJ = new DAL.ManagementDAL();
            return OBJ.UPDATEOTP(Obj);
        }
        
        public int DeleteUserAccount(Int64 BigIntPhoneNumber)
        {
            return new DAL.ManagementDAL().DeleteUserAccount(BigIntPhoneNumber);
        }
        public int InsertReview(Int64 PhoneNumber, String reviewDescription)
        {

            return new DAL.ManagementDAL().InsertReview(PhoneNumber, reviewDescription);
        }
        public int insertContactUs(ContactUsEntity ENTITY)
        {
            return new DAL.ManagementDAL().insertContactUs(ENTITY);
        }
        public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
        {
            new DAL.ManagementDAL().ExceptionLoggin(ControllerName, ActionName, ErrorMessage);
        }
        public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
        {
            return new DAL.ManagementDAL().InsertPromotions(Name, PhoneNumber, Description);
        }

        #region ManaBandi
        public int BookRide(RideEntity ride)
        {

            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.BookRide(ride);

        }

        public int UpateRideDetailsForAdmin(RideEntity ride)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.UpateRideDetailsForAdmin(ride);
        }
        public int VehicleOwnerRegistration(OwnerEntity owner)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.VehicleOwnerRegistration(owner);
        }
        public string AddVehicle(VehicleEntity entity)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.AddVehicle(entity);
        }


        public string UpdateVehicleDetails(VehicleEntity entity)
        {
            return new DAL.ManagementDAL().UpdateVehicleDetails(entity);

        }

        public void DeleteVehicle(int VehicleID, Int64 PhoneNumber)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            objDAL.DeleteVehicle(VehicleID, PhoneNumber);

        }

       public int UpdateVehicleOwnerDetailsByAdmin(OwnerEntity owner)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
             return objDAL.UpdateVehicleOwnerDetailsByAdmin(owner);
        }

        public string UpdateVehicleTypes(VehicleTypesEntity entity)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.UpdateVehicleTypes(entity);
        }


        public int DriverRegistration(DriverEntity driver)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.DriverRegistration(driver);
        }

        public int UpdateDriverDetailsByAdmin(DriverEntity entity)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.UpdateDriverDetailsByAdmin(entity);
        }

       public string UpdatePriceMultiple(PriceMultipleEntity entity)
        {
            DAL.ManagementDAL objDAL = new DAL.ManagementDAL();
            return objDAL.UpdatePriceMultiple(entity);
        }

        #endregion

    }
}
