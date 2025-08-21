using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {


        static int Main()
        {
            int num1 = 0;
            int num2 = 0;
            int operationSelector;

            string[] operations = { "1.Add", "2.Subtract", "3.Multiply", "4.Divide" };
            //Program name
            Console.WriteLine("Calculator");

            while (true)
            {
                //First number input
                Console.Write("Enter First Number: ");
                try
                {
                    num1 = Convert.ToInt16(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
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
                    num2 = Convert.ToInt16(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invaild Input");
                }
            }

            //List all operations
            foreach (string operation in operations)
            {
                Console.WriteLine(operation);
            }

            //Get operation type
            while (true)
            {
                Console.Write("Please select one by entering the corresponding number: ");
                try
                {
                    operationSelector = Convert.ToUInt16(Console.ReadLine()) - 1;
                    if (operationSelector > 3)
                    {
                        throw new Exception();
                    }
                    if (operationSelector == 3 && num2 == 0)
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Input out of bounds");
                }


            }

            //Go to operation
            switch (operationSelector)
            {
                case 0:
                    Console.WriteLine(add(num1, num2));
                    break;
                case 1:
                    Console.WriteLine(subtract(num1, num2));
                    break;
                case 2:
                    Console.WriteLine(multiply(num1, num2));
                    break;
                case 3:
                    Console.WriteLine(divide(num1, num2));
                    break;
                default:
                    Console.WriteLine("Invalid selection, please try again!");
                    break;
            }
    


            return 0;
        }

        static int add(int num1, int num2)
        {
            return num1 + num2;
        }

        static int subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        static int multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        static int divide(int num1, int num2)
        {
            return num1 / num2;
        }

    }
}
