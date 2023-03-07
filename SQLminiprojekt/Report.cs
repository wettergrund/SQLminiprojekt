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
            

            //List all reports and let user select the one to update
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

            if (GoBack(reportIndex)) { 
                return; 
            }


            //Store info about selected report.
            int idOfProject = reports[reportIndex].Id;
            int reportHours = reports[reportIndex].hours;
            string reportUser = usersString[reportIndex];
            string reportProject = projectString[reportIndex];


            //Give user options
            string[] reportMenu = {
                $"Ändra person ({reportUser})",
                $"Ändra tid ({reportHours})",
                $"Ändra projekt({reportProject})",
                $"Ta bort rapport"
            };

            int reportMenuChoice = Menu(reportMenu);



            switch (reportMenuChoice)
            {
                case 0:
                    // Change person
                    ChangeReportUser(idOfProject);

                    break;
                case 1:
                    // Change hours
                    ChangeReportTime(idOfProject);
 
                    break;
                case 2:
                    // Change project
                   
                    int projectDbId = Project.GetProjectID("Ange korrekt projekt");
                    DBconnection.UpdateReport("project_id", $"{projectDbId}", idOfProject);

                    break;
                case 3:
                    RemoveReport(idOfProject);
                    break;
            }
        }

        private static void ChangeReportUser(int projectID)
        {
            // Let user move a report to another user
            int newUserDbId = User.GetUserID("Välj korrekt person");

            if (GoBack(newUserDbId))
            {
                return;
            }

            string newUserName = DBconnection.GetUserName(newUserDbId);

            DBconnection.UpdateReport("person_id", $"{newUserDbId}", projectID);
            Console.WriteLine($"Rapporten har nu registrerats på: {newUserName}");
            Console.ReadLine();

        }

        private static void ChangeReportTime(int projectID)
        {
            // Let user change time for a report
            int newTime = GetHours();

            if (GoBack(newTime))
            {
                return;
            }

            if (newTime == 0)
            {
                //If user select 0, it will ask user to remove the report
                RemoveReport(projectID);
                return;
            }

            //Change hours in DB
            DBconnection.UpdateReport("hours", $"{newTime}", projectID);
            Console.WriteLine($"Ny tid sparad: {newTime}");
            Console.ReadLine();
        }

        internal static void RemoveReport(int idToRemove)
        {
            // Let user remove a report
            string[] confirm = { "Nej", "Ja" };
            int confirmChoice = Menu(confirm, $"Är du säker på att du vill ta bort rapporten? [ID: {idToRemove} ]");
            switch (confirmChoice)
            {
                case 0:
                case -1:
                    break;
                case 1:
                    DBconnection.RemoveReport(idToRemove);
                    Console.WriteLine("Rapporten borttagen");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
