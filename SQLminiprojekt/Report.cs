namespace SQLminiprojekt
{
    internal class Report
    {
        internal static void TimeReporting()
        {
            //Add a new time report

            //Let user select user
            int userDbId = User.GetUserID("Välj person att registrera tid för");
            if (GoBack(userDbId))
            {
                return;
            }

            //Let user enter hours
            int hours = GetHours();
            if (GoBack(hours))
            {
                return;
            }

            //Let user select project
            int projectDbId = Project.GetProjectID();
            if (GoBack(projectDbId))
            {
                return;
            }

            // Added to DB
            DBconnection.NewTimeReport(projectDbId, userDbId, hours);


            Console.Clear();
            GenerateBox("Tidrapport skapad");
            Console.WriteLine($"Användare: {DBconnection.GetUserName(userDbId)}");
            Console.WriteLine($"Projekt: {DBconnection.GetProjectName(projectDbId)}");
            Console.WriteLine($"Tid: {hours} timmar");
            Console.ReadLine();

        }
        internal static void ModifyReport()
        {
            //Let user change existing reports

            ReportModel selectedReport = SelectReport();

            if (selectedReport == null) {
                return;
            }


            //Give user options
            string[] reportMenu = {
                $"Ändra person ({selectedReport.person_name})",
                $"Ändra tid ({selectedReport.hours})",
                $"Ändra projekt({selectedReport.project_name})",
                $"Ta bort rapport"
            };

            int reportMenuChoice = Menu(reportMenu);



            switch (reportMenuChoice)
            {
                case 0:
                    // Change person
                    ChangeReportUser(selectedReport.Id);

                    break;
                case 1:
                    // Change hours
                    ChangeReportTime(selectedReport.Id);
 
                    break;
                case 2:
                    // Change project
                   
                    int projectDbId = Project.GetProjectID("Ange korrekt projekt");
                    DBconnection.UpdateReport("project_id", $"{projectDbId}", selectedReport.Id);

                    break;
                case 3:
                    RemoveReport(selectedReport.Id);
                    break;
            }
        }

        private static ReportModel SelectReport()
        {
            //List all reports and let user select the one to update
            List<ReportModel> reports = DBconnection.GetReport();

            string[] combinedStrings = new string[reports.Count];


            for (int i = 0; i < reports.Count; i++)
            {
               

                combinedStrings[i] = $"Användare: {reports[i].person_name} Projekt: {reports[i].project_name} Tid: {reports[i].hours} timmar";
            }

            int reportIndex = Menu(combinedStrings, "Välj rapport att ändra");

            if (GoBack(reportIndex))
            {
                return null;
            }


            //Store info about selected report.
            int idOfProject = reports[reportIndex].Id;


            return DBconnection.GetReport(idOfProject).Last();
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

        private static void RemoveReport(int idToRemove)
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
