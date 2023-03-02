using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt.Data
{
    internal class DBconnection
    {


        /*
             


         */

        //Test connection, list all users
        public static List<UserModel> GetAllUsers()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT person_name FROM jwe_person", new DynamicParameters());
                return output.ToList();
            }
        }
        

        private static string LoadConnectionString(string id = "Default")
        {
            using (IDbConnection cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings[id].ConnectionString))
            {
       
                return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            };

        }
    }
}
