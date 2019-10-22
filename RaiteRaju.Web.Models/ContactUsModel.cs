using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
 public class ContactUsModel
    {
        public Int64 PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string dtInserted { get; set; }
    }
}
