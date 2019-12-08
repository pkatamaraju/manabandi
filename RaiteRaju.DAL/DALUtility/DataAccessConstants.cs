using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.DAL.DALUtility
{
    public class DataAccessConstants
    {

        public const string ParamAdTitle = "txtAdTitle";
        public const string ParamAdId = "intAdId";
        public const string ParamAdIdS = "intAdIds";
        public const string ParamAdCategory = "txtAdCategory";
        public const string ParamCategory = "txtCategoryName";
        public const string ParamAdDescription = "txtAdDescription";
        public const string ParamUserId = "intUserId";
        public const string ParamSubCategoryName = "txtSubCategoryName";
        public const string ParamPrice = "intPrice";
        public const string ParamQuantity = "intQuantity";
        public const string ParamSellingUnit = "txtSellingUnit";
        public const string ParamAdPostedDate = "dtInserted";
        public const string ParamDtInserted = "dtInserted";
        public const string ParamState = "txtState";
        public const string ParamDistrict = "txtDistrict";
        public const string ParamMandal = "txtMandal";
        public const string PARAMCHECK = "Check";
        public const string PARAMRETURNVALUE = "IntReturnvalue";
        public const string PARAMKEYFORUSERSETTINGS = "KeyForUserSettings";

        public const string PARAMPHOTO = "photo";
        public const string PARAMINTCOUNT = "intCount";

        public const string PARAMINTCATEGORYID = "intCategoryID";
        public const string PARAMLOCATION = "Location";
        public const string PARAMKEYWORD = "txtKeyWord";

        public const string PARAMORDERBYSELECTEDVALUE="OrderbySelectedValue";

       

        public const string PARAMBuyerName = "BuyerName";
        public const string PARAMBuyerPhoneNumber = "BuyerPhoneNumber";
        public const string PARAMSellerName = "SellerName";
        public const string PARAMSellerPhoneNumber = "SellerPhoneNumber";
        public const string PARAMViewedAdId = "ViewedAdId";




       


        #region ManaBandi

        //Rides
        public const string PARAMTXTPICKUPLOCATION = "txtPickUpLocation";
        public const string PARAMTXTDROPLOCATION = "txtDropLocation";
        public const string PARAMDTCREATED = "dtCreated";
        public const string PARAMDTSCHEDULEDDATE = "dtScheduledDate";
        public const string PARAMDTSCHEDULEDTIME = "txtScheduledTime";
        public const string PARAMINTRIDEID = "intRideID";
        public const string PARAMTXTRIDESTATUS = "txtRideStatus";
        public const string PARAMINTRIDESTATUSID = "intRideStatusID";
        public const string PARAMINTRIDEAMOUNT = "intRideAmount";
        public const string PARAMINTRIDECOMMISSION = "intRideCommision";
        public const string PARAMINTRIDEKM = "intRideKM";

        //Users
        public const string ParamPhoneNumber = "BigIntPhoneNumber";
        public const string ParamtName = "txtName";
        public const string Param = "intUserId";
        public const string PARAMFlgAccountDeleted = "FlgAccountDeleted";
        public const string PARAMOTP = "intOTP";
        public const string PARAMPASSWORD = "txtPassword";
        public const string PARAMbitVerifiedPhoneNumber = "bitVerifiedPhoneNumber";
        public const string PARAMUSERTYPE = "txtUserType";

        //Owners

        public const string PARAMINTOWNERID = "intOwnerID";
        public const string PARAMTXTOWNERNAME = "txtOwnerName";
        public const string PARAMTXTSTATENAME = "txtStateName";
        public const string PARAMDISTRICTNAME = "txtDistrictName";
        public const string PARAMMANDALNAME = "txtMandalName";
        public const string Paramvillage = "txtvillage";
        public const string ParamMailId = "txtMailId";
        public const string PARAMINTSTATEID = "intStateId";
        public const string PARAMDISTRICTID = "intDistrictId";
        public const string PARAMMANDALID = "txtMandalId";
        public const string PARAMINTMANDALID = "intMandalID";
        public const string PARAMINTNUMBEROFVEHICLESPERMODEL = "intNumberOfVehiclesPerModel";
        public const string PARAMTXTPLACE = "txtPlace";

        //Vehicle
        public const string PARAMTXTVEHICLENUMBER="txtVehicleNumber";
        public const string PARAMINTVEHICLETYPEID = "intVehicleTypeId";
        public const string PARAMTXTVEHICLETYPE = "txtVehicleType";
        public const string PARAMTXTVEHICLENAME = "txtVehicleName";
        public const string PARAMTXTRETURNVALUE = "txtReturnValue";
        public const string PARAMINTVEHICLEID = "intVehicleID";
        public const string PARAMFLGONRIDE="flgOnRide";

        //Paging
        public const string PARAMINTPAGENUMBER = "INTPAGENUMBER";
        public const string PARAMINTPAGESIZE = "INTPAGESIZE";
        public const string PARAMINTTOTALPAGECOUNT = "TotalPageCount";


        //Review or contact Us
        public const string PARAMDescription = "Description";
        public const string PARAMSubject = "Subject";
        public const string PARAMReview = "Review";
        public const string PARAMFlgReviewVerified = "FlgReviewVerified";

        //Exception
        public const string ParamControllerName = "txtControllerName";
        public const string ParamActionName = "txtActionName";
        public const string ParamExceptionMessage = "txtExceptionMessage";
        public const string PARAMdtLoggedDate = "dtLoggedDate";


        //Admin
        public const string PARAMINTKMS = "intKMs";
        public const string PARAMINTFINALPRICE = "intFinalPrice";
        public const string PARAINTMDROPORNOT = "intDropOrNot";
        public const string PARAMINTTOTALCOST = "intTotalCost";
        public const string PARAMFLGDELETED = "flgDeleted";
        #endregion
    }
}
