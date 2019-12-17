using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.Entities;
using RaiteRaju.Web.Models;

namespace RaiteRaju.ServiceMapper.ObjectMapper
{
    public class InformationObjectMapper
    {
        internal UserDetailsModel MapDetailsEntityToDetailsModel(UserDetailsEntity Entity)
        {


            UserDetailsModel UserObj = new UserDetailsModel();
            if (Entity != null)
            {
                UserObj.txtUserName = Entity.txtName;
                UserObj.intUserId = Entity.intUserId;
                UserObj.txtPhoneNumber = Entity.BigIntPhoneNumber;
                UserObj.ddlState = Entity.txtState;
                UserObj.ddlDistrict = Entity.txtDistrict;
                UserObj.ddlMandal = Entity.txtMandal;
                UserObj.txtVillage = Entity.txtvillage;
                UserObj.txtMailId = Entity.txtMailId;
                UserObj.UserType = Entity.UserType;

                return UserObj;
            }
            else
            {
                return null;
            }

        }

        internal GDictionaryModel MapGDictionaryEntityToModel(GDictionary Entity)
        {
            GDictionaryModel obj = new GDictionaryModel();

            if (Entity != null)
            {
                obj.ID = Entity.ID;
                obj.Name = Entity.Name;
                obj.value = Entity.value;
                obj.Type = Entity.Type;

            }
            return obj;
        }

        internal List<GDictionaryModel> MapGDictionaryEntityListToModelList(List<GDictionary> EntityList)
        {
            GDictionaryModel obj;
            List<GDictionaryModel> ModelList = new List<GDictionaryModel>();
            if (EntityList != null)
            {
                foreach (GDictionary Entity in EntityList)
                {
                    obj = new GDictionaryModel();
                    obj.ID = Entity.ID;
                    obj.Name = Entity.Name;
                    obj.value = Entity.value;
                    obj.Type = Entity.Type;
                    ModelList.Add(obj);
                }
            }
            return ModelList;
        }

        internal UserDetailsModel MapUserDetailsModelToEntity(UserDetailsEntity Entity)
        {
            UserDetailsModel UserObj = new UserDetailsModel();
            if (Entity != null)
            {
                UserObj.txtUserName = Entity.txtName;
                UserObj.intUserId = Entity.intUserId;
                UserObj.txtPhoneNumber = Entity.BigIntPhoneNumber;
                UserObj.ddlState = Entity.txtState;
                UserObj.ddlDistrict = Entity.txtDistrict;
                UserObj.ddlMandal = Entity.txtMandal;
                UserObj.txtVillage = Entity.txtvillage;
                UserObj.txtMailId = Entity.txtMailId;
            }
            return UserObj;

        }

        internal List<UserDetailsModel> MapUserDetailsModelListToEntityList(List<UserDetailsEntity> EntityList)
        {
            UserDetailsModel UserObj;
            List<UserDetailsModel> ModelList = new List<UserDetailsModel>();
            if (EntityList != null)
            {
                foreach (UserDetailsEntity item in EntityList)
                {
                    UserObj = new UserDetailsModel();
                    UserObj.txtUserName = item.txtName;
                    UserObj.intUserId = item.intUserId;
                    UserObj.txtPhoneNumber = item.BigIntPhoneNumber;
                    UserObj.ddlState = item.txtState;
                    UserObj.ddlDistrict = item.txtDistrict;
                    UserObj.ddlMandal = item.txtMandal;
                    UserObj.txtVillage = item.txtvillage;
                    UserObj.txtMailId = item.txtMailId;
                    UserObj.bitVerifiedPhoneNumber = item.bitVerifiedPhoneNumber;
                    UserObj.FlgAccountDeleted = item.FlgAccountDeleted;
                    UserObj.UserType = item.UserType;
                    ModelList.Add(UserObj);
                }
            }
            return ModelList;

        }

