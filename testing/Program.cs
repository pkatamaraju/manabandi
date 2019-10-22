using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RaiteRaju.ApplicationUtility;
namespace testing
{
    class Program
    {
        static void Main()
        {
            Utility obj = new Utility();
          Console.WriteLine(obj.Encrypt("SOFTWARE"));
          Console.WriteLine(obj.Decrypt(obj.Encrypt("SOFTWARE")));
          Console.ReadLine();
            


          

     
        }
    }
}
