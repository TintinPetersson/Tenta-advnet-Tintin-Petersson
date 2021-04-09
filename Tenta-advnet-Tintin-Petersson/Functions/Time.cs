using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    internal class Time
    {
        private Ticker ticker;
        internal string DateString { get => StartTime.ToShortDateString(); }
        internal DateTime StartTime { get; set; }
        internal DateTime CurrentTime { get; set; }
        internal Time()
        {
            ticker = Ticker.GetInstance();
        }
        internal DateTime CalculateStartTime(int month, int day)
        {
            DateTime timeStamp = new DateTime(2021, month, day, 7, 0, 0);
            StartTime = timeStamp;
            return timeStamp;
        }
        internal void CalculateCurrentTime(object sender, EventArgs e)
        {
            int timeToAdd = ticker.tick * 6;
            DateTime timeStamp = StartTime.AddMinutes(timeToAdd);
            CurrentTime = timeStamp;
        }
        
    }
}
