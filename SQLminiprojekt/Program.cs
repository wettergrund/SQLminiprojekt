global using SQLminiprojekt.Models;
using SQLminiprojekt.Data;

namespace SQLminiprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test connection

            List<UserModel> users = DBconnection.GetAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"User {i + 1} : {users[i].Person_Name} ");
            }

        }

        static void Run()
        {
            /* Menu shoult contain
             * 
             * Registrera arbetstid -> TimeReporting()
             * Modify Users -> users.add(), users.remove()
             * Modify projects -> projects.add(), project.remove()
             * 
             * 
             */
        }

        static int Menu(List<string> menuItems)
        {
        

            return -1;
        }
    }
}