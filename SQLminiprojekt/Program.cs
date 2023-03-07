global using SQLminiprojekt.Models;
global using SQLminiprojekt.Data;
global using static SQLminiprojekt.Tools;


namespace SQLminiprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Run();

            GenerateBox("Programmet kommer avslutas");
            
            Console.ReadLine();

        }

        static void Run()
        {

            string[] mainMenu = {
                "Registrera arbetstid",
                "Ändra användare",
                "Ändra projekt",
                "Ändra rapport"
            };


            bool showMenu = true;

            while (showMenu)
            {

                int selectedItem = Menu(mainMenu, "Huvudmeny", true);
                switch (selectedItem)
                {
                    case -1:
                        showMenu = false;
                        break;
                    case 0:
                        TimeReporting();
                        break;
                    case 1:
                        ModifyUser();
                        break;
                    case 2:
                        ModifyProject();
                        break;
                    case 3:
                        Report.ModifyReport();
                        break;
                            
                }
            }

        }

        static void TimeReporting()
        {

            int userDbId = User.GetUserID("Välj person att registrera tid för");
            if (GoBack(userDbId))
            {
                return;
            }

            int hours = GetHours();
            if(GoBack(hours))
            { 
                return;
            }

            int projectDbId = Project.GetProjectID();
            if (GoBack(projectDbId))
            {
                return;
            }

            DBconnection.NewTimeReport(projectDbId, userDbId, hours);

            Console.Clear();
            GenerateBox("Tidrapport skapad");
            Console.WriteLine($"Användare: {DBconnection.GetUserName(userDbId)}");
            Console.WriteLine($"Projekt: {DBconnection.GetProjectName(projectDbId)}");
            Console.WriteLine($"Tid: {hours} timmar");
            Console.ReadLine();

        }

        static void ModifyUser()
        {
            string[] UserMenu = { 
                "Lägg till användare", // --> user.add()
                "Byt namn på användare"
                //"Ta bort användare " // --> user.remove()
            };


            bool showMenu = true;

            while (showMenu)
            {
                int selectedItem = Menu(UserMenu, "Användarmeny");
                switch (selectedItem)
                {
                    case -1:
                        showMenu = false;
                        break;
                    case 0:
                        User.AddUser();

                        break;
                    case 1:
                      
                        User.RenameUser();
                        //User.Remove();
                        break;
                }
            }


        }
        static void ModifyProject()
        {

            string[] ProjectMenu = {
                "Lägg till projekt", 
                "Byt namn på projekt " 
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
                        Project.AddProject();

                        break;
                    case 1:
                        Project.RenameProject();
                        break;
                }
                showMenu = false;

            }
        }

        static void ModifyReport()
        {
            string[] ReportMenu = {
                "Ändra rapport", 
                "Ta bort rapport" 
            };

            bool showMenu = true;

            while (showMenu)
            {

                int selectedItem = Menu(ReportMenu, "Ändra rapporter");
                switch (selectedItem)
                {
                    case -1:
                        showMenu = false;
                        break;
                    case 0:
                        Report.ModifyReport();
                        break;
                    case 1:
                        //Remove report
                        break;

                }
            }
        }

    }
}