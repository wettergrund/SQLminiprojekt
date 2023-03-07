using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Project
    {

        internal static void AddProject()
        {
            //Add new project

            Console.WriteLine("Ange ett projektnamn");
            string newProject = FormatName(Console.ReadLine());
            if(newProject == null)
            {
                return;
            }

            DBconnection.NewProject(newProject);

        }

        internal static void RenameProject()
        {
            //Rename project
            
            int projectDbID = GetProjectID();
            Console.WriteLine("Ange ett nytt projektnamn");
            string newName = FormatName(Console.ReadLine());
            
            //Stop function if no name is entered
            if(newName == null)
            {
                return;
            }

            //Name change in DB
            DBconnection.RenameProject(newName, projectDbID);
            Console.WriteLine($"Nytt projektnamn är: {newName}");
            Console.ReadLine();

        }

        internal static int GetProjectID(string text = "Ange projekt")
        {
            // Let user select project and return its DB ID 

            List<ProjectModel> projects = DBconnection.GetAllProjects();
            string[] allProjects = ConertToArray(projects);

            int selectedProject = Menu(allProjects, text);

            if (GoBack(selectedProject)) { 
                return -1; 
            }

            int result = DBconnection.GetProjectID(allProjects[selectedProject]);

            return result;
        }

        //private static int SelectProject()
        //{   
        //    // Return DB ID of project

        //    List<ProjectModel> users = DBconnection.GetAllProjects();
        //    string[] listOfProjects = ConertToArray(users);

        //    int projectID = Menu(listOfProjects, "Välj projekt");


        //    if (projectID == -1)
        //    {
        //        return -1;
        //    }
        //    projectID = DBconnection.GetProjectID(listOfProjects[projectID]);

        //    return projectID;
        //}

    }
}
