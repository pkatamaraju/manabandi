using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RaiteRaju.Web.Models
{
    public class UserDetailsModel
    {
        public int intUserId { get; set; }

        public string KeyForUserSettings { get; set; }

        public string txtUserName { get; set; }

        public Int64 txtPhoneNumber { get; set; }

        public string ddlState { get; set; }

        public string ddlDistrict { get; set; }

        public string ddlMandal { get; set; }

        public string txtVillage { get; set; }

        public string txtMailId { get; set; }

        public string txtPassword { get; set; }

        public string OTP { get; set; }

        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public byte[] Image { get; set; }

        public int Fk_UserId { get; set; }

        public int bitVerifiedPhoneNumber { get; set; }

        public int FlgAccountDeleted { get; set; }

        public string UserType {get;set;}
    }
}
