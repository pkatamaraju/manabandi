using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RaiteRaju.ApplicationUtility
{
    public class DBAccessHelper
    {

        public static void AddInputParametersWithValues(DbCommand command, string paramName, DbType dataTaype, object value)
        {
            AddInputParameterToCommand(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, command, paramName, dataTaype, value);
        }
        public static DbCommand GetDBCommand(string ProcedureName)
        {
            return GetDatabaseCommand(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, ProcedureName);
        }
        public static IDataReader ExecuteReader(DbCommand dbCommand)
        {
            return GetExecuteReader(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, dbCommand, null, null);
        }
        public static IDataReader ExecuteReader(DbCommand dbCommand,string stringName,out object outputparam)
        {
            return GetExecuteReader(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, dbCommand, stringName,out outputparam,null,null);
        }
        public static IDataReader ExecuteReader(string StoredProcedureName, params object[] parameterValues)
        {
            return GetExecuteReader(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, null, StoredProcedureName, parameterValues);
        }
        public static object ExecuteScalar(DbCommand command)
        {
            return GetExecuteScalar(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, command, null, null);
        }
        public static object ExecuteScalar(string StoredProcedureName, params object[] parameterValues)
        {
            return GetExecuteScalar(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, null, StoredProcedureName, parameterValues);
        }


        public static int ExecuteNonQuery(DbCommand dbCommand)
        {
            return RunExecuteNonQuery(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance,null, dbCommand, null, null);
        }
        public static int ExecuteNonQuery(DbCommand dbCommand, DbTransaction transaction)
        {
            return RunExecuteNonQuery(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, transaction, dbCommand, null, null);
        }
        public static int ExecuteNonQuery(string StoredProcedureName, params object[] parameterValues)
        {
            return RunExecuteNonQuery(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, null, null, StoredProcedureName, parameterValues);

        }
        public static int ExecuteNonQuery(DbTransaction transaction, string StoredProcedureName, params object[] parameterValues)
        {
            return RunExecuteNonQuery(ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance, transaction, null, StoredProcedureName, parameterValues);

        }
        #region Support for multiple DATABASES
        public static void AddInputParametersWithValues(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand dbcommand, string paramName, DbType dataTaype, int value)
        {
            AddInputParameterToCommand(databaseToConnect, dbcommand, paramName, dataTaype, value);
        }
        public static void AddOutputParameter(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand dbcommand, string paramName, DbType dataTaype, int size,ref IDataParameter OUTPUT)
        {
            AddOutputParameterToCommand(databaseToConnect, dbcommand, paramName, dataTaype, size,ref OUTPUT);
        }
        public static DbCommand GetDBCommand(ConnectionManager.DatabaseToConnect databaseToConnect, string spName)
        {
            return GetDatabaseCommand(databaseToConnect, spName);
        }
        public static IDataReader ExecuteReader(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand dbcommand)
        {
            return GetExecuteReader(databaseToConnect, dbcommand, null, null);
        }
        public static int ExecuteNonQuery(ConnectionManager.DatabaseToConnect databaseToConnect, DbTransaction transaction, string StoredProcedureName, params object[] parameterValues)
        {
            return RunExecuteNonQuery(databaseToConnect, transaction, null, StoredProcedureName, parameterValues);

        }
        #endregion



        private static void AddInputParameterToCommand(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand dbCommand, string paramName, DbType dataType, object value)
        {
            ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
            Database dataBase = connectionManager.RaiteRajuDBInstance;
            dataBase.AddInParameter(dbCommand, ApplicationConstants.SQLPARAMDELIMETER + paramName, dataType, value);

        }
        private static void AddOutputParameterToCommand(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand dbCommand, string paramName, DbType dataType, int size,ref IDataParameter OUTPUT)
        {
            ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
            Database dataBase = connectionManager.RaiteRajuDBInstance;
           // dataBase.AddOutParameter(dbCommand, ApplicationConstants.SQLPARAMDELIMETER + paramName, dataType, size);
            SqlParameter OUT = new SqlParameter(ApplicationConstants.SQLPARAMDELIMETER+paramName,dataType);
            OUT.DbType = DbType.Int32;
            OUT.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(OUT);
            OUTPUT = OUT;
            //return OUT;
        }
        public static DbCommand GetDatabaseCommand(ConnectionManager.DatabaseToConnect databaseToConnect, string procName)
        {
               DbCommand dbCommand = null;
                string spName = null;
                if (databaseToConnect == ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance)
                {
                    spName = ConfigReader.RaiteRajuDBSchema + procName;
                    ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
                    Database dataBase = connectionManager.RaiteRajuDBInstance;
                    dbCommand = dataBase.GetStoredProcCommand(spName);
                }
                return dbCommand;
        }
         private static IDataReader GetExecuteReader(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand command, string paramName, out object outputparam ,string storedProcudureName, params object[] parameterValues)
        {
            int number = 0;
            IDataReader IDataReaderData = null;
            if (databaseToConnect == ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance)
            {
                    string spName = ConfigReader.RaiteRajuDBSchema + storedProcudureName;
                    ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
                    Database dataBase = connectionManager.RaiteRajuDBInstance;
                    if (command == null)
                    {
                        IDataReaderData = dataBase.ExecuteReader(spName, parameterValues);
                        outputparam = null;
                    }
                    else
                    {
                        using (command)
                        {
                            IDataReaderData = dataBase.ExecuteReader(command);
                            number = Convert.ToInt32(dataBase.GetParameterValue(command, ApplicationConstants.SQLPARAMDELIMETER + paramName));
                        }
                    }
            }
            outputparam = number;
            return IDataReaderData;
        }
        private static IDataReader GetExecuteReader(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand command, string storedProcudureName, params object[] parameterValues)
        {
            IDataReader IDataReaderData = null;
            if (databaseToConnect == ConnectionManager.DatabaseToConnect.RaiteRajuDefaultInstance)
            {
                {
                    string spName = ConfigReader.RaiteRajuDBSchema + storedProcudureName;
                    ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
                    Database dataBase = connectionManager.RaiteRajuDBInstance;
                    if (command == null)
                    {
                        IDataReaderData = dataBase.ExecuteReader(spName, parameterValues);
                    }
                    else
                    {
                        using (command)
                        {
                            IDataReaderData = dataBase.ExecuteReader(command);
                        }
                    }
                }
            }
            return IDataReaderData;
        }
        private static IDataReader GetSQLExecuteReader(string storedProcedureName)
        {
            IDataReader dr = null;
            string spName = ConfigReader.RaiteRajuDBSchema + storedProcedureName;
            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = ConfigReader.RaiteRajuDBCode;
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = spName;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    return dr;
                }
            }
        }

        private static object GetExecuteScalar(ConnectionManager.DatabaseToConnect databaseToConnect, DbCommand command, string storedProcedureName, params object[] parameterValues)
        {
            object scalarData = null;
            string spName = ConfigReader.RaiteRajuDBSchema + storedProcedureName;
            ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
            Database dataBase = connectionManager.RaiteRajuDBInstance;
            if (command == null)
            {
                scalarData = dataBase.ExecuteScalar(spName, parameterValues);
            }
            else
            {
                using (command)
                {
                    scalarData = dataBase.ExecuteScalar(command);
                }
            }
            return scalarData;

        }
        private static int RunExecuteNonQuery(ConnectionManager.DatabaseToConnect databaseToConnect, DbTransaction transaction, DbCommand command, string storedProcedureName, params object[] parameterValues)
        {
            int RowsAffected = 0;
            string spName = ConfigReader.RaiteRajuDBSchema + storedProcedureName;
            ConnectionManager connectionManager = new ConnectionManager(databaseToConnect);
            Database dataBase = connectionManager.RaiteRajuDBInstance;
            if (command == null)
            {
                if (transaction == null)
                {
                    RowsAffected = dataBase.ExecuteNonQuery(spName, parameterValues);
                }
                else
                {
                    RowsAffected = dataBase.ExecuteNonQuery(transaction, spName, parameterValues);
                }
            }
            else
            {
                if (transaction == null)
                {
                    using (command)
                    {
                        RowsAffected = dataBase.ExecuteNonQuery(command);
                    }
                }
                else
                {
                    using (command)
                    {
                        RowsAffected = dataBase.ExecuteNonQuery(command, transaction);
                    }
                }
            }
            return RowsAffected;
        }
    }
}
