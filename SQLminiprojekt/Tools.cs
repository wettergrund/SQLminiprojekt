namespace SQLminiprojekt
{
    internal class Tools
    {


        internal static string[] ConertToArray(List<UserModel> input)
        {
            //Convert a list to an array

            int numberOfItems = input.Count;

            string[] newArray = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                newArray[i] = input[i].Person_Name;
            }

            return newArray;
        }

        internal static string[] ConertToArray(List<ProjectModel> input)
        {
            //Overload of project model 

            int numberOfItems = input.Count;

            string[] newArray = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                newArray[i] = input[i].Project_Name;
            }

            return newArray;
        }

        internal static int GetHours(string text = "Ange tid i hela timmar")
        {
            //A method to validate and return hours

            bool isValid;
            string userInput;

            GenerateBox(text);
            userInput = Console.ReadLine();

            isValid = int.TryParse(userInput, out int selectedTime);

            if(selectedTime <= 0) {
                Console.WriteLine("Du måste ange minst en timme");
                Console.ReadLine();
                return -1;
            }

            if (!isValid)
            {
                Console.WriteLine("Något gick fel, försök igen och ange hela timmar");
                Console.ReadLine();
                return -1;
            }

            return selectedTime;

        }

        internal static string FormatName(string inputString)
        {
            //Validate and return name with uppe firts letter. Currently not taking care of typos where 2nd letter and beyond is in upper case.
            if (inputString.Length == 0)
            {
                Console.WriteLine("Du har inte angett något namn");
                Console.ReadLine();
                return null;
            }
            return inputString[0].ToString().ToUpper() + inputString.Substring(1);
        }




        internal static int Menu(string[] menuOptions, string header = "" , bool isMainMenu = false )
        {
            /* Return an INT absed on selected menu item to be matched with eg. account in an array.  */

            Console.Clear();


            /* Generate text box (optional) */
            if (header != "")
            {
                GenerateBox(header);
            }

            // Temp array to add array item (Go back option)
            string[] tempArray = new string[menuOptions.Length + 1];
            int lastPosition = tempArray.Length - 1;
            for (int i = 0; i < menuOptions.Length; i++)
            {
                tempArray[i] = menuOptions[i];
            }
            menuOptions = tempArray;

            menuOptions[lastPosition] = isMainMenu ? "Avsluta" : "Gå tillbaka";
            

            int menuRows = menuOptions.Length;
            int selectedRow = 0;

            bool showMenu = true;
            while (showMenu)
            {
                /* Generare menu and higlight selected row */
                for (int i = 0; i < menuRows; i++)
                {
                    if (selectedRow == i)
                    {
                        Console.Write("├ ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.Write("│ ");
                    }


                    Console.WriteLine(menuOptions[i]);
                    Console.ForegroundColor = ConsoleColor.White;


                }


                /* Handle key inputs and change variable selected */
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedRow = Math.Max(0, selectedRow - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedRow = Math.Min(menuRows - 1, selectedRow + 1);
                        break;
                    case ConsoleKey.Enter:
                        showMenu = false;
                        break;
                    case ConsoleKey.Backspace:
                        selectedRow = -1;
                        showMenu = false;
                        break;
                }

                /* Move selecttion based on key inputs */
                if (showMenu)
                {
                    Console.CursorTop = Console.CursorTop - menuRows;
                }

            }

            if(selectedRow == lastPosition)
            {
                return -1;
            }

            return selectedRow;
        }


        internal static void GenerateBox(string text, bool newPage = true)
        {
            /* To get a nice border around eg. a header text */
            if (newPage)
            {
                Console.Clear();
            }

            int strLength = text.Length;

            string result = "";


            string[] boxDesign = { 
                /*0 */"╔", /*1 */"═", /*2 */"╗",
                /*3 */"║", /* Text */
                /*4 */"╚",           /*5 */"╝"
            };

            /* topp */
            result += boxDesign[0];
            for (int i = 0; i < strLength; i++)
            {
                result += boxDesign[1];
            }
            result += $"{boxDesign[2]}\n";

            /* text */
            result += boxDesign[3];
            result += text;
            result += $"{boxDesign[3]}\n";

            /* bottom */
            result += boxDesign[4];
            for (int i = 0; i < strLength; i++)
            {
                result += boxDesign[1];
            }
            result += boxDesign[5];
            Console.WriteLine(result);

        }

        public static bool GoBack(int input)
        {
            //Just validate if a eg. a menu selection return -1 ( = error/go back) for better readability. 
            if(input == -1)
            {
                return true;
            }
            
            return false;
        }
    }


}
