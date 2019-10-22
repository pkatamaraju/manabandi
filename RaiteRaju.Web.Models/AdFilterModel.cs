using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
    public class AdFilterModel
    {
        public Int32 CategoryId { get; set; }

        public string txtState { get; set; }

        public string txtDistrict { get; set; }

        public string txtMandal { get; set; }

        public string TxtKeyWord { get; set; }
        public Int32 INTPAGENUMBER { get; set; }

        public Int32 INTPAGESIZE { get; set; }
        public Int32 SortValue { get; set; }
    }

}
