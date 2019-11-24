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

        //internal AdDetailsEntity MapAdDetailsModelToEntity(AdDetailsModel Model)
        //{
        //    AdDetailsEntity Entity = new AdDetailsEntity();

        //    if (Model != null)
        //    {
        //        Entity.AdID = Model.AdID;
        //        Entity.UserID = Model.UserID;
        //        Entity.AdDescription = Model.txtAdDescription;
        //        Entity.Category = Model.Category;
        //        Entity.txtSubCategoryName = Model.txtSubCategoryName;
        //        Entity.Image = Model.Image;
        //        Entity.MobileNumber = Model.MobileNuber;
        //        Entity.Price = Model.txtPrice;
        //        Entity.Quantity = Model.txtQuantity;
        //        Entity.SellingUnit = Model.SellingUnit;
        //        Entity.Title = Model.txtAddTitle;
        //    }
        //    return Entity;
        //}

        internal List<AdViewStatisticsModel> MapAdViewsStatisticsEntityListToAdViewStatisticsModelList(List<AdViewsStatisticsEntity> EntityList)
        {
            if (EntityList != null)
            {
                List<AdViewStatisticsModel> ModelList = new List<AdViewStatisticsModel>();
                AdViewStatisticsModel model;
                foreach (AdViewsStatisticsEntity Entity in EntityList) {
                    model = new AdViewStatisticsModel();
                    model.BuyerName = Entity.BuyerName;
                    model.BuyerPhoneNumber = Entity.BuyerPhoneNumber;
                    model.SellerPhoneNumber = Entity.SellerPhoneNumber;
                    model.SellerName = Entity.SellerName;
                    model.ViewedAdId = Entity.ViewedAdId;
                    ModelList.Add(model);
                }
                return ModelList;
            }
            else
            {
                return null;
            }
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
                        FlgAccountDeleted = entity.FlgAccountDeleted
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

        #endregion

    }
}
