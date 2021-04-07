using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Ticker
    {
        private static Ticker ticker;
        public int tick;
        public event EventHandler Tiktok;
        public int counter = 1;
        public async Task Ticking(int speed)
        {
            Console.Clear();
            Tiktok?.Invoke(this, EventArgs.Empty);
            tick++;
            await Task.Delay(1000* speed);
        }
        public static Ticker GetInstance()
        {
            if (ticker == null)
            {
                ticker = new Ticker();
            }
            return ticker;
        }
    }
}
