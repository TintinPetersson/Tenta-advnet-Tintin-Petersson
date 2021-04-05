using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Ticker
    {
        public static int Tick { get; set; }
        public event EventHandler Tiktok;
        public int counter = 1;

        public async Task Ticking()
        {
            while (Tick <= Simulations.daysToSimulate * 100)
            {
                if (Tick == 101 && Simulations.daysToSimulate > 0)
                {
                    counter += 1;
                    //Show statusreport for day
                    Tick = 0;
                    Simulations.daysToSimulate--;
                    Time.StartTime = Time.CurrentTime.AddHours(14);

                    Console.Clear();
                    Tiktok?.Invoke(this, EventArgs.Empty);
                    Tick++;
                    await Task.Delay(100);
                }
                else if (Tick == 100 && Simulations.daysToSimulate == 0)
                {
                    //Show status report
                }
                else
                {
                    Console.Clear();
                    Tiktok?.Invoke(this, EventArgs.Empty);
                    Tick++;
                    await Task.Delay(100);
                }
            }

            return;
        }
    }
}
