using System;
using PL;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t\t\tGPA CALCULATOR\n\n");
            int input;

            do
            {
                Console.WriteLine("\n\t1- Enter Student Data");
                Console.WriteLine("\t2- Output Student Data");
                Console.WriteLine("\t3- Exit");
                Console.Write("\t\tPlease select one of the above options: ");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    GPAView gpa = new GPAView();
                    gpa.InputData();
                }

                else if(input == 2)
                {
                    GPAView gpa = new GPAView();
                    gpa.OutputData();
                    Console.WriteLine("\tPress any key to go to main menu.......");
                    Console.ReadKey(true);
                }

            } while (input != 3);
        }
    }
}
