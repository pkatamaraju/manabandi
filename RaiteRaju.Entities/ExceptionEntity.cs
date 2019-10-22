using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
    public class ExceptionEntity
    {
        public string txtControllerName { get; set; }
        public string txtActionName { get; set; }

        public string txtExceptionMessage { get; set; }

        public string dtLoggedDate { get; set; }

    }
}
