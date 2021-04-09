using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class UI
    {
        public int GetMonth()
        {
            bool validInput = false;
            int month = 0;
            do
            {
                Console.Clear();
                Console.Write("Enter which month you want: ");
                bool checkInt = int.TryParse(Console.ReadLine(), out month);
                if (!checkInt)
                {
                    Console.WriteLine("Only numbers.");
                    //Thread.Sleep(300);
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            return month;
        }
        public int GetDay()
        {
            bool validInput = false;
            int day = 0;
            do
            {
                Console.Clear();
                Console.Write("Enter which day of the month you want: ");
                bool checkInt = int.TryParse(Console.ReadLine(), out day);
                if (!checkInt)
                {
                    Console.WriteLine("Only numbers.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            return day;
        }
        public int GetAmountOfDays()
        {
            bool validInput = false;
            int days = 0;
            do
            {
                Console.Clear();
                Console.Write("How many days do you want to simulate: ");
                bool checkInt = int.TryParse(Console.ReadLine(), out days);
                if (!checkInt)
                {
                    Console.WriteLine("Only numbers.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            return days;
        }
        public int GetSpeed()
        {
            bool validInput = false;
            int speed = 0;
            do
            {
                Console.Clear();
                Console.Write("How fast do you want the program to run?\n[1 = 100 ms]: ");
                bool checkInt = int.TryParse(Console.ReadLine(), out speed);
                if (!checkInt)
                {
                    Console.WriteLine("Only numbers.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            return speed;
        }
        public async Task PrintReport(string dailyReport)
        {
            Console.Clear();
            Console.WriteLine(dailyReport.ToString());
            await Task.Delay(3000);
        }
        public async Task StatusReport(string statusReport)
        {
            Console.WriteLine(statusReport.ToString());
            await Task.Delay(10);
        }
    }
}
