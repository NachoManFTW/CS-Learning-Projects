using System;
using System.Collections.Generic;

//Main Namespace
namespace Calculator
{
    //Main Program Class
    class Program
    {
        //Main Function
        static int Main()
        {
            double num1;
            double num2;
            int operationSelector = 0;

            string[] operations = { "1.Add", "2.Subtract", "3.Multiply", "4.Divide" };
            //Program name
            Console.WriteLine("Calculator");

            //Loop until user exits with 'q' or closes out of program
            while (true)
            {
                while (true)
                {
                    //First number input
                    Console.Write("Enter First Number: ");
                    try
                    {
                        num1 = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invaild Input");
                    }
                }

                while (true)
                {
                    //Second number input
                    Console.Write("Enter Second Number: ");
                    try
                    {
                        num2 = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invaild Input");
                    }
                }

                //List all operations
                foreach (string operation in operations)
                {
                    Console.WriteLine(operation);
                }

                //Get operation type, loop until one is selected
                while (true)
                {
                    Console.Write("Please select one by entering the corresponding number: ");
                    try
                    {
                        operationSelector = Convert.ToUInt16(Console.ReadLine()) - 1;
                        if (operationSelector > 3 || operationSelector == 3 && num2 == 0)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");

                        //If print line depending on type of error
                        if (operationSelector == 3 && num2 == 0)
                            Console.WriteLine("ERROR: Cannot divide by zero");
                        else if (operationSelector > 3)
                            Console.WriteLine("ERROR: Input out of bounds");
                    }
                }

                //Go to operation
                GetOperation(operationSelector, num1, num2);
                
                //Quit Program, if 'q' is pressed
                QuitProgram();
                Console.Clear();
            }
        }

        // Add 2 numbers: retunrs sum
        static double Add(double num1, double num2) { return num1 + num2; }

        //Subtract 2 numbers: returns remainder
        static double Subtract(double num1, double num2) { return num1 - num2; }

        //Multiply 2 numbers: returns product
        static double Multiply(double num1, double num2) { return num1 * num2; }

        //Divide 2 numbers: returns dividen
        static double Divide(double num1, double num2) { return num1 / num2; }

        //Perform operation selected
        static void GetOperation(int operationSelector, double num1, double num2)
        {
            switch (operationSelector)
            {
                case 0:
                    Console.WriteLine(Add(num1, num2));
                    break;
                case 1:
                    Console.WriteLine(Subtract(num1, num2));
                    break;
                case 2:
                    Console.WriteLine(Multiply(num1, num2));
                    break;
                case 3:
                    Console.WriteLine(Divide(num1, num2));
                    break;
                default:
                    Console.WriteLine("Invalid selection, please try again!");
                    break;
            }
        }

        //Exit program if user presses 'q'
        static void QuitProgram()
        {
            // Loop request 
            Console.WriteLine("Press q to exit");
            Console.WriteLine("Press space to continue \n\n");
            if ('q' == Console.ReadKey(true).KeyChar)
                Environment.Exit(0);
        }
    }
}
