namespace SQLminiprojekt
{
    internal class User
    {
        internal static void ModifyUser()
        {
            //Options to change existing user

            string[] UserMenu = {
                "Lägg till användare", // --> AddUser();
                "Byt namn på användare" // --> RenameUser()
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
                        AddUser();
                        break;
                    case 1:
                        RenameUser();
                        break;
                }
            }
        }

        internal static int GetUserID(string header = "Välj användare")
        {
            //Return DB ID of user

            List<UserModel> listOfAllUsers = DBconnection.GetAllUsers();
            string[] usersArray = ConertToArray(listOfAllUsers);

            int userID = Menu(usersArray, header);


            if (userID == -1)
            {
                return -1;
            }
            userID = DBconnection.GetUserID(usersArray[userID]);

            return userID;
        }

        internal static void AddUser()
        {
            //Add new user to DB

            Console.WriteLine("Ange ett namn");
            string newUserName = FormatName(Console.ReadLine());

            if(newUserName == null)
            {
                return;
            }

            DBconnection.NewUser(newUserName);
            Console.WriteLine(newUserName + " har skapats");
            Console.ReadLine();
        }

        internal static void RenameUser() {
            // Rename existing user

            int userDbID = GetUserID();
            if (GoBack(userDbID))
            {
                return;
            }

            string oldName = DBconnection.GetUserName(userDbID);

            Console.WriteLine("Ange ett nytt namn");
            string newName = FormatName(Console.ReadLine());

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