        internal List<ReviewModel> MapReviewEntityToModel(List<ReviewEntity> EntityList)
        {
            ReviewModel Model = new ReviewModel();
            List<ReviewModel> lIST = new List<ReviewModel>();
            if (EntityList != null)
            {
                foreach (ReviewEntity Entity in EntityList)
                {
                    Model = new ReviewModel();
                    Model.DtInserted = Entity.DtInserted;
                    Model.FlgReviewVerified = Entity.FlgReviewVerified;
                    Model.PhoneNumber = Entity.PhoneNumber;
                    Model.Review = Entity.Review;
                    lIST.Add(Model);
                }
                return lIST;
            }
            else
            {
                return null;
            }
        }

        internal List<ContactUsModel> MapContactUsEntityToModel(List<ContactUsEntity> EntityList)
        {
            ContactUsModel Model;
            List<ContactUsModel> List = new List<ContactUsModel>();
            if (EntityList != null)
            {

                foreach (ContactUsEntity Entity in EntityList)
                {
                    Model = new ContactUsModel();
                    Model.dtInserted = Entity.DtInserted;
                    Model.Subject = Entity.Subject;
                    Model.PhoneNumber = Entity.PhoneNumber;
                    Model.Description = Entity.Description;
                    List.Add(Model);
                }
                return List;
            }

            else
            {
                return null;
            }
        }

        internal List<ExceptionModel> MapExceptionEntityToModel(List<ExceptionEntity> EntityList)
        {
            ExceptionModel Model;
            List<ExceptionModel> ModelList = new List<ExceptionModel>();
            if (EntityList != null)
            {
                foreach (ExceptionEntity Entity in EntityList)
                {
                    Model = new ExceptionModel();
                    Model.dtLoggedDate = Entity.dtLoggedDate;
                    Model.txtActionName = Entity.txtActionName;
                    Model.txtControllerName = Entity.txtControllerName;
                    Model.txtExceptionMessage = Entity.txtExceptionMessage;
                    ModelList.Add(Model);
                }
                return ModelList;
            }
            else
            {
                return null;
            }
        }

        #region ManaBandi

        internal List<Ride> MapRideEntityListToModel(List<RideEntity> ListEntity)
        {

            Ride rideObj = new Ride();
            List<Ride> rideListObj = new List<Ride>();
            if (ListEntity != null)
            {
                foreach (RideEntity item in ListEntity)
                {
                    rideObj = new Ride();
                    rideObj.Name = item.Name;
                    rideObj.PhoneNumber = item.PhoneNumber;
                    rideObj.DtCreated = item.DtCreated;
                    rideObj.PickUpLocation = item.PickUpLocation;
                    rideObj.DropLocation = item.DropLocation;
                    rideObj.VehicleTypeID = item.VehicleTypeID;
                    rideObj.dtScheduledDate = item.dtScheduledDate;
                    rideObj.txtScheduledTime = item.txtScheduledTime;
                    rideObj.VehicleType = item.VehicleType;
                    rideObj.intRideID = item.intRideID;
                    rideObj.txtRideStatus = item.txtRideStatus;
                    rideObj.txtVehicleNumber = item.txtVehicleNumber;
                    rideObj.intRideAmount = item.intRideAmount;
                    rideObj.intRideCommision = item.intRideCommision;
                    rideObj.intRideKM = item.intRideKM;

                    rideListObj.Add(rideObj);
                }

                return rideListObj;
            }
            else
            {
                return null;
            }
        }

        internal Ride MapRideEntityToModel(RideEntity entity)
        {
            Ride rideObj = null;
            if (entity != null)
            {
                rideObj = new Ride();
                rideObj.Name = entity.Name;
                rideObj.PhoneNumber = entity.PhoneNumber;
                rideObj.DtCreated = entity.DtCreated;
                rideObj.PickUpLocation = entity.PickUpLocation;
                rideObj.DropLocation = entity.DropLocation;
                rideObj.VehicleTypeID = entity.VehicleTypeID;
                rideObj.dtScheduledDate = entity.dtScheduledDate;
                rideObj.txtScheduledTime = entity.txtScheduledTime;
                rideObj.VehicleType = entity.VehicleType;
                rideObj.intRideID = entity.intRideID;
                rideObj.txtRideStatus = entity.txtRideStatus;
                rideObj.txtVehicleNumber = entity.txtVehicleNumber;
                rideObj.intRideAmount = entity.intRideAmount;
                rideObj.intRideCommision = entity.intRideCommision;
                rideObj.intRideKM = entity.intRideKM;
            }
            return rideObj;
        }

