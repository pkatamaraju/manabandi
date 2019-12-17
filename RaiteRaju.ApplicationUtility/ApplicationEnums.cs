using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace RaiteRaju.ApplicationUtility
{

    public enum StateList
    {
        [Display(Name = "Andhra Pradesh")]
        AndhraPradesh = 1,
        //[Display(Name = "Arunachal Pradesh")]
        //ArunachalPradesh = 2,
        //[Display(Name = "Assam")]
        //Assam = 3,
        //[Display(Name = "Bihar")]
        //Bihar = 4,
        //[Display(Name = "Chhattisgarh")]
        //Chhattisgarh = 5,
        //[Display(Name = "Goa")]
        //Goa = 6,
        //[Display(Name = "Gujarat")]
        //Gujarat = 7,
        //[Display(Name = "Haryana")]
        //Haryana = 8,
        //[Display(Name = "Himachal Pradesh")]
        //HimachalPradesh = 9,
        //[Display(Name = "Jammu and Kashmir")]
        //JammuandKashmir = 10,
        //[Display(Name = "Jharkhand")]
        //Jharkhand = 11,
        //[Display(Name = "Karnataka")]
        //Karnataka = 12,
        //[Display(Name = "Kerala")]
        //Kerala = 13,
        //[Display(Name = "Madya Pradesh")]
        //MadyaPradesh = 14,
        //[Display(Name = "Maharashtra")]
        //Maharashtra = 15,
        //[Display(Name = "Manipur")]
        //Manipur = 16,
        //[Display(Name = "Meghalaya")]
        //Meghalaya = 17,
        //[Display(Name = "Mizoram")]
        //Mizoram = 18,
        //[Display(Name = "Nagaland")]
        //Nagaland = 19,
        //[Display(Name = "Orissa")]
        //Orissa = 20,
        //[Display(Name = "Punjab")]
        //Punjab = 21,
        //[Display(Name = "Rajasthan")]
        //Rajasthan = 22,
        //[Display(Name = "Sikkim")]
        //Sikkim = 23,
        //[Display(Name = "Tamil Nadu")]
        //TamilNadu = 24,
        [Display(Name = "Telangana")]
        Telangana = 25,
        //[Display(Name = "Tripura")]
        //Tripura = 26,
        //[Display(Name = "Uttar Pradesh")]
        //UttarPradesh = 27,
        //[Display(Name = "Uttarakhand")]
        //Uttarakhand = 28,
        //[Display(Name = "West Bengal")]
        //WestBengal = 29

    }

    public enum UserSettings{
        [Display(Name = "DETAILS")]
        DETAILS = 1,
        [Display(Name = "PHONENUMBER")]
        PHONENUMBER = 2,
        [Display(Name = "PASSWORD")]
        PASSWORD = 3
    }
    
    public enum VehicleType
    {
        
        [Display(Name = "Mini Truck")]
        DETAILS = 1,
        [Display(Name = "Mini Auto")]
        MiniAuto = 2,
        [Display(Name = "Appi Auto")]
        AppiAuto = 3,
        [Display(Name = "Car (4 seater)")]
        Car4Seater = 4,
        [Display(Name = "Car (7 seater)")]
        Car7Seater = 5,
        [Display(Name = "Car (14 seater)")]
        Car14Seater = 6,
        [Display(Name = "Mini Bus")]
        MiniBus = 7,
        [Display(Name = "Bus")]
        Bus = 8,
        [Display(Name = "Lorry")]
        Lorry = 9
    }
    public enum UserType
    {
        user=1,owner=2,driver=3
    }
}
