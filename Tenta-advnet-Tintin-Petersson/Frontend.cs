using System;
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
        public int AmountOfDays()
        {
            Console.WriteLine("How many days do you want to simulate?");
            int days = int.Parse(Console.ReadLine());
            return days;
        }
    }
}
