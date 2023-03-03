using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class User
    {




        internal static void Add()
        {
            Console.WriteLine("Ange ett namn");
            string newUser = Console.ReadLine();    
            DBconnection.NewUser(newUser);


        }

        internal static void Remove()
        {
            Console.WriteLine("Välj användare att ta bort");

            List<UserModel> users = DBconnection.GetAllUsers();
            string[] listOfUsers = ConertToArray(users);

            int userToRemove = Menu(listOfUsers);

            if (userToRemove == -1)
            {
                return;
            }

            // Get ID of user
            int idOfUser = DBconnection.GetUserID(listOfUsers[userToRemove]);
            Console.WriteLine($"Id är: {idOfUser}");
            Console.ReadLine();
            DBconnection.RemoveUser(idOfUser);


        }
    }
}
