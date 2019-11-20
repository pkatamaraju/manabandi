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

        internal List<AdDetailsModel> MapAdDetailsEntityListToAdDetailsModel(List<AdDetailsEntity> ListEntity)
        {

            AdDetailsModel AdObj = new AdDetailsModel();
            List<AdDetailsModel> adListObj = new List<AdDetailsModel>();
            if (ListEntity != null)
            {
                foreach (AdDetailsEntity item in ListEntity)
                {
                    AdObj = new AdDetailsModel();
                    AdObj.AdID = item.AdID;
                    AdObj.txtAddTitle = item.Title;
                    AdObj.Category = item.Category;
                    AdObj.intCategoryId = item.intCategoryId;
                    AdObj.txtSubCategoryName = item.txtSubCategoryName;
                    AdObj.txtAdDescription = item.AdDescription;
                    AdObj.txtPrice = item.Price;
                    AdObj.txtQuantity = item.Quantity;
                    AdObj.SellingUnit = item.SellingUnit;
                    AdObj.Image = item.Image;
                    adListObj.Add(AdObj);
                }

                return adListObj;
            }
            else
            {
                return null;
            }
        }

        internal AdDetailsModel MapAdDetailsEntityToModel(AdDetailsEntity Entity)
      {
            if (Entity != null)
            {
                AdDetailsModel MODEL = new AdDetailsModel();
                MODEL.AdID = Entity.AdID;
                MODEL.txtAddTitle = Entity.Title;
                MODEL.txtAdDescription = Entity.AdDescription;
                MODEL.Category = Entity.Category;
                MODEL.intCategoryId = Entity.intCategoryId;
                MODEL.txtSubCategoryName = Entity.txtSubCategoryName;
                MODEL.txtPrice = Entity.Price;
                MODEL.txtQuantity = Entity.Quantity;
                MODEL.SellingUnit = Entity.SellingUnit;
                MODEL.Image = Entity.Image;
                return MODEL;
            }
            else
            {
                return null;
            }
        }

        internal DropDownWrapperModel MapDropDownwrapperEntityToModel(DropDrownWrapper Entity)
        {
            List<GDictionaryModel> District = new List<GDictionaryModel>();
            List<GDictionaryModel> mandal = new List<GDictionaryModel>();

            GDictionaryModel obj;
            DropDownWrapperModel Model = new DropDownWrapperModel();

            foreach (GDictionary ITEM in Entity.DistrctList)
            {
                obj = new GDictionaryModel();
                obj.ID = ITEM.ID;
                obj.Name = ITEM.Name;
                obj.value = ITEM.value;
                obj.Type = ITEM.Type;
                District.Add(obj);
            }
            Model.District = District;

            foreach (GDictionary ITEM in Entity.MandalList)
            {
                obj = new GDictionaryModel();
                obj.ID = ITEM.ID;
                obj.Name = ITEM.Name;
                obj.value = ITEM.value;
                obj.Type = ITEM.Type;
                mandal.Add(obj);
            }
            Model.Mandal = mandal;
            return Model;
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
        internal List<AdDetailsModel> MapAdDetailsListEntityToAdDetailsModel(List<AdDetailsEntity> listObj)
        {

            AdDetailsModel AdObj;
            List<AdDetailsModel> adListObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> AdEntityList = new List<AdDetailsEntity>();
            if (listObj != null)
            {
                foreach (AdDetailsEntity item in listObj)
                {
                    AdObj = new AdDetailsModel();
                    AdObj.AdID = item.AdID;
                    AdObj.txtAddTitle = item.Title;
                    AdObj.Category = item.Category;
                    AdObj.txtSubCategoryName = item.txtSubCategoryName;
                    AdObj.txtAdDescription = item.AdDescription;
                    AdObj.txtPrice = item.Price;
                    AdObj.txtQuantity = item.Quantity;
                    AdObj.SellingUnit = item.SellingUnit;
                    AdObj.Image = item.Image;
                    AdObj.Location = item.Location;
                    AdObj.PostedDate = item.PostedDate;
                    adListObj.Add(AdObj);
                }
                return adListObj;
            }
            else
            {
                return null;
            }
            

        }

        internal AdDetailsModel MapAdDetailsEntityToAdDetailsModel(AdDetailsEntity AdEntity)
        {

            AdDetailsModel AdObj;
            if (AdEntity != null)
            {
                AdObj = new AdDetailsModel();
                AdObj.AdID = AdEntity.AdID;
                AdObj.txtAddTitle = AdEntity.Title;
                AdObj.Category = AdEntity.Category;
                AdObj.intCategoryId = AdEntity.intCategoryId;
                AdObj.txtSubCategoryName = AdEntity.txtSubCategoryName;
                AdObj.txtAdDescription = AdEntity.AdDescription;
                AdObj.txtPrice = AdEntity.Price;
                AdObj.txtQuantity = AdEntity.Quantity;
                AdObj.SellingUnit = AdEntity.SellingUnit;
                AdObj.Image = AdEntity.Image;
                AdObj.Location = AdEntity.Location;
                AdObj.Name = AdEntity.Name;
                AdObj.MobileNuber = AdEntity.MobileNumber;
                AdObj.PostedDate = AdEntity.PostedDate;
                return AdObj;
            }
            else
            {
                return null;
            }

        }

        internal AdFilterEntity MapAdFilterModelToAdFilterEntity(AdFilterModel Model)
        {
            if (Model != null)
            {
                AdFilterEntity Entity = new AdFilterEntity();
                Entity.txtState = Model.txtState;
                Entity.txtMandal = Model.txtMandal;
                Entity.txtDistrict = Model.txtDistrict;
                Entity.CategoryId = Model.CategoryId;
                Entity.TxtKeyWord = Model.TxtKeyWord;
                Entity.INTPAGENUMBER = Model.INTPAGENUMBER;
                Entity.INTPAGESIZE = Model.INTPAGESIZE;
                Entity.SortValue = Model.SortValue;
                return Entity;
            }
            else
                return null;
        }

        internal List<AdViewStatisticsModel> MapAdViewsStatisticsEntityListToAdViewStatisticsModelList(List<AdViewsStatisticsEntity> EntityList)
        {
            if (EntityList != null)
            {
                List<AdViewStatisticsModel> ModelList = new List<AdViewStatisticsModel>();
                AdViewStatisticsModel model;
                foreach(AdViewsStatisticsEntity Entity in EntityList){
                    model=new AdViewStatisticsModel();
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
            ReviewModel Model=new ReviewModel();
            List<ReviewModel> lIST=new List<ReviewModel>();
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

                    rideListObj.Add(rideObj);
                }

                return rideListObj;
            }
            else
            {
                return null;
            }
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

                    model = new VehicleFilterModel();
                    model.VehicleID = entity.VehicleID;
                    model.VehicleType = entity.VehicleType;
                    model.VehicleModel = entity.VehicleModel;
                    model.OwnerName = entity.OwnerName;
                    model.VehicleNumber = entity.VehicleNumber;
                    model.Place = entity.Place;
                    model.intStateId = entity.intStateId;
                    model.intDistrictId = entity.intDistrictId;
                    model.intManadalID = entity.intManadalID;
                    model.BigIntPhoneNumber = entity.BigIntPhoneNumber;
                    model.TxtKeyWord = entity.TxtKeyWord;
                    model.IntPageNumber = entity.IntPageNumber;
                    model.IntPageSize = entity.IntPageSize;
                    model.SortValue = entity.SortValue;
                    model.intStateName = entity.intStateName;
                    model.intDistrictName = entity.intDistrictName;
                    model.intManadalName = entity.intManadalName;
                    model.VehicleTypeID = entity.VehicleTypeID;
                    model.flgOnRide = entity.flgOnRide;
                    model.intRideStatusID = entity.intRideStatusID;

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
            }

            return entity;
        }

        #endregion

    }
}
