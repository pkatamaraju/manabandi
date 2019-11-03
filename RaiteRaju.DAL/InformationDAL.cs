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

        public List<GDictionary> FetchStates()
        {
            GDictionary States = null;
            List<GDictionary> StateList = new List<GDictionary>();
            
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFETCHSTATESLIST))
                {
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        States = new GDictionary();
                        States.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTSTATEID]);
                        States.Name = Convert.ToString(dr[DataAccessConstants.PARAMTXTSTATENAME]);
                        StateList.Add(States);
                    }
                    dr.Close();
                }
                return StateList;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchStates", ex.Message);
                return null;
            }
        }
       
        public AdDetailsEntity FetchAdDetails(int AdId)
        {
            AdDetailsEntity Entity = new AdDetailsEntity();
            try {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETADDETAILS))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.String, AdId);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        Entity.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                        //Entity.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        Entity.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        Entity.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        Entity.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        Entity.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        Entity.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        Entity.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                    }
                    dr.Close();
                }
            }
            catch(Exception ex){
                ExceptionLoggin("InformationDal", "FetchAdDetails", ex.Message);
            }

            return Entity;
        }
        public DropDrownWrapper GetDropDownValues()
        {
            DropDrownWrapper wrapper = new DropDrownWrapper();
            List<GDictionary> District = new List<GDictionary>();
            List<GDictionary> mandal = new List<GDictionary>();
            GDictionary obj = new GDictionary();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETDistrictList))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        obj = new GDictionary();
                        obj.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTSTATEID]);
                        obj.Name = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                        obj.value = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTID]);
                        District.Add(obj);
                    }
                    dr.Close();
                }
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETMandalList))
                {

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        obj = new GDictionary();
                        obj.ID = Convert.ToInt32(dr[DataAccessConstants.PARAMDISTRICTID]);
                        obj.Name = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                        obj.value = Convert.ToString(dr[DataAccessConstants.PARAMMANDALID]);
                        mandal.Add(obj);
                    }
                    dr.Close();
                }
                wrapper.DistrctList = District;
                wrapper.MandalList = mandal;
                return wrapper;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetDropDownValues", ex.Message);
                return null;                
            }
        }
        //public AdDetailsEntity GetImage(AdDetailsEntity obj)
        //{
        //    AdDetailsEntity Detobj = new AdDetailsEntity();

        //    try
        //    {
        //        //using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETIMAGE))
        //        //{
        //        //    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.Int64, obj.AdID);
        //        //    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.String, obj.UserID);

        //        //    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
        //        //    while (dr.Read())
        //        //    {
        //        //        Detobj.Image = (byte[])(dr[DataAccessConstants.PARAMPHOTO]);
        //        //        Detobj.UserID = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
        //        //        Detobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]); ;
        //        //    }
        //       // dr.Close();
        //        //}
        //        return Detobj;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLoggin("InformationDal", "GetImage", ex.Message);
        //        return null;
        //    }
        //}
        public List<AdDetailsEntity> SPRRGetADbyCategory(Int32 CategoryID, Int32 PAGENUMBER, out int TotalPageNumber)
        {
            int outputparam=0;

            AdDetailsEntity adobj=null;
            List<AdDetailsEntity> listobj = new List<AdDetailsEntity>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGetADbyCategory))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTCATEGORYID, DbType.Int64, CategoryID);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int64, 10);
                    
                  
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                       // adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        adobj.Location = Convert.ToString(dr[DataAccessConstants.PARAMLOCATION]);
                        adobj.PostedDate = Convert.ToString(dr[DataAccessConstants.ParamAdPostedDate]);

                        listobj.Add(adobj);

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
                ExceptionLoggin("InformationDal", "SPRRGetADbyCategory", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }
        public List<AdDetailsEntity> FetchAdsForHomePage(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            int outputparam = 0;

            AdDetailsEntity adobj = null;
            List<AdDetailsEntity> listobj = new List<AdDetailsEntity>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchAdsForHomePage))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int64, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                        //adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        adobj.Location = Convert.ToString(dr[DataAccessConstants.PARAMLOCATION]);
                        adobj.PostedDate = Convert.ToString(dr[DataAccessConstants.ParamAdPostedDate]);

                        listobj.Add(adobj);

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
                ExceptionLoggin("InformationDal", "FetchAdsForHomePage", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }
        public AdDetailsEntity SPRRGetAdDisplayDetails(Int32 AdId, out int outputparam)
        {
            AdDetailsEntity adobj = null;
            int AdViewCount = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETADDISPLAYDETAILS))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamAdId, DbType.Int64, AdId);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                       // adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        adobj.Location = Convert.ToString(dr[DataAccessConstants.PARAMLOCATION]);
                        adobj.Name = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        adobj.MobileNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        adobj.PostedDate = Convert.ToString(dr[DataAccessConstants.ParamAdPostedDate]);

                    }
                    dr.NextResult();
                         while (dr.Read())
                    {
                        AdViewCount = Convert.ToInt32(dr[DataAccessConstants.PARAMINTCOUNT]);
                    }
                         outputparam = AdViewCount;
                    dr.Close();
                }
                return adobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "SPRRGetAdDisplayDetails", ex.Message);
                outputparam = 0;
                return null;
            }
        }

        public List<AdDetailsEntity> GetFilteredAds(AdFilterEntity Entity,out int TotalPageNumber)
        {
            AdDetailsEntity adobj = null;
            int outputparam = 0;
            List<AdDetailsEntity> listobj = new List<AdDetailsEntity>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETFILTEREDADS))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamState, DbType.String, Entity.txtState);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamDistrict, DbType.String, Entity.txtDistrict);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamMandal, DbType.String, Entity.txtMandal);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTCATEGORYID, DbType.Int32, Entity.CategoryId);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMKEYWORD, DbType.String, Entity.TxtKeyWord);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, Entity.INTPAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int32, Entity.INTPAGESIZE);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMORDERBYSELECTEDVALUE, DbType.Int32, Entity.SortValue);
                   
                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                       // adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        adobj.Location = Convert.ToString(dr[DataAccessConstants.PARAMLOCATION]);
                        adobj.PostedDate = Convert.ToString(dr[DataAccessConstants.ParamAdPostedDate]);

                        listobj.Add(adobj);

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
                ExceptionLoggin("InformationDal", "GetFilteredAds", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }
       
        public List<GDictionary> FetchReviews()
        {
            List<GDictionary> GDObjList = new List<GDictionary>();
            GDictionary GDObj = new GDictionary();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchReviews))
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
        public List<Int32> getAdIdsWithUserid(Int32 userid)
        {
            List<Int32> AdList = new List<int>();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPgetAdIdswithUserid))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamUserId, DbType.Int32, userid);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        AdList.Add(Convert.ToInt32(dr[DataAccessConstants.ParamAdId]));

                    }
                    dr.Close();
                    return AdList;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "getAdIdsWithUserid", ex.Message);
                return null;
            }
        }

 #region Admin
        public UserDetailsEntity AdminLoginCheck(Int64 PhoneNumber, string Password)
        {
            UserDetailsEntity UserEntity = new UserDetailsEntity();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGetAdminLoginCheck))
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
        public List<AdDetailsEntity> FetchAdDetailsToVerify(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsEntity> listEntity = new List<AdDetailsEntity>();
            AdDetailsEntity adobj = null;
            List<AdDetailsEntity> listobj = new List<AdDetailsEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchUnverifiedAds))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int64, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                        //adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        listobj.Add(adobj);

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
                ExceptionLoggin("InformationDal", "FetchAdDetailsToVerify", ex.Message);
                TotalPageNumber = 0;
                return null;
            }

        }
        public List<UserDetailsEntity> FetchUserDetailsForAdminPage(AdFilterEntity Entity, out int TotalPageNumber)
        {

            UserDetailsEntity UserObj = null;
            List<UserDetailsEntity> listobj = new List<UserDetailsEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchUserDetailsForAdminManagement))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamState, DbType.String, Entity.txtState);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamDistrict, DbType.String, Entity.txtDistrict);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamMandal, DbType.String, Entity.txtMandal);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, Entity.INTPAGENUMBER);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        UserObj = new UserDetailsEntity();

                        UserObj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId ]);
                        UserObj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        UserObj.txtDistrict = Convert.ToString(dr[DataAccessConstants.ParamDistrict]);
                        UserObj.txtMandal = Convert.ToString(dr[DataAccessConstants.ParamMandal]);
                        UserObj.txtState = Convert.ToString(dr[DataAccessConstants.ParamState]);
                        UserObj.txtvillage = Convert.ToString(dr[DataAccessConstants.Paramvillage]);
                        UserObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        UserObj.bitVerifiedPhoneNumber = Convert.ToInt32(dr[DataAccessConstants.PARAMbitVerifiedPhoneNumber]);
                        UserObj.FlgAccountDeleted = Convert.ToInt32(dr[DataAccessConstants.PARAMFlgAccountDeleted]);

                        listobj.Add(UserObj);

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
                ExceptionLoggin("InformationDal", "FetchUserDetailsForAdminPage", ex.Message);
                TotalPageNumber = 0;
                return null;
            }

        }
        public List<AdDetailsEntity> FetAdDetailsForAdminPageVerifiedAds(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            List<AdDetailsEntity> listEntity = new List<AdDetailsEntity>();
            AdDetailsEntity adobj = null;
            List<AdDetailsEntity> listobj = new List<AdDetailsEntity>();
            int outputparam = 0;
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchAdDetailsForAdminPage))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int64, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdDetailsEntity();

                        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                       // adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                        adobj.txtSubCategoryName = Convert.ToString(dr[DataAccessConstants.ParamSubCategoryName]);
                        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                        listobj.Add(adobj);

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
                ExceptionLoggin("InformationDal", "FetAdDetailsForAdminPageVerifiedAds", ex.Message);
                TotalPageNumber = 0;
                return null;
            }
        }
        public List<AdViewsStatisticsEntity> FetchAdViewsStatistics(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            AdViewsStatisticsEntity adobj = new AdViewsStatisticsEntity();
            List<AdViewsStatisticsEntity> ListObj = new List<AdViewsStatisticsEntity>();
             int outputparam = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchAdViewsStatistis))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int64, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        adobj = new AdViewsStatisticsEntity();
                        adobj.BuyerName = Convert.ToString(dr[DataAccessConstants.PARAMBuyerName]);
                        adobj.BuyerPhoneNumber = Convert.ToString(dr[DataAccessConstants.PARAMBuyerPhoneNumber]);
                        adobj.ViewedAdId = Convert.ToString(dr[DataAccessConstants.PARAMViewedAdId]);
                        adobj.SellerName = Convert.ToString(dr[DataAccessConstants.PARAMSellerName]);
                        adobj.SellerPhoneNumber = Convert.ToString(dr[DataAccessConstants.PARAMSellerPhoneNumber]);

                        ListObj.Add(adobj);
                    }
                     dr.NextResult();
                    while (dr.Read())
                    {
                        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    }
                    dr.Close();
                    TotalPageNumber = outputparam;
                }
                return ListObj;
            }            
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "FetchAdViewsStatistics", ex.Message);
                TotalPageNumber = 0;
                return null;
            }

        }
        public List<ReviewEntity> FetchReviewDetailsForAdmin()
        {
            List<ReviewEntity> listEntity = new List<ReviewEntity>();
            ReviewEntity RevObj = null;
            
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchReviewsForAdmin))
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
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchContactDestails))
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
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchExceptionDetailsForAdmin))
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
        public List<UserDetailsEntity> FetchUnverifiedUsers(Int32 PAGENUMBER, out int TotalPageNumber)
        {
            UserDetailsEntity UserObj = new UserDetailsEntity();
            List<UserDetailsEntity> listobj = new List<UserDetailsEntity>();
            int outputparam = 0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPFetchUnverifiedUsersForAdmin))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int64, PAGENUMBER);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        UserObj = new UserDetailsEntity();

                        UserObj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        UserObj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        UserObj.txtDistrict = Convert.ToString(dr[DataAccessConstants.ParamDistrict]);
                        UserObj.txtMandal = Convert.ToString(dr[DataAccessConstants.ParamMandal]);
                        UserObj.txtState = Convert.ToString(dr[DataAccessConstants.ParamState]);
                        UserObj.txtvillage = Convert.ToString(dr[DataAccessConstants.Paramvillage]);
                        UserObj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        UserObj.bitVerifiedPhoneNumber = Convert.ToInt32(dr[DataAccessConstants.PARAMbitVerifiedPhoneNumber]);
                        UserObj.FlgAccountDeleted = Convert.ToInt32(dr[DataAccessConstants.PARAMFlgAccountDeleted]);

                        listobj.Add(UserObj);
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
                ExceptionLoggin("InformationDal", "FetchAdViewsStatistics", ex.Message);
                TotalPageNumber = 0;
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
        public GDictionary MobileNuberExistsOrNot(Int64 MobileNumber)
        {
            GDictionary RetObj = new GDictionary();
            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.GET_MobileValidation))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, MobileNumber);

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
                        //adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                        rideObj.DtCreated =Convert.ToString(dr[DataAccessConstants.PARAMDTCREATED]);
                        rideObj.txtScheduledTime = Convert.ToString (dr[DataAccessConstants.PARAMDTSCHEDULEDTIME]);
                        rideObj.dtScheduledDate = Convert.ToString(dr[DataAccessConstants.PARAMDTSCHEDULEDDATE]);
                        rideObj.PickUpLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTPICKUPLOCATION]);
                        rideObj.DropLocation = Convert.ToString(dr[DataAccessConstants.PARAMTXTDROPLOCATION]);
                        rideObj.VehicleTypeID = Convert.ToInt32(dr[DataAccessConstants.PARAMINTVEHICLETYPEID]);
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
                        //userobj.txtState = Convert.ToString(dr[DataAccessConstants.PARAMTXTSTATENAME]);
                        //userobj.txtDistrict = Convert.ToString(dr[DataAccessConstants.PARAMDISTRICTNAME]);
                        //userobj.txtMandal = Convert.ToString(dr[DataAccessConstants.PARAMMANDALNAME]);
                        //userobj.txtvillage = Convert.ToString(dr[DataAccessConstants.Paramvillage]);
                        //userobj.txtMailId = Convert.ToString(dr[DataAccessConstants.ParamMailId]);
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
        public UserDetailsEntity GetUserDetailsWithOTP(Int32 OTP, Int64 PhoneNumber)
        {
            // DetailsEntity DetOjb = new DetailsEntity();
            UserDetailsEntity userobj = null;
            //AdDetailsEntity adobj;tp
            //List<AdDetailsEntity> adListObj = new List<AdDetailsEntity>();
            //int outputparam=0;

            try
            {
                using (DbCommand objDbCommand = DBAccessHelper.GetDBCommand(ConnectionManager.DatabaseToConnect.DefaultInstance, StoredProcedures.SPGETUSERDETAILSWITHOTP))
                {
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.ParamPhoneNumber, DbType.Int64, PhoneNumber);
                    DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMOTP, DbType.Int32, OTP);
                    //DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGENUMBER, DbType.Int32, INTPAGENUMBER);
                    //DBAccessHelper.AddInputParametersWithValues(objDbCommand, DataAccessConstants.PARAMINTPAGESIZE, DbType.Int32, 10);

                    IDataReader dr = DBAccessHelper.ExecuteReader(objDbCommand);
                    while (dr.Read())
                    {
                        userobj = new UserDetailsEntity();
                        userobj.intUserId = Convert.ToInt32(dr[DataAccessConstants.ParamUserId]);
                        userobj.BigIntPhoneNumber = Convert.ToInt64(dr[DataAccessConstants.ParamPhoneNumber]);
                        userobj.txtName = Convert.ToString(dr[DataAccessConstants.ParamtName]);
                        //userobj.txtState = Convert.ToString(dr[DataAccessConstants.ParamState]);
                        //userobj.txtDistrict = Convert.ToString(dr[DataAccessConstants.ParamDistrict]);
                        //userobj.txtMandal = Convert.ToString(dr[DataAccessConstants.ParamMandal]);
                        //userobj.txtvillage = Convert.ToString(dr[DataAccessConstants.Paramvillage]);
                        //userobj.txtMailId = Convert.ToString(dr[DataAccessConstants.ParamMailId]);
                    }
                    //    dr.NextResult();
                    //    while (dr.Read())
                    //    {
                    //        adobj = new AdDetailsEntity();

                    //        adobj.AdID = Convert.ToInt32(dr[DataAccessConstants.ParamAdId]);
                    //        adobj.Title = Convert.ToString(dr[DataAccessConstants.ParamAdTitle]);
                    //        adobj.Category = Convert.ToString(dr[DataAccessConstants.ParamAdCategory]);
                    //        adobj.SubCategory = Convert.ToString(dr[DataAccessConstants.ParamSubCategory]);
                    //        adobj.AdDescription = Convert.ToString(dr[DataAccessConstants.ParamAdDescription]);
                    //        adobj.Price = Convert.ToInt32(dr[DataAccessConstants.ParamPrice]);
                    //        adobj.Quantity = Convert.ToInt32(dr[DataAccessConstants.ParamQuantity]);
                    //        adobj.SellingUnit = Convert.ToString(dr[DataAccessConstants.ParamSellingUnit]);
                    //        //adobj.Image = (byte[])(dr[DataAccessConstants.PARAMPHOTO]);
                    //        adListObj.Add(adobj);
                    //    }
                    //    dr.NextResult();
                    //    while (dr.Read())
                    //    {
                    //        outputparam = Convert.ToInt32(dr[DataAccessConstants.PARAMINTTOTALPAGECOUNT]);
                    //    }
                    dr.Close();
                }
                //TotalPageNumber = outputparam;
                //DetOjb.AdDetails = adListObj;
                //DetOjb.UserDetails = userobj;

                return userobj;
            }
            catch (Exception ex)
            {
                ExceptionLoggin("InformationDal", "GetUserDetailsWithOTP", ex.Message);
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

        #endregion
    }
}

