﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiteRaju.ProxyService;
using System.ServiceModel;
using RaiteRaju.ServiceLayer;
using RaiteRaju.ServiceLayerInterface;
using RaiteRaju.Web.Models;
using RaiteRaju.Entities;
using RaiteRaju.ServiceMapper.ObjectMapper;

namespace RaiteRaju.ServiceMapper
{
    public class InformationServiceWrapper
    {
        public List<GDictionaryModel> FetchStates()
        {

            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.FetchStates();
            gdModel = objmapper.MapGDictionaryEntityListToModelList(gdEntityList);
            return gdModel;
        }

        public List<GDictionaryModel> FetDistrictsOfState(int StateId)
        {
            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.FetDistrictsOfState(StateId);
            gdModel = objmapper.MapGDictionaryEntityListToModelList(gdEntityList);
            return gdModel;
        }
        public List<GDictionaryModel> FetMandalsOfDistrct(int DistrictId)
        {
            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.FetMandalsOfDistrct(DistrictId);
            gdModel = objmapper.MapGDictionaryEntityListToModelList(gdEntityList);
            return gdModel;
        }
        public List<GDictionaryModel> GetCategories()
        {
            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.GetCategories();
            gdModel = objmapper.MapGDictionaryEntityListToModelList(gdEntityList);
            return gdModel;
        }