        internal List<Vehicle> MapVehicleEntityListToModel(List<VehicleEntity> ListEntity)
        {

            Vehicle model = new Vehicle();
            List<Vehicle> ListObj = new List<Vehicle>();
            if (ListEntity != null)
            {
                foreach (VehicleEntity entity in ListEntity)
                {
                    model = new Vehicle();
                    model.intVehicleTypeID = entity.intVehicleTypeID;
                    model.txtVehicleName = entity.txtVehicleName;
                    model.BigIntPhoneNumber = entity.BigIntPhoneNumber;
                    model.txtVehicleNumber = entity.txtVehicleNumber;
                    model.txtVehicleType = entity.txtVehicleType;
                    model.intVehicleID = entity.intVehicleID;
                    model.dtCreated = entity.dtCreated;
                    ListObj.Add(model);
                }

                return ListObj;
            }
            else
            {
                return null;
            }
        }

        internal Vehicle MapVehicleModelToEntity(VehicleEntity entity)
        {
            Vehicle model = new Vehicle();
            model.intVehicleTypeID = entity.intVehicleTypeID;
            model.txtVehicleName = entity.txtVehicleName;
            model.BigIntPhoneNumber = entity.BigIntPhoneNumber;
            model.txtVehicleNumber = entity.txtVehicleNumber;
            model.txtVehicleType = entity.txtVehicleType;
            model.intVehicleID = entity.intVehicleID;
            model.dtCreated = entity.dtCreated;
            return model;
        }

        #endregion

        #region ManaBandi Admin

        internal List<VehicleFilterModel> MapVehicleFilterEntityToModelList(List<VehicleFilterEntity> EntityList)
        {
            List<VehicleFilterModel> lisObj = new List<VehicleFilterModel>();
            if (EntityList != null)
            {
                VehicleFilterModel model = null;


                foreach (VehicleFilterEntity entity in EntityList)
                {

                    model = new VehicleFilterModel
                    {
                        VehicleID = entity.VehicleID,
                        VehicleType = entity.VehicleType,
                        VehicleModel = entity.VehicleModel,
                        OwnerName = entity.OwnerName,
                        VehicleNumber = entity.VehicleNumber,
                        Place = entity.Place,
                        intStateId = entity.intStateId,
                        intDistrictId = entity.intDistrictId,
                        intManadalID = entity.intManadalID,
                        BigIntPhoneNumber = entity.BigIntPhoneNumber,
                        TxtKeyWord = entity.TxtKeyWord,
                        IntPageNumber = entity.IntPageNumber,
                        IntPageSize = entity.IntPageSize,
                        SortValue = entity.SortValue,
                        intStateName = entity.intStateName,
                        intDistrictName = entity.intDistrictName,
                        intManadalName = entity.intManadalName,
                        VehicleTypeID = entity.VehicleTypeID,
                        flgOnRide = entity.flgOnRide,
                        intRideStatusID = entity.intRideStatusID,
                        intOwnerID = entity.intOwnerID,
                        FlgAccountDeleted = entity.FlgAccountDeleted,
                        intRideAmount = entity.intRideAmount,
                        intRideCommision = entity.intRideCommision,
                        intRideKM = entity.intRideKM

                    };
                    lisObj.Add(model);
                }
            }

            return lisObj;
        }

