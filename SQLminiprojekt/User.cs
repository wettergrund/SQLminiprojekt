using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class User
    {


        internal static int SelectUser(string text = "Välj användare")
        {
            //Console.WriteLine("test");
            //Return ID of user

            List<UserModel> users = DBconnection.GetAllUsers();
            string[] listOfUsers = ConertToArray(users);

            int userID = Menu(listOfUsers, text);


            if (userID == -1)
            {
                return -1;
            }
            userID = DBconnection.GetUserID(listOfUsers[userID]);

            return userID;
        }

        internal static void Add()
        {
            Console.WriteLine("Ange ett namn");
            string newUser = FormatName(Console.ReadLine());

            DBconnection.NewUser(newUser);
            Console.WriteLine(newUser + " har skapats");
            Console.ReadLine();
        }

        internal static void Rename() {
            int userDbID = SelectUser();
            string oldName = DBconnection.GetUserName(userDbID);

            Console.WriteLine("Ange ett nytt namn");
            string? newName = FormatName(Console.ReadLine());

            if(newName == null)
            {
                return;
            }

            DBconnection.RenameUser(newName,userDbID);
            Console.WriteLine($"Namnet har ändrats från: {oldName}\nTill: {newName}");
            Console.ReadLine();

        }

        // Remove not needed?
        internal static void Remove()
        {

            List<UserModel> users = DBconnection.GetAllUsers();
            string[] listOfUsers = ConertToArray(users);

            int userToRemove = Menu(listOfUsers, "Välj användare att ta bort");

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

        private static string FormatName(string inputString)
        {
            if(inputString.Length == 0)
            {
                Console.WriteLine("Du har inte angett något namn");
                Console.ReadLine();
                return null;
            }
            return inputString[0].ToString().ToUpper() + inputString.Substring(1).ToLower();
        }
    }
}
