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

namespace RaiteRaju.DAL
{
   public class ManagementDAL
    {
       public int InsertAddPostDetails(AdDetailsEntity Obj)
       {
           int AddId = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPINSERTADDDETAILS))
               {
                   //DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdTitle, DbType.String, Obj.Title);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdCategory, DbType.String, Obj.Category);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTCATEGORYID, DbType.Int32, Obj.intCategoryId);

                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdDescription, DbType.String, Obj.AdDescription);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, Obj.UserID);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand,DataAccessConstants.ParamSubCategoryName,DbType.String,Obj.txtSubCategoryName);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPrice, DbType.Int32, Obj.Price);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamQuantity, DbType.Int32, Obj.Quantity);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamSellingUnit, DbType.String, Obj.SellingUnit);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.MobileNumber);

                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       AddId = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                   }
                   dr.Close();
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "InsertAddPostDetails", ex.Message);
               return 0;
           }
           return AddId;
       }

       public int UploadImage(AdDetailsEntity Obj)
       {
           int AddId = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPUPLOADIMAGE))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPHOTO, DbType.Binary, Obj.Image);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.Int32, Obj.AdID);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, Obj.UserID);
                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       AddId = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                   }
                   dr.Close();
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "UploadImage", ex.Message);
               return 0;
           }
           return AddId;
       }
       public int InsertAddUserDetails(UserDetailsEntity Obj)
       {
           int UserID = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPINSERTUSERDETAILS))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamtName, DbType.String, Obj.txtName);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, Obj.BigIntPhoneNumber);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamState, DbType.String, Obj.txtState);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamDistrict, DbType.String, Obj.txtDistrict);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamMandal, DbType.String, Obj.txtMandal);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.Paramvillage, DbType.String, Obj.txtvillage);
                  // DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamMailId, DbType.String, Obj.txtMailId);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMPASSWORD, DbType.String, Obj.txtPassword);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, Obj.OTP);
          
                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                   }
                   if (Obj.KeyForUserSettings != "ADMIN")
                   {
                       string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + Obj.BigIntPhoneNumber + "/" + Obj.OTP + "/RaiteRajuOTP";
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
       public int UpdatePassword(UserDetailsEntity Obj)
       {
           int UserID = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPUPDAGEUSERDETAILS))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, Obj.intUserId);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, Obj.BigIntPhoneNumber);
                
                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                   }
                   dr.Close();
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "UpdatePassword", ex.Message);
           }

           return UserID;

       }
       public int UPDATEOTP(UserDetailsEntity Obj)
       {
           int OTP = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPUPDATEOTP))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.BigIntPhoneNumber);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.String, Obj.OTP);
                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       OTP = Convert.ToInt32(dr[DataAccessConstants.PARAMOTP]);
                   }
                   dr.Close();
                   string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + Obj.BigIntPhoneNumber + "/" + Obj.OTP + "/RaiteRajuOTP";
                   HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                   //optional
                   HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                   Stream stream = response.GetResponseStream();
               }

           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "UPDATEOTP", ex.Message);
           }

           return OTP;
       }
       public void UpdateAdDetails(AdDetailsEntity Obj)
       {
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPUPDATEADDETAILS))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.String, Obj.AdID);
                  // DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdTitle, DbType.String, Obj.Title);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdCategory, DbType.String, Obj.Category);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTCATEGORYID, DbType.Int32, Obj.intCategoryId);

                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamSubCategoryName, DbType.String, Obj.txtSubCategoryName);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdDescription, DbType.String, Obj.AdDescription);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPrice, DbType.String, Obj.Price);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamQuantity, DbType.String, Obj.Quantity);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamSellingUnit, DbType.String, Obj.SellingUnit);
                   DBAccessHelper.ExecuteNonQuery(objDbCommand);
                   
               }

           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "UpdateAdDetails", ex.Message);
           }
       }
       public void DeleteUserAd(int AdId)
       {
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPDELETEUSERAD))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.Int32, AdId);
                   DBAccessHelper.ExecuteScalar(objDbCommand);
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "DeleteUserAd", ex.Message);
           }
       }
      
       #region Admin
       public int VerifySelectedAds(string SelectedAds)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPVerifyAds))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdIdS, DbType.String, SelectedAds);
                 Success= DBAccessHelper.ExecuteNonQuery(objDbCommand);
                  
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "VerifySelectedAds", ex.Message);
               Success = 0;
           }
           return Success;
       }
       public int DeleteSelectedUserAccounts(string SelectedUserIds)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SRUserAccountDeletionByAdmin))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.String, SelectedUserIds);
                   Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "DeleteSelectedUserAccounts", ex.Message);
               Success = 0;
           }

           return Success;
       }
       #endregion

       public int DeleteUserAccount(Int64 BigIntPhoneNumber)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPDELETEUSERACCOUNT))
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
       public int InsertReview(Int64 PhoneNumber,String reviewDescription)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPInsertReview))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64,PhoneNumber);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMReview, DbType.String,reviewDescription);
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
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPInsertContactUs))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, ENTITY.PhoneNumber);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMSubject, DbType.String,ENTITY.Subject );
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
       public int DeleteAdsByAdmin(string SelectedAds)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPDeleteAdsByAdmin))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdIdS, DbType.String, SelectedAds);
                   Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "DeleteAdsByAdmin", ex.Message);
               Success = 0;
           }

           return Success;
       }
       public int SPInsertAdViewsStatistics(AdDetailsEntity Entity )
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPInsertAdViewsStatistics))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, Entity.UserID);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, Entity.MobileNumber);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.Int32,Entity.AdID);

                   Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "SPInsertAdViewsStatistics", ex.Message);
               Success = 0;
           }

           return Success;
       }
       public int VerifyUsersByAdmin(string SelectedPhoneNumbers)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPVerifyUsersByAdmin))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, SelectedPhoneNumbers);
                   Success = DBAccessHelper.ExecuteNonQuery(objDbCommand);
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "DeleteAdsByAdmin", ex.Message);
               Success = 0;
           }

           return Success;
       }
       public int InsertAdPostByAdmin(AdDetailsEntity Obj)
       {
           int AddId = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPAdPostByAdmin))
               {
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdCategory, DbType.String, Obj.Category);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdDescription, DbType.String, Obj.AdDescription);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamSubCategoryName, DbType.String, Obj.txtSubCategoryName);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPrice, DbType.Int32, Obj.Price);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamQuantity, DbType.Int32, Obj.Quantity);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamSellingUnit, DbType.String, Obj.SellingUnit);
                   DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.String, Obj.MobileNumber);

                   IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                   while (dr.Read())
                   {
                       AddId = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                   }
                   dr.Close();
               }
           }
           catch (Exception ex)
           {
               ExceptionLoggin("ManagementDal", "InsertAddPostDetails", ex.Message);
               return 0;
           }
           return AddId;
       }
       public int InsertPromotions(string Name, Int64 PhoneNumber,string Description)
       {
           int Success = 0;
           try
           {
               using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPINSERTPROMOTIONS))
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

                if (Success != 0 || Success != -1)
                {
                    SendOTP(ride.PhoneNumber, ride.OTP);
                }
                return Success;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("ManagementDal", "BookRide", ex.Message);
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
        public void SendOTP(Int64 PhoneNumber,Int32 OTP)
        {
            string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + PhoneNumber + "/" + OTP + "/RaiteRajuOTP";
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
                        string URL = "https://2factor.in/API/V1/a2cbd769-9ef3-11e8-a895-0200cd936042/SMS/" + Obj.BigIntPhoneNumber + "/" + Obj.OTP + "/RaiteRajuOTP";
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
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBOwnerDetails))
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

                if (Success != 0 || Success != -1)
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

      public  string AddVehicle(VehicleEntity entity)
        {
            string txtReturnValue = "";
            using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.INSERT_MBOwnerDetails))
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
        #endregion

    }

}
