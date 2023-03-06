using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Report
    {

        internal static int Select()
        {
            // Return DB ID of project

            List<ReportModel> projects = DBconnection.GetAllReports();

            string[] usersString = new string[projects.Count];
            string[] projectString = new string[projects.Count];
            string[] combinedStrings = new string[projects.Count];


            for (int i = 0; i < projects.Count; i++)
            {
                usersString[i] = DBconnection.GetUserName(projects[i].Person_Id);
                projectString[i] = DBconnection.GetProjectName(projects[i].Project_Id);

                combinedStrings[i] = $"{usersString[i]} {projectString[i]} {projects[i].hours}";

            }

            int test = Menu(combinedStrings, "Välj rapport att ändra");


            //for (int i = 0; i < usersString.Length; i++)
            //{
            //    Console.WriteLine(usersString[i] + " " + projectString[i] + " Tid: "+ projects[i].hours);
            //}

            string[] reportMenu = {
                $"Ändra person ({usersString[test]})",
                $"Ändra tid ({projects[test].hours})",
                $"Ändra projekt({projectString[test]})"
            };

            int reportMenuChoice = Menu(reportMenu);

            switch (reportMenuChoice)
            {
                case 0:
                    Console.WriteLine();
                    // Change person
                    break;
                case 1:
                    Console.WriteLine("Ange en ny tid");
                    int newTime = int.Parse(Console.ReadLine());
                    // Change hour
                    break;
                case 2:
                    Console.WriteLine("Ange korrekt projekt");
                    //Project.Rename(Console.ReadLine(), test);
                    // Change project
                    break;
            }


            Console.WriteLine(test);


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
