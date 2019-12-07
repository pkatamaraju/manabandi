using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Reflection;
using RaiteRaju.Entities;
using RaiteRaju.ApplicationUtility;
using RaiteRaju.DAL.DALUtility;

namespace RaiteRaju.DAL
{
    public class InformationDAL
    {
       
        public List<GDictionary> FetchReviews()
        {
            List<GDictionary> GDObjList = new List<GDictionary>();
            GDictionary GDObj = new GDictionary();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBReviews))
                {
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        GDObj = new GDictionary();
                        GDObj.Name = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        GDObj.value = Convert.ToString(dr[DataAccessConstants.PARAMReview]);

                        GDObjList.Add(GDObj);
                    }
                    dr.Close();
                }
                return GDObjList;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchReviews", ex.Message);
                return null;
            }
        }


        #region Admin

        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            UserDetailsEntity UserEntity = new UserDetailsEntity();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.Get_AdminLoginCheck))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Password);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        UserEntity.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                    }
                    dr.Close();
                    return UserEntity;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "AdminLoginCheck", ex.Message);
                return null;
            }
        }

        public List<ReviewEntity> FetchReviewDetailsForAdmin()
        {
            List<ReviewEntity> listEntity = new List<ReviewEntity>();
            ReviewEntity RevObj = null;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_ReviewsForAdmin))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        RevObj = new ReviewEntity();

                        RevObj.DtInserted = Convert.ToString(dr[DataAccessConstants.ParamDtInserted]);
                        RevObj.PhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        RevObj.Review = Convert.ToString(dr[DataAccessConstants.PARAMReview]);
                        RevObj.FlgReviewVerified = Convert.ToInt32(dr[DataAccessConstants.PARAMFlgReviewVerified]);

                        listEntity.Add(RevObj);
                    }
                    dr.Close();
                }
                return listEntity;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchReviewDetailsForAdmin", ex.Message);
                return null;
            }
        }

        public List<ContactUsEntity> FetchContactUsDetailsForAdmin()
        {
            List<ContactUsEntity> listEntity = new List<ContactUsEntity>();
            ContactUsEntity RevObj = null;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_ContactDestailsForAdmin))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        RevObj = new ContactUsEntity();

                        RevObj.DtInserted = Convert.ToString(dr[DataAccessConstants.ParamDtInserted]);
                        RevObj.PhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        RevObj.Description = Convert.ToString(dr[DataAccessConstants.PARAMDescription]);
                        RevObj.Subject = Convert.ToString(dr[DataAccessConstants.PARAMSubject]);

                        listEntity.Add(RevObj);
                    }
                    dr.Close();
                }
                return listEntity;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchContactUsDetailsForAdmin", ex.Message);
                return null;
            }
        }

        public List<ExceptionEntity> FetchExceptionDetailsForAdmin()
        {
            List<ExceptionEntity> listEntity = new List<ExceptionEntity>();
            ExceptionEntity ExceptObj = null;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBExceptionDetailsForAdmin))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        ExceptObj = new ExceptionEntity();

                        ExceptObj.txtExceptionMessage = Convert.ToString(dr[DataAccessConstants.ParamExceptionMessage]);
                        ExceptObj.txtControllerName = Convert.ToString(dr[DataAccessConstants.ParamControllerName]);
                        ExceptObj.txtActionName = Convert.ToString(dr[DataAccessConstants.ParamActionName]);
                        ExceptObj.dtLoggedDate = Convert.ToString(dr[DataAccessConstants.PARAMdtLoggedDate]);

                        listEntity.Add(ExceptObj);
                    }
                    dr.Close();
                }
                return listEntity;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchExceptionDetailsForAdmin", ex.Message);
                return null;
            }
        }

        #endregion

        #region ManaBandi

        public List<GDictionary> FetDistrictsOfState(int StateId)
        {
            GDictionary Districts = null;
            List<GDictionary> DistrictsList = new List<GDictionary>();

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_DistrictsForStateID))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.Int32, StateId);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        Districts = new GDictionary();
                        Districts.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMDISTRICTID]);
                        Districts.Name = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                        DistrictsList.Add(Districts);
                    }
                    dr.Close();
                }
                return DistrictsList;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetDistrictsOfState", ex.Message);
                return null;
            }
        }

        public List<GDictionary> FetMandalsOfDistrct(int DistrictId)
        {
            GDictionary Mandals = null;
            List<GDictionary> MandalList = new List<GDictionary>();

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MandalsOfDistrict))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, DistrictId);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        Mandals = new GDictionary();
                        Mandals.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMMANDALID]);
                        Mandals.Name = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                        MandalList.Add(Mandals);
                    }
                    dr.Close();
                }
                return MandalList;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetMandalsOfDistrct", ex.Message);
                return null;
            }
        }

        public List<GDictionary> GetVehicleTypes()
        {
            GDictionary VehicleTypes = null;
            List<GDictionary> VehicleTypeList = new List<GDictionary>();

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_VehicleTypes))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        VehicleTypes = new GDictionary();
                        VehicleTypes.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);
                        VehicleTypes.Name = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                        VehicleTypeList.Add(VehicleTypes);
                    }
                    dr.Close();
                }
                return VehicleTypeList;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetVehicleTypes", ex.Message);
                return null;
            }
        }

        public UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            UserDetailsEntity userobj = null;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_GetUserDetailsWithOTP))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, OTP);
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        userobj = new UserDetailsEntity();
                        userobj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        userobj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        userobj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        userobj.UserType = Convert.ToString(dr[DataAccessConstants.PARAMUSERTYPE]);
                        userobj.txtState = Convert.ToString(dr[DataAccessConstants.PARAMINTSTATEID]);
                        userobj.txtDistrict = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTID]);
                        userobj.txtMandal = Convert.ToString(dr[DataAccessConstants.PARAMINTMANDALID]);
                        userobj.txtvillage = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);

                    }
                    dr.Close();
                }

                return userobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetUserDetailsWithOTP", ex.Message);
                return null;
            }

        }

        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber, string userType)
        {
            GDictionary RetObj = new GDictionary();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MobileValidation))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, MobileNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMUSERTYPE, DbType.String, userType);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        RetObj.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMRETURNVALUE]);
                    }
                    dr.Close();
                }
                return RetObj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "MobileNuberExistsOrNot", ex.Message);
                return null;
            }
        }

        public UserDetailsEntity GetLoginCheck(Int64 phoneNumber, string password)
        {
            UserDetailsEntity EntityObj = new UserDetailsEntity();
            string Pcheck = string.Empty;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBLoginCheck))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, phoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, password);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        EntityObj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        EntityObj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        EntityObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);

                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetLoginCheck", ex.Message);
            }
            return EntityObj;
        }

        public List<RideEntity> GetUserRides(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            RideEntity rideObj;
            List<RideEntity> ListObj = new List<RideEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_UserRides))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Password);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, INTPAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int32, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        rideObj = new RideEntity();

                        rideObj.PhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        rideObj.intRideID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTRIDEID]);
                        rideObj.DtCreated = Convert.ToString(dr[DataAccessConstants.PARAMDTCREATED]);
                        rideObj.txtScheduledTime = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDTIME]);
                        rideObj.dtScheduledDate = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDDATE]);
                        rideObj.PickUpLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTPICKUPLOCATION]);
                        rideObj.DropLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTDROPLOCATION]);
                        rideObj.VehicleType = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                        ListObj.Add(rideObj);

                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                }
                TotalPageNumber = outputparam;
                return ListObj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetUserRides", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }

        public UserDetailsEntity GetUserDetailsWithPassword(Int64 PhoneNumber, string Password)
        {
            UserDetailsEntity userobj = null;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_GetUserDetailsWithPassword))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Password);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        userobj = new UserDetailsEntity();

                        userobj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        userobj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        userobj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        userobj.UserType = Convert.ToString(dr[DataAccessConstants.PARAMUSERTYPE]);
                        userobj.txtState = Convert.ToString(dr[DataAccessConstants.PARAMINTSTATEID]);
                        userobj.txtDistrict = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTID]);
                        userobj.txtMandal = Convert.ToString(dr[DataAccessConstants.PARAMINTMANDALID]);
                        userobj.txtvillage = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);
                    }
                    dr.Close();

                }

                return userobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetUserDetailsWithPassword", ex.Message);
                return null;

            }
        }

        public void ExceptionLoggin(string ControllerName, string ActionName, string ErrorMessage)
        {
            using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBExceptionLogging))
            {
                DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamControllerName, DbType.String, ControllerName);
                DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamActionName, DbType.String, ActionName);
                DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamExceptionMessage, DbType.String, ErrorMessage);

                DBAccessHelper.ExecuteNonQuery(objDbCommand);
            }
        }

        public List<VehicleEntity> GetVehicleDetails(Int64 PhoneNumber, string Password, int INTPAGENUMBER, out int TotalPageNumber)
        {
            VehicleEntity entity;
            List<VehicleEntity> ListObj = new List<VehicleEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_VehicleDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Password);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, INTPAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int32, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        entity = new VehicleEntity();

                        entity.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        entity.dtCreated = Convert.ToString(dr[DataAccessConstants.PARAMDTCREATED]);
                        entity.txtVehicleType = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                        entity.intOwnerID = Convert.ToString(dr[DataAccessConstants.PARAMINTOWNERID]);
                        entity.txtVehicleName = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENAME]);
                        entity.intVehicleID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLEID]);
                        entity.txtVehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);
                        entity.intVehicleTypeID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);
                        ListObj.Add(entity);

                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                }
                TotalPageNumber = outputparam;
                return ListObj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetVehicleDetails", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }

        public VehicleEntity GetVehicledDetailsByID(int VehicleID, Int64 PhoneNumber)
        {
            VehicleEntity entity = null;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBVehicleDetailsByID))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLEID, DbType.Int32, VehicleID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        entity = new VehicleEntity();

                        entity.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        entity.intOwnerID = Convert.ToString(dr[DataAccessConstants.PARAMINTOWNERID]);
                        entity.txtVehicleName = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENAME]);
                        entity.intVehicleID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLEID]);
                        entity.txtVehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);
                        entity.intVehicleTypeID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);

                    }
                    dr.Close();
                }

                return entity;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetVehicledDetailsByID", ex.Message);
                return null;
            }
        }

        public RideEntity GetRideDetailsByID(int rideID)
        {
            try
            {
                RideEntity rideObj=null;
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBRideDetailsByID))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDEID, DbType.Int32, rideID);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        rideObj = new RideEntity();

                        rideObj.intRideID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTRIDEID]);
                        rideObj.Name = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        rideObj.PhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        rideObj.txtScheduledTime = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDTIME]);
                        rideObj.dtScheduledDate = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDDATE]);
                        rideObj.PickUpLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTPICKUPLOCATION]);
                        rideObj.DropLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTDROPLOCATION]);
                        rideObj.VehicleTypeID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);
                        rideObj.txtRideStatus = Convert.ToString(dr[DataAccessConstants.PARAMINTRIDESTATUSID]);
                        rideObj.txtVehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);

                    }
                    dr.Close();
                }
               
                return rideObj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetRideDetailsByID", ex.Message);
                return null;
            }

        }

        #endregion


        #region ManaBandi Admin

        public List<VehicleFilterEntity> GetVehicleDetailsForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            VehicleFilterEntity vehObj = null;
            int outputparam = 0;
            List<VehicleFilterEntity> listobj = new List<VehicleFilterEntity>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_VehicleDetailsForAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.Int32, Entity.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, Entity.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, Entity.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, Entity.VehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMKEYWORD, DbType.String, Entity.TxtKeyWord);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, Entity.IntPageNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int32, Entity.IntPageSize);
                    //DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMORDERBYSELECTEDVALUE, DbType.Int32, Entity.SortValue);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        vehObj = new VehicleFilterEntity();
                        vehObj.VehicleID = Convert.ToString(dr[DataAccessConstants.PARAMINTVEHICLEID]);
                        vehObj.VehicleType = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                        vehObj.VehicleModel = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENAME]);
                        vehObj.VehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);
                        vehObj.intStateName = Convert.ToString(dr[DataAccessConstants.PARAMTXTSTATENAME]);
                        vehObj.intDistrictName = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                        vehObj.intManadalName = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                        vehObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        vehObj.OwnerName = Convert.ToString(dr[DataAccessConstants.PARAMTXTOWNERNAME]);
                        vehObj.Place = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);
                        vehObj.flgOnRide = Convert.ToInt32(dr[DataAccessConstants.PARAMFLGONRIDE]);

                        listobj.Add(vehObj);

                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                    TotalPageNumber = outputparam;
                }
                return listobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetVehicleDetailsForAdmin", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }

        public List<RideEntity> GetRidesForAdmin(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            RideEntity rideObj;
            List<RideEntity> ListObj = new List<RideEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_RideDetailForAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32,Entity.VehicleTypeID );
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDESTATUSID, DbType.Int32, Entity.intRideStatusID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, Entity.IntPageNumber);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        rideObj = new RideEntity();

                        rideObj.intRideID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTRIDEID]);
                        rideObj.Name= Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        rideObj.PhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        rideObj.DtCreated = Convert.ToString(dr[DataAccessConstants.PARAMDTCREATED]);
                        rideObj.txtScheduledTime = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDTIME]);
                        rideObj.dtScheduledDate = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDDATE]);
                        rideObj.PickUpLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTPICKUPLOCATION]);
                        rideObj.DropLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTDROPLOCATION]);
                        rideObj.VehicleType = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                        rideObj.txtRideStatus= Convert.ToString(dr[DataAccessConstants.PARAMTXTRIDESTATUS]);
                        rideObj.VehicleTypeID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);
                        rideObj.txtVehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);
                        ListObj.Add(rideObj);

                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                }
                TotalPageNumber = outputparam;
                return ListObj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetRidesForAdmin", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }

        public List<VehicleFilterEntity> GetOwnerDetailsForAdminPage(VehicleFilterEntity Entity, out int TotalPageNumber)
        {
            VehicleFilterEntity vehObj = null;
            int outputparam = 0;
            List<VehicleFilterEntity> listobj = new List<VehicleFilterEntity>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_OwnerDetailsForAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.Int32, Entity.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, Entity.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, Entity.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, Entity.IntPageNumber);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        vehObj = new VehicleFilterEntity();
                        vehObj.intStateName = Convert.ToString(dr[DataAccessConstants.PARAMTXTSTATENAME]);
                        vehObj.intDistrictName = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                        vehObj.intManadalName = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                        vehObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        vehObj.OwnerName = Convert.ToString(dr[DataAccessConstants.PARAMTXTOWNERNAME]);
                        vehObj.Place = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);
                        vehObj.intOwnerID= Convert.ToInt32(dr[DataAccessConstants.PARAMINTOWNERID]);
                        vehObj.FlgAccountDeleted= Convert.ToInt32(dr[DataAccessConstants.PARAMFlgAccountDeleted]);
                        listobj.Add(vehObj);

                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                    TotalPageNumber = outputparam;
                }
                return listobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetOwnerDetailsForAdminPage", ex.Message);
                TotalPageNumber = 0;
                return null;
            }

        }

        public int GetPriceForRide(int KM, int VehicleTypeId, string TravelRequestType,out int cost)
        {
           
            int price = 0;
            cost = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_Price))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTKMS, DbType.Int32, KM);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, VehicleTypeId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAINTMDROPORNOT, DbType.Int32, Convert.ToInt32(TravelRequestType));

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        price = Convert.ToInt32(dr[DataAccessConstants.PARAMINTFINALPRICE]);
                        cost= Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALCOST]);
                    }
                    dr.Close();
                }

                return price;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetPriceForRide", ex.Message);
                return 0;
            }
        }
       
        public OwnerEntity GetOwnerDetailsByIDForAdmin(int ownerID)
        {
            OwnerEntity Entity = null;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MBOwnerDetailsByIDForAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTOWNERID, DbType.Int32, ownerID);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        Entity = new OwnerEntity();

                        Entity.intOwnerID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTOWNERID]);
                        Entity.txtOwnerName = Convert.ToString(dr[DataAccessConstants.PARAMTXTOWNERNAME]);
                        Entity.intStateId = Convert.ToInt32(dr[DataAccessConstants.PARAMINTSTATEID]);
                        Entity.intDistrictId = Convert.ToInt32(dr[DataAccessConstants.PARAMDISTRICTID]);
                        Entity.intManadalID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTMANDALID]);
                        Entity.txtPlace = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);
                        Entity.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);

                    }
                    
                    dr.Close();
                    return Entity;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetOwnerDetailsForAdminPage", ex.Message);
                return null;
            }

        }
        
        public Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> GetOwnerDetailsByPhoneNumberForAdmin(Int64 phoneNumber)
        {
            VehicleFilterEntity entity;
            List<VehicleFilterEntity> ListObj = new List<VehicleFilterEntity>();
            VehicleFilterEntity vehObj = new VehicleFilterEntity();

            using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_OwnerDetailsWithPhoneNumberAdmin))
            {
                DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, phoneNumber);

                IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);

                while (dr.Read())
                {
                    vehObj = new VehicleFilterEntity();
                    vehObj.intStateName = Convert.ToString(dr[DataAccessConstants.PARAMTXTSTATENAME]);
                    vehObj.intDistrictName = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                    vehObj.intManadalName = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                    vehObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                    vehObj.OwnerName = Convert.ToString(dr[DataAccessConstants.PARAMTXTOWNERNAME]);
                    vehObj.Place = Convert.ToString(dr[DataAccessConstants.PARAMTXTPLACE]);
                    vehObj.intOwnerID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTOWNERID]);
                    vehObj.FlgAccountDeleted = Convert.ToInt32(dr[DataAccessConstants.PARAMFlgAccountDeleted]);

                }
               
                dr.NextResult();
                while (dr.Read())
                {
                    entity = new VehicleFilterEntity();
                    entity.VehicleID = Convert.ToString(dr[DataAccessConstants.PARAMINTVEHICLEID]);
                    entity.intOwnerID=Convert.ToInt32(dr[DataAccessConstants.PARAMINTOWNERID]);
                    entity.VehicleType = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLETYPE]);
                    entity.VehicleModel = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENAME]);
                    entity.VehicleNumber = Convert.ToString(dr[DataAccessConstants.PARAMTXTVEHICLENUMBER]);
                    entity.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                    entity.flgOnRide = Convert.ToInt32(dr[DataAccessConstants.PARAMFLGONRIDE]);
                    entity.FlgAccountDeleted = Convert.ToInt32(dr[DataAccessConstants.PARAMFLGDELETED]);

                    ListObj.Add(entity);

                }
                dr.Close();
            }
            Tuple<VehicleFilterEntity, List<VehicleFilterEntity>> returnObj = new Tuple<VehicleFilterEntity, List<VehicleFilterEntity>>(vehObj,ListObj);
            return returnObj;
        }

        #endregion

    }
}


