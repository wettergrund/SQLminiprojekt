using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class User
    {


        internal static int GetUserID(string text = "Välj användare")
        {
            //Return DB ID of user

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

        internal static void AddUser()
        {
            //Add new user to DB

            Console.WriteLine("Ange ett namn");
            string newUser = FormatName(Console.ReadLine());

            DBconnection.NewUser(newUser);
            Console.WriteLine(newUser + " har skapats");
            Console.ReadLine();
        }

        internal static void RenameUser() {
            // Rename existing user

            int userDbID = GetUserID();
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
    }
}
