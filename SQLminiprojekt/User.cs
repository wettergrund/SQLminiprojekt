using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class User
    {

        //public User() { 
        
        //}

        internal static void Select()
        {

     
        }

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
            string[] listOfUsers = Tools.ConertToArray(users);

            int userToRemove = Tools.Menu(listOfUsers);
            int idOfUser = DBconnection.GetUserID(listOfUsers[userToRemove]);
            Console.WriteLine($"Id är: {idOfUser}");
            Console.ReadLine();

        }
    }
}
