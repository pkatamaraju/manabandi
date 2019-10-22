using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
   public class ReviewModel
    {
        public Int64 PhoneNumber { get; set; }
        
        public string Review { get; set; }
       
        public string DtInserted { get; set; }
        
        public int FlgReviewVerified { get; set; }
    }
}
