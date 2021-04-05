using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Simulations
    {
        private EventHandler StartClock;
        private Time time;
        private Ticker ticker;
        private Frontend frontend;
        private int month;
        private int day;

        public Simulations()
        {
            time = new Time();
            ticker = new Ticker();
            frontend = new Frontend();
        }
        public void Start()
        {
            //Subscribers
            #region Subscribers
            StartClock += StartTicker;

            ticker.Tiktok += time.OnCalculateCurrentTime;
            ticker.Tiktok += StatusReport;
            #endregion

            //Asking user for month and day
            month = frontend.GetMonth();
            day = frontend.GetDay();
            time.CalculateStartTime(month, day);

            //Invoking the event/simulation to start
            StartClock?.Invoke(this, EventArgs.Empty);
        }
        private async void StartTicker(object sender, EventArgs e)
        {
            //Runs the event "Ticking", which has numerous subscribers
            await Task.Run(() => ticker.Ticking());
        }
        private void StatusReport(object sender, EventArgs e)
        {
            Console.WriteLine(Ticker.Tick);
            Console.WriteLine(time.CurrentTime.ToString());
        }
    }
}
