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

                int selectedItem = Menu(mainMenu, "Huvudmeny");
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
                        ModifyReport();
                        break;
                            
                }
            }

        }

        static void TimeReporting()
        {

            int userDbId = User.SelectUser("Välj person att registrera tid för");
            int projectDbId = Project.GetProjectID();

            int hours = GetHours();
            if(hours == -1)
            {
                return;
            }

            DBconnection.NewTimeReport(projectDbId, userDbId, hours);
            Console.WriteLine("New time report added"); 
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
                        User.Add();

                        break;
                    case 1:
                      
                        User.Modify();
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
                        Project.Add();

                        break;
                    case 1:
                        Project.Rename();
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
                        Report.SelectReport();
                        break;
                    case 1:
                        //Remove report
                        break;

                }
            }
        }

    }
}