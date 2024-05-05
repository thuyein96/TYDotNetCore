using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters.Length > 0 && parameters is not null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                } 

                //cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());
                
                //var parameterArray = parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
                //cmd.Parameters.AddRange(parameterArray);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt); // C# object to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; // json to C# object
            return lst;
        }

        public T FirstOrDefaultQuery<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters.Length > 0 && parameters is not null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                }

                //cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());

                //var parameterArray = parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
                //cmd.Parameters.AddRange(parameterArray);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt); // C# object to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; // json to C# object
            return lst[0];
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if (parameters.Length > 0 && parameters is not null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                }
            }
            int result = command.ExecuteNonQuery();

            connection.Close();
            
            return result;
        }
    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
