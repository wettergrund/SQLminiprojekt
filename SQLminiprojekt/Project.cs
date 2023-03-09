using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Project
    {
        internal static void ModifyProject()
        {
            // Options to modify existing project

            string[] ProjectMenu = {
                "Lägg till projekt", // --> AddProject()
                "Byt namn på projekt " // --> RenameProject()
            };

            bool showMenu = true;

            while (showMenu)
            {
                int selectedItem = Menu(ProjectMenu, "Projektmeny");
                switch (selectedItem)
                {
                    case -1:
                        break;
                    case 0:
                        AddProject();

                        break;
                    case 1:
                        RenameProject();
                        break;
                }
                showMenu = false;

            }
        }

        internal static void AddProject()
        {
            
            //Let user enter project name
            Console.WriteLine("Ange ett projektnamn");
            string projectName = FormatName(Console.ReadLine());

            //Stop function if no name is entered
            if (projectName == null)
            {
                return;
            }

            //Update DB
            DBconnection.NewProject(projectName);

        }

        internal static void RenameProject()
        {
            //User select project to rename (Return DB ID)
            int projectID = GetProjectID();
            //Stop function if no name is entered
            if (GoBack(projectID))
            {
                return;
            }

            Console.WriteLine("Ange ett nytt projektnamn");
            string newProjectName = FormatName(Console.ReadLine());
            
            //Stop function if no name is entered
            if(newProjectName == null)
            {
                return;
            }

            //Name change in DB
            DBconnection.RenameProject(newProjectName, projectID);
            Console.WriteLine($"Nytt projektnamn är: {newProjectName}");
            Console.ReadLine();

        }

        internal static int GetProjectID(string text = "Ange projekt")
        {
            // Let user select project and return its DB ID 
        
            List<ProjectModel> listOfProjects = DBconnection.GetAllProjects();
            string[] projectsArray = ConertToArray(listOfProjects); //List to array for menu

            int selectedProject = Menu(projectsArray, text);

            if (GoBack(selectedProject)) { 
                return -1; 
            }

            //Get ID from DB
            int result = DBconnection.GetProjectID(projectsArray[selectedProject]);

            return result;
        }



    }
}
