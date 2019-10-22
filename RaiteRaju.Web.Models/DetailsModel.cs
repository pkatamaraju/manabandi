using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
   public class DetailsModel
    {
       public UserDetailsModel UserDetailsModel { get; set; }
       public List<AdDetailsModel> AdDetails { get; set; }
    }
}
