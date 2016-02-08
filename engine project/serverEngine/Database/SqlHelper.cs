using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverEngine.Data
{
    public static class SqlHelper
    {
        public static SqlParameter ToSqlParameter<T>(this T objectToSql, string name, params object[] parameters)
        {
            if (parameters.Length > 0)
                name = String.Format(name, parameters);
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            return objectToSql == null ? new SqlParameter(name, DBNull.Value) : new SqlParameter(name, objectToSql);
        }

        public static SqlParameter ToSqlParameter<T>(this T? objectToSql, string name, params object[] parameters) where T : struct
        {
            if (parameters.Length > 0)
                name = String.Format(name, parameters);
            return !objectToSql.HasValue ? new SqlParameter(name, DBNull.Value) : new SqlParameter(name, objectToSql.Value);
        }
    }
}
