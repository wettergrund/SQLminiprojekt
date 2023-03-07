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


        internal static void Rename(string? newName = "", int projectDbID = -1)
        {
            if(projectDbID == -1 && newName == "") { 
                projectDbID = SelectProject();
                Console.WriteLine("Ange ett nytt namn");
                newName = Console.ReadLine();
            }

            

            DBconnection.RenameProject(newName, projectDbID);
            Console.WriteLine($"Nytt namn är: {newName}");
            Console.ReadLine();


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

        internal static int GetProjectID(string text = "Ange projekt")
        {
            List<ProjectModel> projects = DBconnection.GetAllProjects();
            string[] allProjects = ConertToArray(projects);

            int selectedProject = Menu(allProjects, text);
            if (selectedProject == -1) { return -1; }

            int result = DBconnection.GetProjectID(allProjects[selectedProject]);

            return result;
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

        

        




    }
}
