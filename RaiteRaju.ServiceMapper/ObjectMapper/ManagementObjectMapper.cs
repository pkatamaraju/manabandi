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
        internal UserDetailsEntity MapUserRegistrationModelToUserRegistrationEntity(UserDetailsModel Model) {

            UserDetailsEntity Entity = new UserDetailsEntity();
            Entity.intUserId = Model.intUserId;
            Entity.KeyForUserSettings = Model.KeyForUserSettings;
            Entity.txtName = Model.txtUserName;
            Entity.BigIntPhoneNumber = Model.txtPhoneNumber;
            Entity.txtMailId = Model.txtMailId;
            Entity.txtState = Model.ddlState;
            Entity.txtDistrict = Model.ddlDistrict;
            Entity.txtMandal = Model.ddlMandal;
            Entity.txtvillage = Model.txtVillage;
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

        #region Manabandi

        internal RideEntity MapRideModelToRideEntity(Ride ride)
        {
            RideEntity rideEntity = new RideEntity();
            rideEntity.intRideID = ride.intRideID;
            rideEntity.Name = ride.Name;
            rideEntity.PhoneNumber = ride.PhoneNumber;
            rideEntity.PickUpLocation = ride.PickUpLocation;
            rideEntity.DropLocation = ride.DropLocation;
            rideEntity.VehicleTypeID = ride.VehicleTypeID;
            rideEntity.OTP = ride.OTP;
            rideEntity.Password = ride.Password;
            rideEntity.dtScheduledDate = ride.dtScheduledDate;
            rideEntity.txtScheduledTime = ride.txtScheduledTime;
            rideEntity.txtVehicleNumber = ride.txtVehicleNumber;
            rideEntity.txtRideStatus = ride.txtRideStatus;
            rideEntity.intRideAmount = ride.intRideAmount;
            rideEntity.intRideCommision = ride.intRideCommision;
            rideEntity.intRideKM = ride.intRideKM;
            rideEntity.RefrerredByPhoneNumber = ride.RefrerredByPhoneNumber;
            return rideEntity;
        }

        internal OwnerEntity MapOwnerModelToEntity(Owner model)
        {
            OwnerEntity Entity = new OwnerEntity();
            Entity.intOwnerID = model.intOwnerID;
            Entity.txtOwnerName = model.txtOwnerName;
            Entity.BigIntPhoneNumber = model.BigIntPhoneNumber;
            Entity.txtPassword = model.txtPassword;
            Entity.intStateId = model.intStateId;
            Entity.intDistrictId = model.intDistrictId;
            Entity.intManadalID = model.intManadalID;
            Entity.txtPlace = model.txtPlace;
            Entity.OTP = model.OTP;
            return Entity;

        }

        internal VehicleEntity MapVehicleModelToEntity(Vehicle model) {
            VehicleEntity entity = new VehicleEntity();
            entity.intVehicleTypeID = model.intVehicleTypeID;
            entity.txtVehicleName = model.txtVehicleName;
            entity.BigIntPhoneNumber = model.BigIntPhoneNumber;
            entity.txtVehicleNumber = model.txtVehicleNumber;
            entity.txtVehicleType = model.txtVehicleType;
            entity.intVehicleID = model.intVehicleID;
            entity.dtCreated = model.dtCreated;
            return entity;
        }
        
        internal VehicleTypesEntity MapVehicleTypeModelToEntity(VehicleTypesModel model)
        {
            VehicleTypesEntity Entity = null;

            if (model != null)
            {
                Entity = new VehicleTypesEntity();
                Entity.intVehicleTypeId = model.intVehicleTypeId;
                Entity.txtVehicleType = model.txtVehicleType;
                Entity.intMileage = model.intMileage;
                Entity.intAverageFuelPrice = model.intAverageFuelPrice;
                Entity.intDriverSalary = model.intDriverSalary;
                Entity.intAvgTollPrice = model.intAvgTollPrice;
                Entity.intAverageSpeed = model.intAverageSpeed;
                Entity.intAvgWorkingHours = model.intAvgWorkingHours;
                Entity.intFuelCostPerKM = model.intDriverCostPerKM;
                Entity.intDriverCostPerKM = model.intDriverCostPerKM;
                Entity.intTotalCostPerKM = model.intTotalCostPerKM;
                Entity.BaseFare = model.BaseFare;
            }
            return Entity;
        }

        internal DriverEntity MapDriverModelToEntity(DriverModel model)
        {
            DriverEntity Entity = new DriverEntity();
            Entity.intDriverID = model.intDriverID;
            Entity.txtDriverName = model.txtDriverName;
            Entity.BigIntPhoneNumber = model.BigIntPhoneNumber;
            Entity.txtPassword = model.txtPassword;
            Entity.intStateId = model.intStateId;
            Entity.intDistrictId = model.intDistrictId;
            Entity.intManadalID = model.intManadalID;
            Entity.txtPlace = model.txtPlace;
            Entity.OTP = model.OTP;
            return Entity;

        }

        internal PriceMultipleEntity MapPriceMultipleModelToEntity(PriceMultipleModel model)
        {
            PriceMultipleEntity entity = new PriceMultipleEntity();
            if (model != null)
            {
                entity.intVehicleTypeID = model.intVehicleTypeID;
                entity.intPriceMultiple = model.intPriceMultiple;
                entity.intKMRange = model.intKMRange;
                entity.IntPricePK = model.IntPricePK;
                entity.intPricePerKM = model.intPricePerKM;
            }
            return entity;

        }

        #endregion

    }
}
