using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace JungleApi.Web.DataAccess
{
    public sealed class DataAccessMethods
    {
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    dr[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static T GetFieldValue<T>(DataRow dr, string fieldname)
        {
            if (dr[fieldname] == null || dr[fieldname] == DBNull.Value)
                return default;
            else
                return (T)Convert.ChangeType(dr[fieldname], typeof(T));
        }

        public static SqlParameter GetSqlParameter(SqlDbType sqlDbType, string parameterName, string typeName, object value)
        {
            return new SqlParameter
            {
                SqlDbType = sqlDbType,
                ParameterName = parameterName,
                TypeName = typeName,
                Value = value
            };
        }

        public static SqlConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public static SqlCommand GetSqlCommand(string sql, SqlConnection cn)
        {
            return new SqlCommand(sql, cn);
        }
    }
}
