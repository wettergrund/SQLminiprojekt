global using SQLminiprojekt.Models;
global using SQLminiprojekt.Data;

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

            int selectedItem = Menu(mainMenu);

            bool runProgram = true;

            while (runProgram)
            {
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
            }

        }

        static void TimeReporting()
        {
            List<UserModel> users = DBconnection.GetAllUsers();
            string[] allUsers = Tools.ConertToArray(users);
            List<ProjectModel> projects = DBconnection.GetAllProjects();
            string[] allProjects = Tools.ConertToArray(projects);

            Console.WriteLine("Välj vilken användare du ska rapportera på");
            int selectedUser = Menu(allUsers);

            Console.WriteLine("Ange vilket projekt");
            int selectedProject = Menu(allProjects);

            Console.WriteLine("Ange hela timmar:");
            int hours = int.Parse(Console.ReadLine());
        
            

        }
        static void ModifyUser()
        {
            string[] UserMenu = { 
                "Lägg till användare", // --> user.add()
                "Ta bort användare " // --> user.remove()
            };

            int selectedItem = Menu(UserMenu);

            bool runProgram = true;

            while (runProgram)
            {
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

            string[] UserMenu = {
                "Lägg till projekt", // --> user.add()
                "Ta bort projekt " // --> user.remove()
            };

        }


        static int Menu(string[] input)
        {
            Console.Clear();

            int stringLength = input.Length;

            for (int i = 0; i < stringLength; i++)
            {
                Console.WriteLine($"[{i + 1}] {input[i]}");
            }
            Console.WriteLine($"[{stringLength + 1}] Gå tillbaka");

            Console.Write("Välj en siffra: ");
            int selectedItem = int.Parse(Console.ReadLine());
            if(selectedItem == stringLength + 1) {

                return -1;

            }

            selectedItem--;
          
            return selectedItem;
        }
    }
}