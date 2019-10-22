using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace RaiteRaju.ApplicationUtility
{
   public class ConnectionManager
    {
       private SqlConnection connection = new SqlConnection();
       private SqlDataAdapter dataAaptor = new SqlDataAdapter();
       private SqlCommand command = new SqlCommand();
       private DataSet dataset = new DataSet();

       private Database _RaiteRajuDataBase;

       public ConnectionManager()
       {
           _RaiteRajuDataBase = DatabaseFactory.CreateDatabase(ApplicationConstants.RaiteRajuDBInstance);
       }
       public ConnectionManager(DatabaseToConnect databaseInstance)
       {
           try {
               if (databaseInstance == DatabaseToConnect.RaiteRajuDefaultInstance)
               {
                   _RaiteRajuDataBase = DatabaseFactory.CreateDatabase(ApplicationConstants.RaiteRajuDBInstance);
               }
           }
           catch(Exception ee)
           {
               throw ee;
           }
       }
       public Database RaiteRajuDBInstance
       {
           get
           {
               return _RaiteRajuDataBase;
           }
       }
       public enum DatabaseToConnect
       {
           RaiteRajuDefaultInstance
       }
       }
}
