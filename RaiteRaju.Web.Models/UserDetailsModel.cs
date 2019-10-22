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

        
        
        //[StringLength(50, ErrorMessage = "Max 50 characters")]
        //[Required(ErrorMessage = "Please Enter Name.")]
        //[RegularExpression(@"^[a-zA-Z0-9 .]+$", ErrorMessage = "Special characters are not allowed for Name")]
        public string txtUserName { get; set; }

        //[Required(ErrorMessage = "Mobile Number is required.")]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public Int64 txtPhoneNumber { get; set; }

        public string ddlState { get; set; }
        public string ddlDistrict { get; set; }
        public string ddlMandal { get; set; }

        //[StringLength(50, ErrorMessage = "Max 50 characters")]
        //[Required(ErrorMessage = "Please Enter Village.")]
        //[RegularExpression(@"^[a-zA-Z0-9 .]+$", ErrorMessage = "Special characters are not allowed for village")]
        public string txtVillage { get; set; }

        //[StringLength(50, ErrorMessage = "Max 50 characters")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string txtMailId { get; set; }

        //[StringLength(50, ErrorMessage = "Max 50 characters")]
        //[Required(ErrorMessage = "Please Enter Password")]
        //[RegularExpression(@"^[a-zA-Z0-9 .]+$", ErrorMessage = "Special characters are not allowed for password")]
        public string txtPassword { get; set; }

        //[Required(ErrorMessage = "Please Enter OTP")]
        //[RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid OTP.")]
        public string OTP { get; set; }

        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public int Fk_UserId { get; set; }

        public int bitVerifiedPhoneNumber { get; set; }

        public int FlgAccountDeleted { get; set; }
    }
}
