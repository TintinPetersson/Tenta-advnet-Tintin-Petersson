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
        public int daysToSimulate;
        private int speed;
        public Simulations()
        {
            time = new Time();
            ticker = Ticker.GetInstance();
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
            daysToSimulate = frontend.GetAmountOfDays();
            month = frontend.GetMonth();
            day = frontend.GetDay();
            speed = frontend.GetSpeed();
            time.CalculateStartTime(month, day);
            AddHamsters();

            //Invoking the event/simulation to start
            StartClock?.Invoke(this, EventArgs.Empty);
        }
        private async void StartTicker(object sender, EventArgs e)
        {
            //Runs the event "Ticking", which has numerous subscribers
            while (ticker.tick <= 100 * daysToSimulate)
            {
                if (ticker.tick == 100 && daysToSimulate > 0)
                {
                    ticker.counter += 1;
                    ticker.tick = 1;
                    daysToSimulate--;
                    time.StartTime = time.CurrentTime.AddHours(14);
                    await Task.Run(() => ticker.Ticking(speed));
                    //Show Daily Report
                    RemoveHamsters();
                }
                else if (ticker.tick == 100 && daysToSimulate == 0)
                {
                    //Show daily report
                    await Task.Run(() => RemoveHamsters());
                }
                else
                {
                    await Task.Run(() => ticker.Ticking(speed));
                }
            }
        }
        private void StatusReport(object sender, EventArgs e)
        {
            Console.WriteLine($"Tick: {ticker.tick}");
            Console.WriteLine($"Day: {ticker.counter}");
            Console.WriteLine($"Current time: { time.CurrentTime.ToString()}");
        }
        private void AddHamsters()
        {
            HamsterDbContext hdb = new HamsterDbContext();

            var hamster = hdb.Hamsters.ToList();
            var cage = hdb.Cages.ToArray();

            var female = hamster.Select(c => c).Where(c => c.Gender == Gender.Male).ToList();
            var male = hamster.Select(c => c).Where(c => c.Gender == Gender.Female).ToList();

            int mCounter = 0;
            int fCounter = 0;
            int statsToAdd = 0;

            for (int i = 0; i < cage.Length; i++)
            {
                while (!cage[i].IsFull)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsters.Add(male[mCounter]);
                        cage[i].hamsters[statsToAdd].CageId = cage[i].Id;
                        cage[i].hamsters[statsToAdd].CheckInTime = time.StartTime;
                        statsToAdd++;
                        mCounter++;
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters.Add(female[fCounter]);
                        cage[i].hamsters[statsToAdd].CageId = cage[i].Id;
                        cage[i].hamsters[statsToAdd].CheckInTime = time.StartTime;
                        statsToAdd++;
                        fCounter++;
                    }
                }
                statsToAdd = 0;
            }
            hdb.SaveChanges();
        }
        private void RemoveHamsters()
        {
            HamsterDbContext hdb = new HamsterDbContext();

            var cage = hdb.Cages.ToArray();

            int mCounter = 0;
            int fCounter = 0;
            int statsToRemove = 0;

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsters != null)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsters[statsToRemove].CageId = null;
                        cage[i].hamsters[statsToRemove].CheckInTime = null;
                        cage[i].hamsters.Remove(cage[i].hamsters[mCounter]);
                        mCounter++;
                        statsToRemove++;
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters[statsToRemove].CageId = null;
                        cage[i].hamsters[statsToRemove].CheckInTime = null;
                        cage[i].hamsters.Remove(cage[i].hamsters[fCounter]);
                        fCounter++;
                        statsToRemove++;
                    }
                }
                statsToRemove = 0;
            }
            hdb.SaveChanges();

        }
    }
}