        public UserDetailsModel GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            UserDetailsModel DetModelObj = new UserDetailsModel();
            UserDetailsEntity DetEntityObj = new UserDetailsEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            DetEntityObj = obj.GetUserDetailsWithOTP(OTP, PhoneNumber);
            DetModelObj = ObjMapper.MapDetailsEntityToDetailsModel(DetEntityObj);
            return DetModelObj;
        }
        public UserDetailsModel GetUserDetailsWithPassword(Int64 PhoneNumber, string Password)
        {
            UserDetailsModel DetModelObj = new UserDetailsModel();
            UserDetailsEntity DetEntityObj = new UserDetailsEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            DetEntityObj = obj.GetUserDetailsWithPassword(PhoneNumber, Password);
            DetModelObj = ObjMapper.MapDetailsEntityToDetailsModel(DetEntityObj);
            return DetModelObj;
        }
        public List<AdDetailsModel> GetUserAds(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsModel> listobj = new List<AdDetailsModel>();
            List<AdDetailsEntity> listEntity = new List<AdDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            listEntity = obj.GetUserAds(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
            listobj = ObjMapper.MapAdDetailsEntityListToAdDetailsModel(listEntity);
            return listobj;
        }
        public UserDetailsModel GetLoginCheck(Int64 PhoneNumber, string Password)
        {
            UserDetailsEntity EntityObj = new UserDetailsEntity();
            UserDetailsModel ModelObj = new UserDetailsModel();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            EntityObj = obj.GetLoginCheck(PhoneNumber, Password);
            ModelObj = ObjMapper.MapUserDetailsModelToEntity(EntityObj);
            return ModelObj;

        }
        public AdDetailsModel FetchAdDetails(int AdId)
        {
            AdDetailsModel modelObj = new AdDetailsModel();
            AdDetailsEntity EntityObj = new AdDetailsEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityObj = obj.FetchAdDetails(AdId);
            modelObj = ObjMapper.MapAdDetailsEntityToModel(EntityObj);
            return modelObj;
        }
        public DropDownWrapperModel GetDropDownValues()
        {
            DropDownWrapperModel model = new DropDownWrapperModel();
            DropDrownWrapper Entity = new DropDrownWrapper();
            List<GDictionaryModel> District = new List<GDictionaryModel>();
            List<GDictionaryModel> mandal = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Entity = obj.GetDropDownValues();
            model = ObjMapper.MapDropDownwrapperEntityToModel(Entity);
            return model;
        }
        public GDictionaryModel MobileNumberVerification(Int64 MobileNumber)
        {
            GDictionaryModel Model = new GDictionaryModel();
            GDictionary entity = new GDictionary();
            ServiceLayer.InformationService obj = new InformationService();
            entity = obj.MobileNumberVerification(MobileNumber);
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Model = ObjMapper.MapGDictionaryEntityToModel(entity);
            return Model;

        }
        //public AdDetailsModel GetImage(AdDetailsModel Detobj)
        //{

        //    AdDetailsModel modelObjoutPut = new AdDetailsModel();
        //    AdDetailsEntity EntityObj1 = new AdDetailsEntity();
        //    AdDetailsEntity EntityObj2= new AdDetailsEntity();

        //    ServiceLayer.InformationService obj = new InformationService();
        //    InformationObjectMapper ObjMapper = new InformationObjectMapper();
        //    EntityObj1 = ObjMapper.MapAdDetailsModelToEntity(Detobj);
        //    EntityObj2 = obj.GetImage(EntityObj1);
        //    modelObjoutPut = ObjMapper.MapAdDetailsEntityToModel(EntityObj2);
        //    return modelObjoutPut;
        //}

        public List<AdDetailsModel> SPRRGetADbyCategory(int CategoryID, Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsModel> listObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> EntityListObj = new List<AdDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityListObj = obj.SPRRGetADbyCategory(CategoryID, PAGENUMBER, out TotalPageNumber);
            listObj = ObjMapper.MapAdDetailsListEntityToAdDetailsModel(EntityListObj);
            return listObj;
        }
        public AdDetailsModel SPRRGetAdDisplayDetails(Int32 AdId,out int outputparam)
        {
            AdDetailsModel Model = new AdDetailsModel();
            AdDetailsEntity Entity = new AdDetailsEntity();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Entity = obj.SPRRGetAdDisplayDetails(AdId, out outputparam);
            Model = ObjMapper.MapAdDetailsEntityToAdDetailsModel(Entity);
            return Model;
        }
        public List<AdDetailsModel> GetfilteredAds(AdFilterModel Obj, out int TotalPageNumber)
        {
            List<AdDetailsModel> listObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> EntityListObj = new List<AdDetailsEntity>();

            AdFilterEntity Entity = new AdFilterEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Entity = ObjMapper.MapAdFilterModelToAdFilterEntity(Obj);
            EntityListObj = obj.GetFilteredAds(Entity, out TotalPageNumber);
            listObj = ObjMapper.MapAdDetailsListEntityToAdDetailsModel(EntityListObj);
            return listObj;
        }
        public List<AdDetailsModel> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsModel> listObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> EntityListObj = new List<AdDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            EntityListObj = obj.FetchAdDetailsToVerify(PAGENUMBER, out TotalPageNumber);
            listObj = objmapper.MapAdDetailsListEntityToAdDetailsModel(EntityListObj);
            return listObj;
        }
        public List<GDictionaryModel> FetchReviews()
        {
            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.FetchReviews();
            gdModel = objmapper.MapGDictionaryEntityListToModelList(gdEntityList);
            return gdModel;

        }
        public List<Int32> getAdIdsWithUserid(Int32 Userid)
        {
            List<Int32> adList = new List<Int32>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            adList = obj.getAdIdsWithUserid(Userid);
            return adList;
        }
        public UserDetailsModel AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            UserDetailsModel UserModel = new UserDetailsModel();
            UserDetailsEntity UserEntity = new UserDetailsEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            UserEntity = obj.AdminLoginCheck(PhoneNumber, Password);
            UserModel = objmapper.MapUserDetailsModelToEntity(UserEntity);
            return UserModel;
        }
        public List<UserDetailsModel> FetchUserDetailsForAdminPage(AdFilterModel Model, out int TotalPageNumber)
        {
            List<UserDetailsModel> listObj = new List<UserDetailsModel>();
            List<UserDetailsEntity> EntityListObj = new List<UserDetailsEntity>();

            AdFilterEntity Entity = new AdFilterEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Entity = ObjMapper.MapAdFilterModelToAdFilterEntity(Model);
            EntityListObj = obj.FetchUserDetailsForAdminPage(Entity, out TotalPageNumber);
            listObj = ObjMapper.MapUserDetailsModelListToEntityList(EntityListObj);
            return listObj;
        }
        public List<AdDetailsModel> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsModel> listObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> EntityListObj = new List<AdDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            EntityListObj = obj.FetAdDetailsForAdminPageVerifiedAds(PAGENUMBER, out TotalPageNumber);
            listObj = objmapper.MapAdDetailsListEntityToAdDetailsModel(EntityListObj);
            return listObj;
        }
        public List<AdViewStatisticsModel> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdViewStatisticsModel> listObj = new List<AdViewStatisticsModel>();
            List<AdViewsStatisticsEntity> EntityListObj = new List<AdViewsStatisticsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            EntityListObj = obj.FetchAdViewsStatistics(PAGENUMBER, out TotalPageNumber);
            listObj = objmapper.MapAdViewsStatisticsEntityListToAdViewStatisticsModelList(EntityListObj);
            return listObj;
        }
        public List<AdDetailsModel> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsModel> listObj = new List<AdDetailsModel>();
            List<AdDetailsEntity> EntityListObj = new List<AdDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityListObj = obj.FetchAdsForHomePage(PAGENUMBER, out TotalPageNumber);
            listObj = ObjMapper.MapAdDetailsListEntityToAdDetailsModel(EntityListObj);
            return listObj;

        }
        public List<ReviewModel> FetchReviewsForAdmin()
        {
            List<ReviewModel> ModelList = new List<ReviewModel>();
            List<ReviewEntity> EntityList = new List<ReviewEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityList = obj.FetchReviewDetailsForAdmin();
            ModelList = ObjMapper.MapReviewEntityToModel(EntityList);
            return ModelList;
        }
        public List<ContactUsModel> FetchContactForAdmin()
        {
            List<ContactUsModel> ModelList = new List<ContactUsModel>();
            List<ContactUsEntity> EntityList = new List<ContactUsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityList = obj.FetchContactUsDetailsForAdmin();
            ModelList = ObjMapper.MapContactUsEntityToModel(EntityList);
            return ModelList;
        }
        public List<ExceptionModel> FetchExceptionsForAdmin()
        {
            List<ExceptionModel> ModelList = new List<ExceptionModel>();
            List<ExceptionEntity> EntityList = new List<ExceptionEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityList = obj.FetchExceptionDetailsForAdmin();
            ModelList = ObjMapper.MapExceptionEntityToModel(EntityList);
            return ModelList;
        }
        public List<UserDetailsModel> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<UserDetailsModel> ModelList = new List<UserDetailsModel>();
            List<UserDetailsEntity> EntityList = new List<UserDetailsEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            EntityList = obj.FetchUnverifiedUsers(PAGENUMBER, out TotalPageNumber);
            ModelList = ObjMapper.MapUserDetailsModelListToEntityList(EntityList);
            return ModelList;

        }
    }
}
