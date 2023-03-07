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

    }
}
