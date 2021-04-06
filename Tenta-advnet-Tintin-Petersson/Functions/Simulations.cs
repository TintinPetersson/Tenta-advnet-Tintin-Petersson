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
        private HamsterDbContext hdb;
        private int month;
        private int day;
        public int daysToSimulate;
        private int speed;
        public Simulations()
        {
            time = new Time();
            ticker = Ticker.GetInstance();
            frontend = new Frontend();
            hdb = new HamsterDbContext();

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
                if (ticker.tick == 101 && daysToSimulate > 1)
                {
                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintReport(dailyReport));
                    await Task.Run(() => DailyReport());

                    ticker.counter += 1;
                    ticker.tick = 0;
                    daysToSimulate--;
                    time.StartTime = time.CurrentTime.AddHours(14);

                    await Task.Run(() => RemoveHamsters());
                    AddHamsters();
                    await Task.Run(() => ticker.Ticking(speed));
                }
                else if (ticker.tick == 100 && daysToSimulate <= 1)
                {
                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintReport(dailyReport));
                    await Task.Run(() => RemoveHamsters());
                    break;
                }
                else
                {
                    await Task.Run(() => ticker.Ticking(speed));
                }
            }
        }
        private string DailyReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hamster in hdb.Hamsters)
            {
               sb.AppendLine($"\tName: {hamster.Name.PadLeft(5).PadRight(20)} " +
               $"| Gender: {hamster.OwnerId.ToString().PadLeft(2).PadRight(5)} | " +
               $"Last exercise: {hamster.Id.ToString().PadLeft(5).PadRight(15)} | Activites: {hamster.CageId.ToString().PadLeft(5)}");
            }
            return sb.ToString();
        }
        private void StatusReport(object sender, EventArgs e)
        {
            Console.WriteLine($"Tick: {ticker.tick}");
            Console.WriteLine($"Day: {ticker.counter}");
            Console.WriteLine($"Current time: { time.CurrentTime.ToString()}");
        }
        private void AddHamsters()
        {
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
        private async Task RemoveHamsters()
        {
            await Task.Delay(100);
            var cage = hdb.Cages.ToArray();

            int counter = 0;

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsters.Count != 0)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsters[counter].CageId = null;
                        cage[i].hamsters[counter].CheckInTime = null;
                        cage[i].hamsters.Remove(cage[i].hamsters[counter]);
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters[counter].CageId = null;
                        cage[i].hamsters[counter].CheckInTime = null;
                        cage[i].hamsters.Remove(cage[i].hamsters[counter]);
                    }
                }
            }
            hdb.SaveChanges();

        }
    }
}
