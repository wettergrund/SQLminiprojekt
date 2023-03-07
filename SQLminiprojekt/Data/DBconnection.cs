using Npgsql;
using Dapper;
using System.Configuration;
using System.Data;


namespace SQLminiprojekt.Data
{
    
    internal class DBconnection
    {
        //Users
        public static List<UserModel> GetAllUsers()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT person_name FROM jwe_person", new DynamicParameters());
                return output.ToList();
            }
        }
        public static int GetUserID(string personName)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT id FROM jwe_person WHERE person_name = '{personName}'", new DynamicParameters());
                return output.Last().Id;
            }
        }
        public static string GetUserName(int id)
                {
                    using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
                    {
                        var output = cnn.Query<UserModel>($"SELECT person_name FROM jwe_person WHERE id = '{id}'", new DynamicParameters());
                        return output.Last().Person_Name;
                    }
                }
        public static void NewUser(string newUserName)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"INSERT INTO jwe_person (person_name) VALUES ('{newUserName}')", new DynamicParameters());
            }
        }
        public static void RenameUser(string newName, int id) {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Query<UserModel>($"UPDATE jwe_person SET person_name='{newName}' WHERE jwe_person.id = {id}", new DynamicParameters());
            }

        }

      
        //Projects
        public static List<ProjectModel> GetAllProjects()
                {
                    using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
                    {
                        var output = cnn.Query<ProjectModel>($"SELECT project_name FROM jwe_project", new DynamicParameters());
                        return output.ToList();
                    }
                }
        public static int GetProjectID(string projectName)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>($"SELECT id FROM jwe_project WHERE project_name = '{projectName}'", new DynamicParameters());
                return output.Last().Id;
            }
        }
        public static string GetProjectName(int id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>($"SELECT project_name FROM jwe_project WHERE id = '{id}'", new DynamicParameters());
                return output.Last().Project_Name;
            }
        }
        public static void NewProject(string newProjectName)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"INSERT INTO jwe_project (project_name) VALUES ('{newProjectName}')", new DynamicParameters());
            }
        }
        public static void RenameProject(string newName, int id)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Query<UserModel>($"UPDATE jwe_project SET project_name='{newName}' WHERE jwe_project.id = {id}", new DynamicParameters());
            }

        }


        //Reports

        public static List<ReportModel> GetLastReports()
        {
            // Return last 10 reports
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ReportModel>($"SELECT * FROM jwe_project_person ORDER BY id DESC LIMIT 10", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void NewTimeReport(int projectId, int personId, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"INSERT INTO jwe_project_person (project_id, person_id, hours) VALUES ({projectId},{personId},{hours})", new DynamicParameters());
            }
        }
        public static void UpdateReport(string fieldToUpdate, string newData, int id)
        {
          
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Query<ReportModel>($"UPDATE jwe_project_person SET {fieldToUpdate}={newData} WHERE id={id}", new DynamicParameters());
            }
        }
        public static void RemoveReport(int toDelete)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"DELETE FROM jwe_project_person WHERE id = {toDelete}", new DynamicParameters());
            }
        }


 
        //Connection to DB
        private static string LoadConnectionString(string id = "Default")
        {
            using (IDbConnection cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings[id].ConnectionString))
            {
       
                return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            };

        }
    }
}
