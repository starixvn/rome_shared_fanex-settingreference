using Fanex.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fanex.PTSetting.BettypeReference.Services
{
    public static class ObjectDbExtensions
    {
        public static IEnumerable<T> QueryOnSiteDB<T>(this ObjectDb objdb, Hashtable parameters, string dbServer)
        {
            string oldConnectionString = objdb.DbSetting.ConnectionString;
            objdb.DbSetting.ConnectionString = BuildConnectionString(dbServer, oldConnectionString);            
            
            try
            {
                return objdb.Query<T>(parameters);
            }
            finally
            {
                objdb.DbSetting.ConnectionString = oldConnectionString;
            }
        }        

        private static string BuildConnectionString(string serverIP, string connectionString)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            if (!string.IsNullOrWhiteSpace(serverIP))
            {
                sqlConnectionStringBuilder.DataSource = serverIP;
            }

            return sqlConnectionStringBuilder.ToString();
        }
    }
}
