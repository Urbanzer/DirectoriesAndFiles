using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {







            string rootDirectory = @"C:\Users\Aleksander\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();


            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory {newDirectory} exists at {rootDirectory}");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
            }

            string[] arrayFromFile = File.ReadAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while(loopActive)
            {
                Console.WriteLine("Would you like to add objects to your list? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if(userInput == 'y')
                {
                    Console.WriteLine("Enter your object to the list:");
                    string userShopping = Console.ReadLine();
                    myShoppingList.Add(userShopping);
                }
                else
                {
                    loopActive = false;
                }
            }

            Console.Clear();
            Console.WriteLine("Take care!");
            foreach (string Shopping in myShoppingList)
            {
                Console.WriteLine($@"Your shopping list: {Shopping}");
            }

            File.WriteAllLines($"{newDirectory}{fileName}", myShoppingList);



        }
    }
}
