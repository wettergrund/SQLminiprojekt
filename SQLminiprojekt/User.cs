﻿using System;
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
            string newUser = Console.ReadLine();    
            DBconnection.NewUser(newUser);


        }

        internal static void Modify() {
            int userDbID = SelectUser();

            Console.WriteLine("Ange ett nytt namn");
            string? newName = Console.ReadLine();

            DBconnection.RenameUser(newName,userDbID);


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
    }
}
