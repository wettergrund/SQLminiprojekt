using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt
{
    internal class Tools
    {


        internal static string[] ConertToArray(List<UserModel> input)
        {

            int numberOfItems = input.Count;

            string[] strings = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                strings[i] = input[i].Person_Name;
            }

            return strings;
        }

        internal static string[] ConertToArray(List<ProjectModel> input)
        {

            int numberOfItems = input.Count;

            string[] strings = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                strings[i] = input[i].Project_Name;
            }

            return strings;
        }

        internal static int GetHours(string text = "Ange tid i hela timmar")
        {
            bool isValid;
            int selectedNumber;
            string userInput;

            GenerateBox(text);
            userInput = Console.ReadLine();

            isValid = int.TryParse(userInput, out selectedNumber);

            if (!isValid)
            {
                Console.WriteLine("Något gick fel, försök igen och ange hela timmar");
                Console.ReadLine();
                return -1;
            }

            return selectedNumber;

        }


        internal static int Menu(string[] menuOptions, string header = "")
        {
            Console.Clear();

            /* Return an INT absed on selected menu item to be matched with eg. account in an array.  */

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

            menuOptions[lastPosition] = "Gå tillbaka";


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
    }
}
