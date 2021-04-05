﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Time
    {
        public static DateTime StartTime { get; set; }
        public static DateTime CurrentTime { get; set; }
        public DateTime CalculateStartTime(int month, int day)
        {
            DateTime timeStamp = new DateTime(2021, month, day, 7, 0, 0);
            StartTime = timeStamp;
            return timeStamp;
        }
        public void OnCalculateCurrentTime(object sender, EventArgs e)
        {
            int timeToAdd = Ticker.Tick * 6;
            DateTime timeStamp = StartTime.AddMinutes(timeToAdd);
            CurrentTime = timeStamp;
        }
    }
}