        internal VehicleFilterEntity MapVehicleFilterModelToEntity(VehicleFilterModel model)
        {
            VehicleFilterEntity entity = new VehicleFilterEntity();
            if (model != null)
            {
                entity.VehicleID = model.VehicleID;
                entity.VehicleType = model.VehicleType;
                entity.VehicleModel = model.VehicleModel;
                entity.OwnerName = model.OwnerName;
                entity.VehicleNumber = model.VehicleNumber;
                entity.Place = model.Place;
                entity.intStateId = model.intStateId;
                entity.intDistrictId = model.intDistrictId;
                entity.intManadalID = model.intManadalID;
                entity.BigIntPhoneNumber = model.BigIntPhoneNumber;
                entity.TxtKeyWord = model.TxtKeyWord;
                entity.IntPageNumber = model.IntPageNumber;
                entity.IntPageSize = model.IntPageSize;
                entity.SortValue = model.SortValue;
                entity.intStateName = model.intStateName;
                entity.intDistrictName = model.intDistrictName;
                entity.intManadalName = model.intManadalName;
                entity.VehicleTypeID = model.VehicleTypeID;
                entity.flgOnRide = model.flgOnRide;
                entity.intRideStatusID = model.intRideStatusID;
                entity.intOwnerID = model.intOwnerID;
                entity.FlgAccountDeleted = model.FlgAccountDeleted;
                entity.intRideAmount = model.intRideAmount;
                entity.intRideCommision= model.intRideCommision;
                entity.intRideKM= model.intRideKM;

            }

            return entity;
        }

        internal Owner MapOwnerEntityToModel(OwnerEntity Entity)
        {
            Owner model = new Owner();

            if (Entity!=null)
            {
                model.txtOwnerName = Entity.txtOwnerName;
                model.intOwnerID = Entity.intOwnerID;
                model.BigIntPhoneNumber = Entity.BigIntPhoneNumber;
                model.intStateId = Entity.intStateId;
                model.intDistrictId = Entity.intDistrictId;
                model.intManadalID = Entity.intManadalID;
                model.txtPlace = Entity.txtPlace;

            }
            return model;
        }

        internal Tuple<VehicleFilterModel, List<VehicleFilterModel>> MapOwnerTuple(Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> tuple)
        {
            VehicleFilterModel model=null;
            List<VehicleFilterModel> list = new List<VehicleFilterModel>();
            VehicleFilterModel vehOjb;

            if (tuple!=null)
            {
                model = new VehicleFilterModel
                {
                    VehicleID = tuple.Item1.VehicleID,
                    VehicleType = tuple.Item1.VehicleType,
                    VehicleModel = tuple.Item1.VehicleModel,
                    OwnerName = tuple.Item1.OwnerName,
                    VehicleNumber = tuple.Item1.VehicleNumber,
                    Place = tuple.Item1.Place,
                    intStateId = tuple.Item1.intStateId,
                    intDistrictId = tuple.Item1.intDistrictId,
                    intManadalID = tuple.Item1.intManadalID,
                    BigIntPhoneNumber = tuple.Item1.BigIntPhoneNumber,
                    TxtKeyWord = tuple.Item1.TxtKeyWord,
                    IntPageNumber = tuple.Item1.IntPageNumber,
                    IntPageSize = tuple.Item1.IntPageSize,
                    SortValue = tuple.Item1.SortValue,
                    intStateName = tuple.Item1.intStateName,
                    intDistrictName = tuple.Item1.intDistrictName,
                    intManadalName = tuple.Item1.intManadalName,
                    VehicleTypeID = tuple.Item1.VehicleTypeID,
                    flgOnRide = tuple.Item1.flgOnRide,
                    intRideStatusID = tuple.Item1.intRideStatusID,
                    intOwnerID = tuple.Item1.intOwnerID,
                    FlgAccountDeleted = tuple.Item1.FlgAccountDeleted,
                    intRideAmount = tuple.Item1.intRideAmount,
                    intRideCommision=tuple.Item1.intRideCommision,
                    intRideKM=tuple.Item1.intRideKM
                    
                };

                foreach (VehicleFilterEntity entity in tuple.Item2)
                {
                    vehOjb = new VehicleFilterModel
                    {
                        VehicleID = entity.VehicleID,
                        VehicleType = entity.VehicleType,
                        VehicleModel = entity.VehicleModel,
                        OwnerName = entity.OwnerName,
                        VehicleNumber = entity.VehicleNumber,
                        Place = entity.Place,
                        intStateId = entity.intStateId,
                        intDistrictId = entity.intDistrictId,
                        intManadalID = entity.intManadalID,
                        BigIntPhoneNumber = entity.BigIntPhoneNumber,
                        TxtKeyWord = entity.TxtKeyWord,
                        IntPageNumber = entity.IntPageNumber,
                        IntPageSize = entity.IntPageSize,
                        SortValue = entity.SortValue,
                        intStateName = entity.intStateName,
                        intDistrictName = entity.intDistrictName,
                        intManadalName = entity.intManadalName,
                        VehicleTypeID = entity.VehicleTypeID,
                        flgOnRide = entity.flgOnRide,
                        intRideStatusID = entity.intRideStatusID,
                        intOwnerID = entity.intOwnerID,
                        FlgAccountDeleted = entity.FlgAccountDeleted,
                        intRideAmount = entity.intRideAmount,
                        intRideCommision = entity.intRideCommision,
                        intRideKM = entity.intRideKM
                    };
                    list.Add(vehOjb);
                }
            }


            Tuple<VehicleFilterModel, List<VehicleFilterModel>> modelTuple = new Tuple<VehicleFilterModel, List<VehicleFilterModel>>(model, list);
            return modelTuple;
        }

