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
using System.Net;
using System.IO;
using System.Net.Mail;

namespace RaiteRaju.DAL
{
    public class ManagementDAL
    {

        public int InsertAddUserDetails(UserDetailsEntity Obj)
        {
            int UserID = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBUserDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamtName, DbType.String, Obj.txtName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, Obj.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Obj.txtPassword);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, Obj.OTP);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                    }
                    if (Obj.KeyForUserSettings != "ADMIN")
                    {
                        string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + Obj.BigIntPhoneNumber + "/" + Obj.OTP + "/BellaCabsOTP";
                        HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                        //optional
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        Stream stream = response.GetResponseStream();
                    }
                    dr.Close();
                }
                return UserID;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "InsertAddUserDetails", ex.Message);
                return 0;
            }

        }

        public int UPDATEOTP(UserDetailsEntity Obj)
        {
            int OTP = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_OTP))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.String, Obj.OTP);
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        OTP = Convert.ToInt32(dr[DataAccessConstants.PARAMOTP]);
                    }
                    dr.Close();
                    if (OTP != 0 || OTP != -1)
                    {
                        SendOTP(Obj.BigIntPhoneNumber, OTP);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UPDATEOTP", ex.Message);
            }

            return OTP;
        }

       
        public int DeleteUserAccount(Int64 BigIntPhoneNumber)
        {
            int Success = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.DELETE_User))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, BigIntPhoneNumber);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "DeleteUserAccount", ex.Message);
                return 0;
            }
        }

        public int InsertReview(Int64 PhoneNumber, String reviewDescription)
        {
            int Success = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBReview))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMReview, DbType.String, reviewDescription);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "InsertReview", ex.Message);
                return 0;
            }
        }

        public int insertContactUs(ContactUsEntity ENTITY)
        {
            int Success = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBContactUs))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, ENTITY.PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMSubject, DbType.String, ENTITY.Subject);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDescription, DbType.String, ENTITY.Description);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "insertContactUs", ex.Message);
                return 0;
            }
        }

        public int InsertPromotions(string Name, Int64 PhoneNumber, string Description)
        {
            int Success = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBInsertPromotions))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamtName, DbType.String, Name);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDescription, DbType.String, Description);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "InsertPromotions", ex.Message);
                return 0;
            }

        }

        #region ManaBandi methods

        public int BookRide(RideEntity ride)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBRideDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamtName, DbType.String, ride.Name);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, ride.PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, ride.Password);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPICKUPLOCATION, DbType.String, ride.PickUpLocation);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTDROPLOCATION, DbType.String, ride.DropLocation);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, ride.VehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, ride.OTP);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }

                if (Success > 0 & ride.OTP != 0)
                {
                    SendOTP(ride.PhoneNumber, ride.OTP);
                    SendMail();
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "BookRide", ex.Message);
                return 0;
            }
        }
        public int UpateRideDetailsForAdmin(RideEntity ride)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBRideDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPICKUPLOCATION, DbType.String, ride.PickUpLocation);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTDROPLOCATION, DbType.String, ride.DropLocation);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, ride.VehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDEID, DbType.Int32, ride.intRideID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDESTATUSID, DbType.Int32, Convert.ToInt32(ride.txtRideStatus));
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDTSCHEDULEDDATE, DbType.String, ride.dtScheduledDate);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDTSCHEDULEDTIME, DbType.String, ride.txtScheduledTime);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTVEHICLENUMBER, DbType.String, ride.txtVehicleNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDEAMOUNT, DbType.Decimal, ride.intRideAmount);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDECOMMISSION, DbType.Decimal, ride.intRideCommision);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTRIDEKM, DbType.Decimal, ride.intRideKM);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UpateRideDetailsForAdmin", ex.Message);
                return 0;
            }
        }

        public UserDetailsEntity VerifyMobileNumber(UserDetailsEntity Obj)
        {
            UserDetailsEntity Entity = new UserDetailsEntity();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_UserStatusToVerified))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.String, Obj.OTP);
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        Entity.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        Entity.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        Entity.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        Entity.txtPassword = Convert.ToString(dr[DataAccessConstants.PARAMPASSWORD]);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "VerifyMobileNumber", ex.Message);
                return null;
            }

            return Entity;
        }

        public void SendOTP(Int64 PhoneNumber, Int32 OTP)
        {
            string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + PhoneNumber + "/" + OTP + "/BellaCabsOTP";
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            //optional
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
        }

        public int UpdateUserDetails(UserDetailsEntity Obj)
        {
            int UserID = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBUserDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, Obj.intUserId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamtName, DbType.String, Obj.txtName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMKEYFORUSERSETTINGS, DbType.String, Obj.KeyForUserSettings);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.String, Obj.txtState);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.String, Obj.txtDistrict);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.String, Obj.txtMandal);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPLACE, DbType.String, Obj.txtvillage);

                    if (Obj.KeyForUserSettings == Convert.ToString(UserSettings.DETAILS))
                    {
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Obj.txtPassword);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, Obj.OTP);

                        IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                        while (dr.Read())
                        {
                            UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        }
                        dr.Close();
                    }


                    else if (Obj.KeyForUserSettings == Convert.ToString(UserSettings.PASSWORD))
                    {
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Obj.txtPassword);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, Obj.OTP);

                        IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                        while (dr.Read())
                        {
                            UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        }
                        dr.Close();
                    }
                    else if (Obj.KeyForUserSettings == Convert.ToString(UserSettings.PHONENUMBER))
                    {
                        string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + Obj.BigIntPhoneNumber + "/" + Obj.OTP + "/BellaCabsOTP";
                        HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                        //optional
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        Stream stream = response.GetResponseStream();


                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Obj.txtPassword);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                        DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, Obj.OTP);

                        IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                        while (dr.Read())
                        {
                            UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        }
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UpdateUserDetails", ex.Message);
            }

            return UserID;
        }

        public int VehicleOwnerRegistration(OwnerEntity owner)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBVehicleOwnerDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTOWNERNAME, DbType.String, owner.txtOwnerName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, owner.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, owner.txtPassword);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, owner.OTP);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.String, owner.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, owner.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, owner.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPLACE, DbType.String, owner.txtPlace);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }

                if (Success > 0 & owner.OTP != 0)
                {
                    SendOTP(owner.BigIntPhoneNumber, owner.OTP);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "VehicleOwnerRegistration", ex.Message);
                return 0;
            }
        }

        public string AddVehicle(VehicleEntity entity)
        {

            try
            {

                string txtReturnValue = "";
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_VehicleDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, entity.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.String, entity.intVehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTVEHICLENAME, DbType.String, entity.txtVehicleName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTVEHICLENUMBER, DbType.String, entity.txtVehicleNumber);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);

                    while (dr.Read())
                    {
                        txtReturnValue = Convert.ToString(dr[DataAccessConstants.PARAMTXTRETURNVALUE]);
                    }
                    dr.Close();
                }
                return txtReturnValue;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "AddVehicle", ex.Message);
                return null;
            }


        }

        public string UpdateVehicleDetails(VehicleEntity entity)
        {
            try
            {
                string txtReturnValue = "";
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBVehicleDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLEID, DbType.Int32, entity.intVehicleID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, entity.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.String, entity.intVehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTVEHICLENAME, DbType.String, entity.txtVehicleName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTVEHICLENUMBER, DbType.String, entity.txtVehicleNumber);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);

                    while (dr.Read())
                    {
                        txtReturnValue = Convert.ToString(dr[DataAccessConstants.PARAMTXTRETURNVALUE]);
                    }
                    dr.Close();
                }
                return txtReturnValue;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "DeleteVehicle", ex.Message);
                return null;
            }
        }

        public int UpdateVehicleOwnerDetailsByAdmin(OwnerEntity owner)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBVehicleOwnerDetailsByAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTOWNERID, DbType.Int32, owner.intOwnerID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTOWNERNAME, DbType.String, owner.txtOwnerName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, owner.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.String, owner.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, owner.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, owner.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPLACE, DbType.String, owner.txtPlace);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }
                
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UPDATE_MBVehicleOwnerDetailsByAdmin", ex.Message);
                return 0;
            }
        }

        public void DeleteVehicle(int VehicleID, Int64 PhoneNumber)
        {
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.DELETE_MBVehicle))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLEID, DbType.Int32, VehicleID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);

                    int success = DBAccessHelper.ExecuteNonQuery(objDbCommand);

                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "DeleteVehicle", ex.Message);
            }
        }

        public string UpdateVehicleTypes(VehicleTypesEntity entity)
        {
            string returnVal = "";
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBVehicleTypes))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, entity.intVehicleTypeId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMILEAGE, DbType.Int32, entity.intMileage);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTAVERAGEFUELPRICE, DbType.Decimal, entity.intAverageFuelPrice);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTDRIVERSALARY, DbType.Decimal, entity.intDriverSalary);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTAVGTOLLPRICE, DbType.Decimal, entity.intAvgTollPrice);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTAVERAGESPEED, DbType.Int32, entity.intAverageSpeed);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTAVGWORKINGHOURS, DbType.Int32, entity.intAvgWorkingHours);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMBASEFARE, DbType.Int32, entity.BaseFare);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        returnVal = Convert.ToString(dr[DataAccessConstants.PARAMTXTRETURNVALUE]);
                    }

                    dr.Close();
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UpdateVehicleTypes", ex.Message);
                return null;
            }

        }

        public int DriverRegistration(DriverEntity driver)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBDriverDetails))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTDRIVERNAME, DbType.String, driver.txtDriverName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, driver.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, driver.txtPassword);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, driver.OTP);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.String, driver.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, driver.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, driver.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPLACE, DbType.String, driver.txtPlace);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }

                if (Success > 0 & driver.OTP != 0)
                {
                    SendOTP(driver.BigIntPhoneNumber, driver.OTP);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "DriverRegistration", ex.Message);
                return 0;
            }
        }

        public int UpdateDriverDetailsByAdmin(DriverEntity owner)
        {
            int Success = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_MBDriverDetailsByAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTDRIVERID, DbType.Int32, owner.intDriverID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTDRIVERNAME, DbType.String, owner.txtDriverName);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, owner.BigIntPhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTSTATEID, DbType.String, owner.intStateId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDISTRICTID, DbType.Int32, owner.intDistrictId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTMANDALID, DbType.Int32, owner.intManadalID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMTXTPLACE, DbType.String, owner.txtPlace);
                    Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
                }

                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UpdateDriverDetailsByAdmin", ex.Message);
                return 0;
            }
        }

        public string UpdatePriceMultiple(PriceMultipleEntity entity)
        {
            string returnVal = "";
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.UPDATE_PriceMultiple))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTVEHICLETYPEID, DbType.Int32, entity.intVehicleTypeID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PAMAMINTPRICEPK, DbType.Int32, entity.IntPricePK);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMDECIMALPRICEMULTIPLE, DbType.Decimal, entity.intPriceMultiple);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPRICEPERKM, DbType.Decimal, entity.intPricePerKM);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        returnVal = Convert.ToString(dr[DataAccessConstants.PARAMTXTRETURNVALUE]);
                    }

                    dr.Close();
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "UpdatePriceMultiple", ex.Message);
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

        public void SendMail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("bellacabs1@gmail.com");
            message.To.Add(new MailAddress("katamaraju.p@gmail.com"));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "You have received one ride, Please check";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("bellacabs1@gmail.com", "BellaCabs@1");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        #endregion

    }

}
