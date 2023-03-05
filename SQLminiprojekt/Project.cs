using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Project
    {

        internal static void Add()
        {
            Console.WriteLine("Ange ett projektnamn");
            string newProject = Console.ReadLine();

            DBconnection.NewProject(newProject);

        }


        internal static void Modify()
        {
            int projectDbID = SelectProject();

            Console.WriteLine("Ange ett nytt namn");
            string? newName = Console.ReadLine();

            DBconnection.RenameProject(newName, projectDbID);


        }


        // Remove not needed?
        internal static void Remove()
        {
            Console.WriteLine("Välj användare att ta bort"); 

            List<ProjectModel> allProjects = DBconnection.GetAllProjects();
            string[] arrayOfProjects = ConertToArray(allProjects);

            int projectToRemove = Menu(arrayOfProjects);


            if (projectToRemove == -1) {
                return;
            }

            // Get ID of user
            int idOfProject = DBconnection.GetUserID(arrayOfProjects[projectToRemove]);

            Console.WriteLine($"Id är: {idOfProject}");
            Console.ReadLine();
            DBconnection.RemoveUser(idOfProject);


        }


        private static int SelectProject()
        {   
            // Return DB ID of project

            List<ProjectModel> users = DBconnection.GetAllProjects();
            string[] listOfProjects = ConertToArray(users);

            int projectID = Menu(listOfProjects, "Välj projekt");


            if (projectID == -1)
            {
                return -1;
            }
            projectID = DBconnection.GetProjectID(listOfProjects[projectID]);

            return projectID;
        }

        internal static int SelectReport()
        {
            // Return DB ID of project

            List<ReportModel> projects = DBconnection.GetAllReports();

            string[] usersString = new string[projects.Count];
            string[] projectString = new string[projects.Count];


            for (int i = 0; i < projects.Count; i++)
            {
                usersString[i] = DBconnection.GetUserName(projects[i].Person_Id);
                projectString[i] = DBconnection.GetProjectName(projects[i].Project_Id);

            }

            for (int i = 0; i < usersString.Length; i++)
            {
                Console.WriteLine(usersString[i] + " " + projectString[i] + " Tid: "+ projects[i].hours);
            }

            Console.ReadLine();
            // AttributeTargets name by id
            //int projectID = Menu(listOfProjects, "Välj projekt");


            //if (projectID == -1)
            //{
            //    return -1;
            //}
            //projectID = DBconnection.GetProjectID(listOfProjects[projectID]);

            return -1;
        }


    }
}
