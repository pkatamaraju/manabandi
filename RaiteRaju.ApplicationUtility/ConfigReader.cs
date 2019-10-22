using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.ApplicationUtility
{
    public class ConfigReader
    {

        public static string RaiteRajuDBCode = ConfigurationManager.ConnectionStrings["RaiteRajuConnection"].ToString();
        public static string RaiteRajuDBSchema = ConfigurationManager.AppSettings["RaiteRajuSchemadbo"].ToString();


    }
   
}

