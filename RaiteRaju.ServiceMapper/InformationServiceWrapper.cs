using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<GDictionaryModel> GetVehicleTypes()
        {
            List<GDictionary> gdEntityList = new List<GDictionary>();
            List<GDictionaryModel> gdModel = new List<GDictionaryModel>();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper objmapper = new InformationObjectMapper();
            gdEntityList = obj.GetVehicleTypes();
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

        public List<Ride> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            List<Ride> listobj = new List<Ride>();
            List<RideEntity> listEntity = new List<RideEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            listEntity = obj.GetUserRides(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
            listobj = ObjMapper.MapRideEntityListToModel(listEntity);
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

        public GDictionaryModel MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            GDictionaryModel Model = new GDictionaryModel();
            GDictionary entity = new GDictionary();
            ServiceLayer.InformationService obj = new InformationService();
            entity = obj.MobileNuberExistsOrNot(MobileNumber,userType);
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            Model = ObjMapper.MapGDictionaryEntityToModel(entity);
            return Model;

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


        #region ManaBandi Methods

        public List<Vehicle> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            List<Vehicle> listobj = new List<Vehicle>();
            List<VehicleEntity> listEntity = new List<VehicleEntity>();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            listEntity = obj.GetVehicleDetails(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
            listobj = ObjMapper.MapVehicleEntityListToModel(listEntity);
            return listobj;
        }

        public Vehicle GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber)
        {
            Vehicle model = new Vehicle();
            VehicleEntity entity = new VehicleEntity();

            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            entity = obj.GetVehicledDetailsByID(VehicleID, PhoneNumber);
            if (entity != null)
            {
                model = ObjMapper.MapVehicleModelToEntity(entity);
            }
            return model;
        }

        public List<Ride> GetAssignedRideDetails(Int64 phoneNumber, int intPageNumber, out int TotalPageNumber)
        {
            Ride model = new Ride();
            List<Ride> rideList = new List<Ride>();
            List<RideEntity> entityList = new List<RideEntity>();

            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            entityList = obj.GetAssignedRideDetails(phoneNumber, intPageNumber, out TotalPageNumber);
            rideList = ObjMapper.MapRideEntityListToModel(entityList);
            return rideList;
        }

        #endregion


        #region manabandi admin

        public List<VehicleFilterModel> GetVehicleDetailsForAdmin(VehicleFilterModel model, out int TotalPageNumber)
        {
            List<VehicleFilterModel> listobj = new List<VehicleFilterModel>();
            List<VehicleFilterEntity> listEntity = new List<VehicleFilterEntity>();

            VehicleFilterModel modelObj = new VehicleFilterModel();
            VehicleFilterEntity entity = new VehicleFilterEntity();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            entity = ObjMapper.MapVehicleFilterModelToEntity(model);
            listEntity = obj.GetVehicleDetailsForAdmin(entity, out TotalPageNumber);
            listobj = ObjMapper.MapVehicleFilterEntityToModelList(listEntity);
            return listobj;
        }

        public List<VehicleFilterModel> GetOwnerDetailsForAdminPage(VehicleFilterModel model, out int TotalPageNumber)
        {
            List<VehicleFilterModel> listobj = new List<VehicleFilterModel>();
            List<VehicleFilterEntity> listEntity = new List<VehicleFilterEntity>();

            VehicleFilterModel modelObj = new VehicleFilterModel();
            VehicleFilterEntity entity = new VehicleFilterEntity();
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            entity = ObjMapper.MapVehicleFilterModelToEntity(model);
            listEntity = obj.GetOwnerDetailsForAdminPage(entity, out TotalPageNumber);
            listobj = ObjMapper.MapVehicleFilterEntityToModelList(listEntity);
            return listobj;
        }

        public List<Ride> GetRidesForAdmin(VehicleFilterModel model, out int TotalPageNumber)
        {
            List<Ride> listobj = new List<Ride>();
            List<RideEntity> listEntity = new List<RideEntity>();

            VehicleFilterModel modelObj = new VehicleFilterModel();
            VehicleFilterEntity entity = new VehicleFilterEntity();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            entity = ObjMapper.MapVehicleFilterModelToEntity(model);
            listEntity = obj.GetRidesForAdmin(entity, out TotalPageNumber);
            listobj = ObjMapper.MapRideEntityListToModel(listEntity);
            return listobj;
        }

        public PriceModel GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType)
        {
            ServiceLayer.InformationService obj = new InformationService();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            PriceModel model = new PriceModel();

            PriceEntity entity = obj.GetPriceForRide(KM, VehicleTypeId, TravelRequestType);
            model = ObjMapper.MapPriceEntityToPriceModel(entity);
            return model;

        }

        public Ride GetRideDetailsByID(int rideID)
        {
            Ride model = new Ride();
            RideEntity entity = new RideEntity();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            entity = obj.GetRideDetailsByID(rideID);
            model = ObjMapper.MapRideEntityToModel(entity);
            return model;
        }

        public Owner GetOwnerDetailsByIDForAdmin(int ownerID)
        {
            Owner model = new Owner();
            OwnerEntity Entity = new OwnerEntity();
            InformationObjectMapper mapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            Entity = obj.GetOwnerDetailsByIDForAdmin(ownerID);
            model = mapper.MapOwnerEntityToModel(Entity);
            return model;
        }

        public Tuple<VehicleFilterModel, List<VehicleFilterModel>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber)
        {
            VehicleFilterModel model = new VehicleFilterModel();
            List<VehicleFilterModel> list = new List<VehicleFilterModel>();
            InformationObjectMapper mapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> tupleEntity = obj.GetOwnerDetailsByPhoneNumberForAdmin(phoneNumber);
            Tuple<VehicleFilterModel, List<VehicleFilterModel>> tuple = mapper.MapOwnerTuple(tupleEntity);
            return tuple;
        }

        public Tuple<VehicleFilterModel, List<VehicleFilterModel>> GetOwnerDetailsByPhoneOrVehicleNumberForAdmin(string phoneOrVehicleNumber)
        {
            VehicleFilterModel model = new VehicleFilterModel();
            List<VehicleFilterModel> list = new List<VehicleFilterModel>();
            InformationObjectMapper mapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> tupleEntity = obj.GetOwnerDetailsByPhoneOrVehicleNumberForAdmin(phoneOrVehicleNumber);
            Tuple<VehicleFilterModel, List<VehicleFilterModel>> tuple = mapper.MapOwnerTuple(tupleEntity);
            return tuple;
        }

        public List<VehicleTypesModel> VehicleTypeForAdmin()
        {
            List<VehicleTypesModel> listobj = new List<VehicleTypesModel>();
            List<VehicleTypesEntity> listEntity = new List<VehicleTypesEntity>();

            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            listEntity = obj.GetVehicleTypesForAdmin();
            listobj = ObjMapper.MapVehicleTypesEntityListToModel(listEntity);
            return listobj;
        }

        public VehicleTypesModel GetVehicleTypeByIDForAdmin(int vehicleTypeID)
        {
            VehicleTypesModel model = new VehicleTypesModel();
            VehicleTypesEntity entity = new VehicleTypesEntity();
            InformationObjectMapper ObjMapper = new InformationObjectMapper();
            ServiceLayer.InformationService obj = new InformationService();
            entity = obj.GetVehicleTypeByIDForAdmin(vehicleTypeID);
            model = ObjMapper.MapVehicleTypesEntityToModel(entity);
            return model;
        }

        

        #endregion



    }
}
