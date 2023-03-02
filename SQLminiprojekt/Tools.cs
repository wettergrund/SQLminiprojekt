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

        internal static int Menu(string[] input)
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
            if (selectedItem == stringLength + 1)
            {

                return -1;

            }

            selectedItem--;

            return selectedItem;
        }
    }
}
