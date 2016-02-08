using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace serverEngine.Data
{
    public class Database
    {
        public static Database Instance => new Database();


        private readonly string _connectionString;
        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Database()
        {
            _connectionString = File.ReadAllText("connectionstring.setting");
        }

        public T ExecuteScalar<T>(string queryString, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddRange(parameters);
                command.Connection.Open();
                return (T)command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Voert een SQL commando uit en haalt het resultaat op
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <returns>Returnd een lijst met resultaten uit database</returns>
        public IEnumerable<Dictionary<string, object>> Query(string queryString, params SqlParameter[] parameters)
        {
            var results = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddRange(parameters);

                    using (var dataAdapter = new SqlDataAdapter(command))
                        dataAdapter.Fill(results);

                    foreach (DataRow row in results.Rows)
                    {
                        var items = new Dictionary<string, object>();
                        foreach (var column in row.Table.Columns.Cast<DataColumn>())
                        {
                            items[column.ColumnName] = row[column.ColumnName];
                        }

                        yield return items;

                    }
                }
            }


        }

        public int ExecuteNonQuery(string queryString, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(
               _connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddRange(parameters);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}
