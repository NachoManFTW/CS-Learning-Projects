using System;
using System.Collections.Generic;
using System.Linq;


namespace TODO
{
    class Program
    {
        static readonly string[] options = { "1.Add to List", "2.Remove from List", "3.Edit List", "4.View List", "5.Quit" };

        static int Main()
        {
            //Hold all items to do, dynamically resizeable
            List<string> To_Do_List = new List<string>();
            //Generic User Input
            string userOptionsChoice;
            int choice;

            //Prompt user for selection
            Console.WriteLine("Todo List\n\n");

            while (true)
            {
                //List each item in options, what to do to list
                foreach (var item in options)
                {
                    Console.WriteLine(item);
                }

                //Loop until valid input is recieved
                while (true)
                {
                    //Get user option, repeat until valid option is selected
                    Console.Write("Please select one of the corresponding numbers: ");
                    userOptionsChoice = Console.ReadLine();

                    //Try to convert string to int, if failed loop until valid option is selected
                    try
                    {
                        choice = Convert.ToUInt16(userOptionsChoice) - 1;
                        if (choice > 4 || choice < 0)
                            throw new Exception();
                        if (choice < 5 && choice >= 0)
                            break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Invalid Option");
                    }
                }

                OptionsSwitchCase(ref choice, ref To_Do_List);
            }
        }

        //Add item to list
        static void AddToList(ref List<string> list)
        {
            string item;
            Console.Write("Add: ");
            item = Console.ReadLine();
            list.Add(item);
        }

        //Remove item from list
        static void RemoveFromList(ref List<string> list)
        {
            int choice;
            ViewList(ref list);
            //Loop until a number that is within the list
            while (true)
            {
                Console.Write("Which would you like to remove: ");
                try
                {
                    choice = Convert.ToInt16(Console.ReadLine()) - 1;
                    if (choice < 0 || choice >= list.Count)
                        throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid Option");
                }
            }
            //Remove item at chosen position
            list.RemoveAt(choice);
        }

        //Edit item in list
        static void EditList(ref List<string> list)
        {
            int choice;
            ViewList(ref list);
            Console.Write("Which item would you like to edit: ");
            while (true)
            {
                try
                {
                    choice = Convert.ToUInt16(Console.ReadLine()) - 1;
                    if (choice < 0 || choice >= list.Count)
                        throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Invalid Option");
                }
            }
            Console.WriteLine($"Current Item: {choice}. {list[choice + 1]}");
            Console.Write("\nReplace with: ");
            list[choice] = Console.ReadLine();
        }

        //View all items in list
        static void ViewList(ref List<string> list)
        {
            //Loop throw each item in the list and print to console
            //Print each item in list with corresponding number
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine($"{i + 1}: {list[i]}");
            }
        }

        //Switch case for all available options from list
        static void OptionsSwitchCase(ref int choice, ref List<string> To_Do_List)
        {
            switch (choice)
            {
                case 0:
                    AddToList(ref To_Do_List);
                    Console.Clear();
                    break;
                case 1:
                    RemoveFromList(ref To_Do_List);
                    Console.Clear();
                    break;
                case 2:
                    EditList(ref To_Do_List);
                    Console.Clear();
                    break;
                case 3:
                    ViewList(ref To_Do_List);
                    break;
                case 4:
                    Console.WriteLine("Exitting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
