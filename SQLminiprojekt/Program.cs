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

        }

        static void Run()
        {
            //Main menu with options

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
                        Report.TimeReporting();
                        break;
                    case 1:
                        User.ModifyUser();
                        break;
                    case 2:
                        Project.ModifyProject();
                        break;
                    case 3:
                        Report.ModifyReport();
                        break;
                            
                }
            }

            //Before closing program
            GenerateBox("Programmet kommer avslutas");

            Console.ReadLine();
        }
    }
}