        internal PriceModel MapPriceEntityToPriceModel(PriceEntity entity)
        {
            PriceModel model = new PriceModel();
            if (entity != null)
            {
                model = new PriceModel()
                {
                    FinalPrice = entity.FinalPrice,
                    AvgTollCost = entity.AvgTollCost,
                    FinalDriverCost = entity.FinalDriverCost,
                    FinalCost = entity.FinalCost,
                    FinalFuelCost = entity.FinalFuelCost
                };
            }
            return model;
        }

        internal VehicleTypesModel MapVehicleTypesEntityToModel(VehicleTypesEntity entity)
        {
            VehicleTypesModel model = new VehicleTypesModel();
            if (entity != null)
            {
                model.intVehicleTypeId = entity.intVehicleTypeId;
                model.txtVehicleType = entity.txtVehicleType;
                model.intMileage = entity.intMileage;
                model.intAverageFuelPrice = entity.intAverageFuelPrice;
                model.intDriverSalary = entity.intDriverSalary;
                model.intAvgTollPrice = entity.intAvgTollPrice;
                model.intAverageSpeed = entity.intAverageSpeed;
                model.intAvgWorkingHours = entity.intAvgWorkingHours;
                model.intFuelCostPerKM = entity.intFuelCostPerKM;
                model.intDriverCostPerKM = entity.intDriverCostPerKM;
                model.intTotalCostPerKM = entity.intTotalCostPerKM;
                model.BaseFare = entity.BaseFare;
            }
            return model;
        }


        internal List<VehicleTypesModel> MapVehicleTypesEntityListToModel(List<VehicleTypesEntity> entityList)
        {
            VehicleTypesModel model = new VehicleTypesModel();
            List<VehicleTypesModel> listModel = new List<VehicleTypesModel>();
            if (entityList != null)
            {
                foreach (VehicleTypesEntity entity in entityList)
                {
                    model = new VehicleTypesModel();
                    model.intVehicleTypeId = entity.intVehicleTypeId;
                    model.txtVehicleType = entity.txtVehicleType;
                    model.intMileage = entity.intMileage;
                    model.intAverageFuelPrice = entity.intAverageFuelPrice;
                    model.intDriverSalary = entity.intDriverSalary;
                    model.intAvgTollPrice = entity.intAvgTollPrice;
                    model.intAverageSpeed = entity.intAverageSpeed;
                    model.intAvgWorkingHours = entity.intAvgWorkingHours;
                    model.intFuelCostPerKM = entity.intFuelCostPerKM;
                    model.intDriverCostPerKM = entity.intDriverCostPerKM;
                    model.intTotalCostPerKM = entity.intTotalCostPerKM;
                    model.BaseFare = entity.BaseFare;
                    listModel.Add(model);
                }
            }
            return listModel;
        }
        
        internal DriverModel MapDriverEntityToModel(DriverEntity entity)
        {
            DriverModel model=new DriverModel();
            if (entity != null)
            {
                model.txtDriverName = entity.txtDriverName;
                model.intDriverID = entity.intDriverID;
                model.BigIntPhoneNumber = entity.BigIntPhoneNumber;
                model.intStateId = entity.intStateId;
                model.intDistrictId = entity.intDistrictId;
                model.intManadalID = entity.intManadalID;
                model.txtPlace = entity.txtPlace;

            }
            return model;
        }

        #endregion

    }
}
