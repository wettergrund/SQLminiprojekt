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
    }
}
