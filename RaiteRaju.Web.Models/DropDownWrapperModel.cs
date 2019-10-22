using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
   public class DropDownWrapperModel
    {
       public List<GDictionaryModel> District { get; set; }
       public List<GDictionaryModel> Mandal { get; set; }
    }
}
