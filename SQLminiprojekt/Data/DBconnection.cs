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

        public static void NewUser(string newUserName)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"INSERT INTO jwe_person (person_name) VALUES ('{newUserName}');", new DynamicParameters());
            }
        }


        public static List<ProjectModel> GetAllProjects()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>($"SELECT project_name FROM jwe_project", new DynamicParameters());
                return output.ToList();
            }
        }



        public static int GetUserID(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT id FROM jwe_person WHERE person_name = '{name}'", new DynamicParameters());
                return output.Last().Id;
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
