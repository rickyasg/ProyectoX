using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace HamDataTransactions
{
    public class DBTransaction
    {

        public int RowAffected = -1;
        private string strcnn;
        public string ErrorMessage;

        public DBTransaction()
        {
            try
            {
                strcnn = ConfigurationManager.ConnectionStrings["DBErp"].ConnectionString;                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public int GetIdentity(string tablename)
        {
            int ValorIdentity = -1;
            ErrorMessage = string.Empty;

            string sql = string.Format("SELECT IDENT_CURRENT('{0}') as Identidad", tablename);
            DataView dv = GetData(sql);
            if (dv.Count > 0)
            {
                ValorIdentity = Convert.ToInt32(dv[0]["Identidad"]);
            }
            return ValorIdentity;
        }

        public DataView GetData(string query)
        {
            DataTable dt = new DataTable();
            ErrorMessage = string.Empty;
            query = string.Format(DBGlobalization.GetCultureInfo(), "{0}", query);
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    //da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    ExceptionHandler(query, ex);
                }
                finally
                {
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(query, ex);
            }
            return dt.DefaultView;
        }

        public DataTable GetDataView(string viewname)
        {
            string query = string.Format("SELECT * FROM {0}", viewname);//cambiar
            DataTable dt = GetData(query).Table;
            return dt;
        }
        public DataTable GetDataFuncion(string query)
        {
           return GetData(query).Table;
        }

        public int GetFunction(string functionname, List<SqlParameter> parameters)
        {
            ExecStoreProcedure(functionname, parameters);
            return RowAffected;
        }

        public DataRow GetDataRow(string tablename, Dictionary<string, int> parameters)
        {
            string query = string.Format("SELECT * FROM {0} WHERE ", tablename);
            foreach (var item in parameters)
            {
                query += string.Format("({0}={1}) AND ", item.Key, item.Value);
            }
            query += "(1=1)";
            DataTable dt = GetData(query).Table;
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        private void ExceptionHandler(string query, Exception ex)
        {
            ex.Source = ex.Source + "º" + query;
            ErrorMessage = string.Format(ex.Message);
        }

        public void ExecStoreProcedure(string storeProcedure, List<SqlParameter> parameters)
        {
            RowAffected = -1;
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);

                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(storeProcedure, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters.ToArray());
                    RowAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    ExceptionHandler(storeProcedure, ex);
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(storeProcedure, ex);
            }
        }

        public DataTable GetStoreProcedure(string storeProcedure, List<SqlParameter> parameters)
        {
            DataTable dt = new DataTable();
            //RowAffected = -1;
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);

                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(storeProcedure, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters.ToArray());
                    //RowAffected = cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    //return dt.DefaultView;
                }
                catch (SqlException ex)
                {
                    ExceptionHandler(storeProcedure, ex);
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(storeProcedure, ex);
            }
            return dt;
        }

        public DataView GetSystemTables()
        {
            string query = "SELECT name FROM sys.tables ORDER BY name";
            return GetData(query);
        }

        public DataView GetFieldsTable(string tablename)
        {
            string query = string.Format("SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')", tablename);
            return GetData(query);
        }
    }
}
