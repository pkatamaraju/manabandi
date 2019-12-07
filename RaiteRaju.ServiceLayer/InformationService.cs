﻿using System;
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
    public class InformationService : InformationServiceInterface
    {

        #region Manabandi
       
        public List<GDictionary> FetDistrictsOfState(int StateId)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.FetDistrictsOfState(StateId);
        }

        public List<GDictionary> FetMandalsOfDistrct(int DistrictId)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.FetMandalsOfDistrct(DistrictId);
        }

        public List<GDictionary> GetVehicleTypes()
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicleTypes();
        }

        public UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserDetailsWithOTP(OTP, PhoneNumber);
        }

        public UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserDetailsWithPassword(PhoneNumber, Password);
        }

        public List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetUserRides(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
        }

        public UserDetailsEntity GetLoginCheck(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetLoginCheck(PhoneNumber, Password);
        }

        public List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicleDetails(PhoneNumber, Password, INTPAGENUMBER, out TotalPageNumber);
        }

        public VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicledDetailsByID(VehicleID, PhoneNumber);
        }

        #endregion

        #region manabandi admin
        public List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetVehicleDetailsForAdmin(Entity, out TotalPageNumber);
        }

        public List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsForAdminPage(Entity, out TotalPageNumber);
        }

        public List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetRidesForAdmin(Entity, out TotalPageNumber);
        }

        public int GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType, out int cost)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetPriceForRide(KM, VehicleTypeId, TravelRequestType, out cost);
        }

        public RideEntity GetRideDetailsByID(int rideID)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetRideDetailsByID(rideID);
        }


        public OwnerEntity GetOwnerDetailsByIDForAdmin(int ownerID)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsByIDForAdmin(ownerID);
        }

        public Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.GetOwnerDetailsByPhoneNumberForAdmin(phoneNumber);
        }

        #endregion

        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            InformationBusinessLayerInterface obj = new BusinessLayer.InformationBusinessLayer();
            return obj.MobileNuberExistsOrNot(MobileNumber, userType);

        }


        public List<GDictionary> FetchReviews()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchReviews();

        }

        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.AdminLoginCheck(PhoneNumber, Password);
        }

        public List<ContactUsEntity> FetchContactUsDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchContactUsDetailsForAdmin();
        }

        public List<ReviewEntity> FetchReviewDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchReviewDetailsForAdmin();
        }

        public List<ExceptionEntity> FetchExceptionDetailsForAdmin()
        {
            InformationBusinessLayerInterface BusObj = new BusinessLayer.InformationBusinessLayer();
            return BusObj.FetchExceptionDetailsForAdmin();
        }

       
    }


}
