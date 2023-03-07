using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Report
    {
        internal static void ModifyReport()
        {
            // Return DB ID of project

            List<ReportModel> reports = DBconnection.GetAllReports();

            string[] usersString = new string[reports.Count];
            string[] projectString = new string[reports.Count];

            string[] combinedStrings = new string[reports.Count];


            for (int i = 0; i < reports.Count; i++)
            {
                usersString[i] = DBconnection.GetUserName(reports[i].Person_Id);
                projectString[i] = DBconnection.GetProjectName(reports[i].Project_Id);

                combinedStrings[i] = $"{usersString[i]} {projectString[i]} {reports[i].hours}";
            }

            int reportIndex = Menu(combinedStrings, "Välj rapport att ändra");



            if (reportIndex == -1) { return; }

            string reportUser = usersString[reportIndex];
            int reportHours = reports[reportIndex].hours;
            string reportProject =projectString[reportIndex];



            string[] reportMenu = {
                $"Ändra person ({reportUser})",
                $"Ändra tid ({reportHours})",
                $"Ändra projekt({reportProject})",
                $"Ta bort rapport"
            };

            int reportMenuChoice = Menu(reportMenu);

            int idOfProject = reports[reportIndex].Id;


            switch (reportMenuChoice)
            {
                case 0:

                    int newUserDbId = User.SelectUser("Välj korrekt person");

                    if (newUserDbId == -1)
                    {
                        break;
                    }

                    DBconnection.UpdateReport("person_id", $"{newUserDbId}", idOfProject);
                    // Change person
                    break;
                case 1:
                    // Change hour
                    int newTime = GetHours();

                    if (newTime == -1)
                    {
                        break;
                    }
                    if(newTime == 0)
                    {
                        RemoveReport(idOfProject);
                    }

                    DBconnection.UpdateReport("hours", $"{newTime}", idOfProject);
                    break;
                case 2:
                    // Change project
                    Console.ReadLine();
                    int projectDbId = Project.GetProjectID("Ange korrekt projekt");
                    DBconnection.UpdateReport("project_id", $"{projectDbId}", idOfProject);
                    break;
                case 3:
                    RemoveReport(idOfProject);
                    break;
            }
        }

        internal static void RemoveReport(int idTorRemove)
        {
            string[] confirm = { "Nej", "Ja" };
            int confirmChoice = Menu(confirm, $"Är du säker på att du vill ta bort rapporten? [ID: {idTorRemove} ]");
            switch (confirmChoice)
            {
                case 0:
                case -1:
                    break;
                case 1:
                    DBconnection.RemoveReport(idTorRemove);
                    break;
            }
        }
    }
}
