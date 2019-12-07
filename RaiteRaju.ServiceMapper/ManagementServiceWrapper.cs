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
        public int InsertAddUserDetails(UserDetailsModel obj)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            Entity = objMapper.MapUserRegistrationModelToUserRegistrationEntity(obj);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.InsertAddUserDetails(Entity);

        }

        public UserDetailsModel VerifyMobileNumber(int otp, Int64 MobileNumber)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            UserDetailsEntity Entity = new UserDetailsEntity();
            UserDetailsModel Model = new UserDetailsModel();
            Entity.BigIntPhoneNumber = MobileNumber;
            Entity.OTP = otp.ToString();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            Entity = ManObj.VerifyMobileNumber(Entity);
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

        public int DeleteUserAccount(Int64 BigIntPhoneNumber)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.DeleteUserAccount(BigIntPhoneNumber);
        }

        public int insertContactUs(ContactUsModel Model)
        {
            ContactUsEntity ENTITY = new ContactUsEntity();
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            ENTITY = objMapper.MapContactUsModelToContactUsEntity(Model);
            return ManObj.insertContactUs(ENTITY);
        }

        public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
        {
            ServiceLayer.ManagementService ManObj = new ManagementService();
            ManObj.ExceptionLoggin(ControllerName, ActionName, ErrorMessage);
        }

        public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
        {
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.InsertPromotions(Name, PhoneNumber, Description);
        }

        public int InsertReview(Int64 BigIntPhoneNumber, string ReviewDes)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.InsertReview(BigIntPhoneNumber, ReviewDes);
        }
       
        #region ManaBandi
        public int BookNow(Ride ride) {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            RideEntity Entity = new RideEntity();
            Entity = objMapper.MapRideModelToRideEntity(ride);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.BookRide(Entity);
        }

        public int UpateRideDetailsForAdmin(Ride ride)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            RideEntity Entity = new RideEntity();
            Entity = objMapper.MapRideModelToRideEntity(ride);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UpateRideDetailsForAdmin(Entity);
        }

        public int VehicleOwnerRegistration(Owner owner)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            OwnerEntity Entity = new OwnerEntity();
            Entity = objMapper.MapOwnerModelToEntity(owner);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.VehicleOwnerRegistration(Entity);
        }

        public string AddVehicle(Vehicle model)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            VehicleEntity Entity = new VehicleEntity();
            Entity = objMapper.MapVehicleModelToEntity(model);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.AddVehicle(Entity);
        }

        public void DeleteVehicle(int VehicleID, Int64 PhoneNumber)
        {
            ServiceLayer.ManagementService ManObj = new ManagementService();
             ManObj.DeleteVehicle(VehicleID,PhoneNumber);
        }

        public string UpdateVehicleDetails(Vehicle model)
        {
            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            VehicleEntity Entity = new VehicleEntity();
            Entity = objMapper.MapVehicleModelToEntity(model);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UpdateVehicleDetails(Entity);
        }
       
        public int UpdateVehicleOwnerDetailsByAdmin(Owner owner)
        {

            ManagementObjectMapper objMapper = new ManagementObjectMapper();
            OwnerEntity Entity = new OwnerEntity();
            Entity = objMapper.MapOwnerModelToEntity(owner);

            ServiceLayer.ManagementService ManObj = new ManagementService();
            return ManObj.UpdateVehicleOwnerDetailsByAdmin(Entity);
        }
       
        #endregion
    }
}
