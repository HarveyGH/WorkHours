using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RefactoringWorkHours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfEmployees;
            int numOfDays;

            Random rd = new Random();

            //Print banner
            PrintSessionBanner();

            //Number of employees
            numOfEmployees = GetSimulationEmployees();

            //Number of days
            numOfDays = GetSimulationDay();

            //Run simulation
            int[,] arr = RunSimulation(rd, numOfEmployees, numOfDays);

            //Print matrix
            PrintMatrix(arr);

            //Print summary
            PrintSummary(arr);

            //Pause 
            Write("\nPress any key to wrap it up...");
            ReadKey();
        }

        //Methods
        private static void PrintSessionBanner()
        {
            WriteLine("****************************************************************************");
            WriteLine("*                                                                          *");
            WriteLine("*                     EMPLOYEE WORK HOURS SIMULATION v. 2.0                *");
            WriteLine("*                                                                          *");
            WriteLine("*                  One row per employee, one column per day                *");
            WriteLine("*                                                                          *");
            WriteLine("****************************************************************************");
        }

        private static int GetSimulationEmployees()
        {
            const int MaxNumber = 100;
            int number = 0;

            //Number of employees
            Write("\nEnter number of employees for this simulation (1-100):\t");
            int.TryParse(ReadLine(), out number);
            while (number < 1 || number > MaxNumber)
            {
                Write($"{"Please enter a positive whole number from 1 to 100: \t"}");
                int.TryParse(ReadLine(), out number);
            }
            return number;
        }

        private static int GetSimulationDay()
        {
            const int MaxDays = 10;
            int days = 0;

            //Number of days
            Write("\nEnter number of days for this simulation (1-10):\t");
            int.TryParse(ReadLine(), out days);
            while (days < 1 || days > MaxDays)
            {
                Write($"{"Please enter a positive whole number from 1 to 10: \t"}");
                int.TryParse(ReadLine(), out days);
            }
            return days;
        }

        private static int[,] RunSimulation(Random rand, int number, int day)
        {
            int[,] arr = new int[number, day];
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < day; j++)
                {
                    arr[i, j] = rand.Next(1, 9); 
                }
            }
            return arr;
        }

        private static void PrintMatrix(int[,] array)
        {
            int numOfEmployees;
            int days;
            numOfEmployees = array.GetLength(0);
            days = array.GetLength(1);
            //Display
            WriteLine("\n\nSIMULATION 1: {0} employees over {1} days", numOfEmployees, days);

            for (int i = 0; i < days; i++)
            {
                Write("\t{0,4}", i + 1);
            }
            WriteLine();
            Write("     ");
            for (int i = 0; i < days; i++)
            {
                Write("{0,8}", " _______");
            }

            for (int i = 0; i < numOfEmployees; i++)
            {
                Write("\n{0,-2}{1,3}", i + 1, "|");
                for (int j = 0; j < days; j++)
                {
                    Write("\t{0,5}", array[i, j]);
                }

            }
            WriteLine();
            Write("     ");
        }

        private static void PrintSummary(int[,] array)
        {
            int sumArr = 0;
            float avgArr;

            int number = array.GetLength(0);
            int days = array.GetLength(1);
            foreach (int item in array)
            {
                sumArr += item;
            }
            avgArr = (float)sumArr / (number * days);
            WriteLine("\nTotal hours worked:\t\t{0}", sumArr);
            WriteLine("Average hours per employee per day:\t{0}", avgArr);
        }
    }
}

