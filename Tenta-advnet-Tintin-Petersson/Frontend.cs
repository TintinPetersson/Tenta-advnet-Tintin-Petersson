﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Frontend
    {
        public int GetMonth()
        {
            Console.Clear();
            Console.WriteLine("Enter which month you want: ");
            int month = int.Parse(Console.ReadLine());
            return month;
        }
        public int GetDay()
        {
            Console.Clear();
            Console.WriteLine("Enter which day you want: ");
            int day = int.Parse(Console.ReadLine());
            return day;
        }
        public int GetAmountOfDays()
        {
            Console.Clear();
            Console.WriteLine("How many days do you want to simulate?");
            int days = int.Parse(Console.ReadLine());
            return days;
        }
        public int GetSpeed()
        {
            Console.Clear();
            Console.WriteLine("How fast do you want the program to run? 1-5");
            int speed = int.Parse(Console.ReadLine());
            return speed;
        }

        internal async Task PrintReport(string dailyReport)
        {
            Console.WriteLine(dailyReport.ToString());
            await Task.Delay(100);
        }
    }
}
