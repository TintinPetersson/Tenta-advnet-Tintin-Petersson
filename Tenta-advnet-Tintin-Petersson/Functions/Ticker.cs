﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    internal class Ticker
    {
        private static Ticker ticker;
        internal event EventHandler Tiktok;

        internal int tick;
        internal int counter = 1;

        internal async Task Ticking(int speed)
        {
            Console.Clear();
            await Task.Run(() => Tiktok?.Invoke(this, EventArgs.Empty));
            tick++;
            await Task.Delay(500* speed);
        }
        internal static Ticker GetInstance()
        {
            if (ticker == null)
            {
                ticker = new Ticker();
            }
            return ticker;
        }
    }
}
