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
            
            // Test connection

            //List<UserModel> users = DBconnection.GetAllUsers();

            //string[] allUsers = ConertToArray(users);

            //int selectedOption = Menu(allUsers);

            //Console.WriteLine(selectedOption);
            //Console.ReadLine();

        }

        static void Run()
        {
            /* Menu should contain
             * 
             * Registrera arbetstid -> TimeReporting()
             * Modify Users -> user.add(), user.remove()
             * Modify projects -> projects.add(), project.remove()
             * 
             * 
             */

            string[] mainMenu = {
                "Registrera arbetstid",
                "Ändra användare",
                "Ändra projekt"
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
                            
                }
            }

        }

        static void TimeReporting()
        {
            List<UserModel> users = DBconnection.GetAllUsers();
            string[] allUsers = ConertToArray(users);


            List<ProjectModel> projects = DBconnection.GetAllProjects();
            string[] allProjects = ConertToArray(projects);

            int selectedUser = Menu(allUsers, "Välj person att registrera tid för");

            if (selectedUser == -1) { return; }
            
            int userDbId = DBconnection.GetUserID(allUsers[selectedUser]);


            int selectedProject = Menu(allProjects, "Ange projekt");
            if (selectedProject == -1) { return; }

            int projectDbId = DBconnection.GetProjectID(allProjects[selectedProject]);

            Console.WriteLine("Ange hela timmar:");
            int hours = int.Parse(Console.ReadLine());


            DBconnection.NewTimeReport(projectDbId, userDbId, hours);
            Console.WriteLine("New time report added");
            Console.ReadLine();





        }
        static void ModifyUser()
        {
            string[] UserMenu = { 
                "Lägg till användare", // --> user.add()
                "Ändra användare"
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
                "Lägg till projekt", // --> Project.add()
                "Ta bort projekt " // --> Project.remove()
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
                        Project.Remove();
                        break;
                }
                showMenu = false;

            }
        }

    }
}