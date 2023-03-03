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


            bool runProgram = true;

            while (runProgram)
            {

                int selectedItem = Menu(mainMenu);
                switch (selectedItem)
                {
                    case -1:
                        runProgram = false;
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
                //runProgram = false;
            }

        }

        static void TimeReporting()
        {
            List<UserModel> users = DBconnection.GetAllUsers();
            string[] allUsers = ConertToArray(users);


            List<ProjectModel> projects = DBconnection.GetAllProjects();
            string[] allProjects = ConertToArray(projects);

            int selectedUser = Menu(allUsers);

            if (selectedUser == -1) { return; }
            
            int userDbId = DBconnection.GetUserID(allUsers[selectedUser]);


            Console.WriteLine("Ange vilket projekt");
            int selectedProject = Menu(allProjects);
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
                "Ta bort användare " // --> user.remove()
            };


            bool runProgram = true;

            while (runProgram)
            {
                int selectedItem = Menu(UserMenu);
                switch (selectedItem)
                {
                    case -1:
                        runProgram = false;
                        break;
                    case 0:
                        User.Add();

                        break;
                    case 1:
                        User.Remove();
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


            bool runProgram = true;

            while (runProgram)
            {
                int selectedItem = Menu(ProjectMenu);
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
                runProgram = false;

            }
        }

    }
}