using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RaiteRaju.Web.Models
{
   public class AdDetailsModel
    {
       public int AdID { get; set; }
       //[StringLength(50, ErrorMessage = "Max 50 characters")]
       //[Required(ErrorMessage = "Please Enter Title")]
       //[RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
       public string txtAddTitle { get; set; }
       public string Category { get; set; }
       public Int32 intCategoryId { get; set; }
       public string txtSubCategoryName { get; set; }
    
       public string txtAdDescription { get; set; }
       //[Required(ErrorMessage = "Please enter price")]
       //[RegularExpression(@"^([0-9]{1-10})$", ErrorMessage = "Only number are allowed.")]
       public Int32 txtPrice { get; set; }
       //[Required(ErrorMessage = "Please enter Quantity.")]
       //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Only number are allowed.")]
       public Int32 txtQuantity { get; set; }
       public Int32 UserID { get; set; }
        public string SellingUnit { get; set; }
        public Int64 MobileNuber { get; set; }
        public int ImageId { get; set; }
        public byte[] Image { get; set; }

        public string ImageData { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string PostedDate { get; set; }
       
    }
}
