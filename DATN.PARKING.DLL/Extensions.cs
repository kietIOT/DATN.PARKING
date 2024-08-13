using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using TCIS.TTOS.Commons;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static NRules.RuleModel.Builders.RuleTransformation;

namespace TCIS.TTOS.EDI.DAL
{

    public static partial class Util
    {

        public static List<T> ExecSQL<T>(this DbContext context, string query, ILogger logger = null)
        {
            return ExecSQL<T>(context, query, logger, null);
        }

        public static List<T> ExecSQL<T>(this DbContext context, string query, params SqlParameter[] sqlParams)
        {
            return ExecSQL<T>(context, query, null, sqlParams);
        }

        /// <summary>
        /// execute Raw SQL queries: Non-model types
        /// https://github.com/aspnet/EntityFrameworkCore/issues/1862
        /// </summary>
        public static List<T> ExecSQL<T>(this DbContext context, string query, ILogger logger, params SqlParameter[] sqlParams)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                if (sqlParams != null) command.Parameters.AddRange(sqlParams);
                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var list = new List<T>();
                    var mapper = new DataReaderMapper<T>(result);

                    while (result.Read())
                    {
                        list.Add(mapper.MapFrom(result));
                    }

                    sw.Stop();
                    logger?.LogInformation($"Executed ({sw.ElapsedMilliseconds}ms)");
                    logger?.LogInformation($"{query}");

                    return list;
                }
            }
        }
        public static List<T> ExecStoredProcedure<T>(this DbContext context, string query, ILogger logger = null)
        {
            return ExecStoredProcedure<T>(context, query, logger, null);
        }

        public static List<T> ExecStoredProcedure<T>(this DbContext context, string query, params OracleParameter[] sqlParams)
        {
            return ExecStoredProcedure<T>(context, query, null, sqlParams);
        }

        public static List<T> ExecStoredProcedure<T>(this DbContext context, string query, ILogger logger, params OracleParameter[] sqlParams)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;
                if (sqlParams != null) command.Parameters.AddRange(sqlParams);
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var list = new List<T>();
                    var mapper = new DataReaderMapper<T>(result);
                    while (result.Read())
                    {
                        list.Add(mapper.MapFrom(result));
                    }
                    sw.Stop();
                    logger?.LogInformation($"Executed ({sw.ElapsedMilliseconds}ms)");
                    logger?.LogInformation($"{query}");
                    return list.RemoveWhiteSpaceForList();
                }
                return new List<T>();
            }
        }

        public static DataTable ExecToDataTable(this DbContext context,  string sqlQuery, params DbParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            DbConnection connection = context.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;

            //Sample Using
            /*stored procedure*/
            //DataTable searchUser = db.DataTable(
            //    "EXEC sp_test_role @name = @paramName",
            //    new OracleParameter("paramName", SqlDbType.NVarChar) { Value = "sa" }
            //);

            /*select query*/
            //DataTable likeUser = db.DataTable(
            //    "SELECT * FROM [dbo].[tbl_test_role] WHERE [name] LIKE '%' + @paramName +'%'",
            //    new OracleParameter("paramName", SqlDbType.NVarChar) { Value = "a" }
            //);
        }
        public static List<string> SplitString(this string str, char[] chars)
        {
            return str.Split(chars, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(x => x.Replace("\r", "").Replace("\t", "").TrimEx())
                                   .Where(x => !string.IsNullOrEmpty(x.Trim()))
                                   .Distinct()
            .ToList();
        }

        public static int GetNextValSequence(this DbContext context, string sequenceName)
        {
            string sql = $"SELECT {sequenceName}.NEXTVAL FROM DUAL";

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                context.Database.OpenConnection();

                object result = command.ExecuteScalar();
                int nextSequenceValue = Convert.ToInt32(result);
                return nextSequenceValue;
            }
        }
        public static string ToEDOCustomerName(this string customerName) => customerName.TrimEx().Replace("\r\n", "").Replace("\n", "").Replace("\t", "").DeleteSingleQuote()
                                                                           .SubstringEx(0, GlobalSettings.MaxLengthConsignee).TrimEx();
        public static string ToEDOSecureCode(this string secureCode) => secureCode.TrimEx().Replace("\r\n", "").Replace("\n", "").DeleteSingleQuote();
    }

}
