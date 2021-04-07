using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Simulation
    {
        private EventHandler StartClock;
        private Time time;
        private Ticker ticker;
        private Frontend frontend;
        private HamsterDbContext hdb;
        private int tickMultiplier;
        private int month;
        private int day;
        public int daysToSimulate;
        private int speed;
        public Simulation()
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

            ticker.Tiktok += time.CalculateCurrentTime;
            ticker.Tiktok += StatusReport;
            ticker.Tiktok += ExerciseAdd;
            ticker.Tiktok += ExerciseRemove;
            ticker.Tiktok += ChangeGenderOnExArea;
            #endregion

            //Asking user for month, day, days to simulate and speed of program
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
               $"Time before first exercise: {hamster.Id.ToString().PadLeft(5).PadRight(15)} | Activites Count: PadLeft(5)");
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
                        cage[i].hamsters[statsToAdd].CurrentActivity = "In cage";
                        statsToAdd++;
                        mCounter++;
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters.Add(female[fCounter]);
                        cage[i].hamsters[statsToAdd].CageId = cage[i].Id;
                        cage[i].hamsters[statsToAdd].CheckInTime = time.StartTime;
                        cage[i].hamsters[statsToAdd].CurrentActivity = "In cage";
                        statsToAdd++;
                        fCounter++;
                    }
                }
                statsToAdd = 0;
                hdb.SaveChanges();
            }
        }
        private async Task RemoveHamsters()
        {
            await Task.Delay(10);
            var cage = hdb.Cages.ToArray();

            int counter = 0;

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsters.Count != 0)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsters[counter].CageId = null;
                        cage[i].hamsters[counter].OldCageId = null;
                        cage[i].hamsters[counter].ExerciseAreaId = null;
                        cage[i].hamsters[counter].CheckInTime = null;
                        cage[i].hamsters[counter].TimeOfLastExercise = null;
                        cage[i].hamsters[counter].CurrentActivity = "Home";
                        cage[i].hamsters.Remove(cage[i].hamsters[counter]);
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters[counter].ExerciseAreaId = null;
                        cage[i].hamsters[counter].CageId = null;
                        cage[i].hamsters[counter].OldCageId = null;
                        cage[i].hamsters[counter].CheckInTime = null;
                        cage[i].hamsters[counter].TimeOfLastExercise = null;
                        cage[i].hamsters[counter].CurrentActivity = "Home";
                        cage[i].hamsters.Remove(cage[i].hamsters[counter]);
                    }
                }
                hdb.SaveChanges();
            }
        }
        private void ChangeGenderOnExArea(object sender, EventArgs e)
        {
            var exA = hdb.ExerciseAreas.ToArray().First();

            if (ticker.tick == 0 || ticker.tick == 60)
            {
                exA.Gender = Gender.Male;
            }
            else if (ticker.tick == 30 || ticker.tick == 90)
            {
                exA.Gender = Gender.Female;
            }
            return;
        }
        private void ExerciseAdd(object sender, EventArgs e)
        {
            var hamsters = new List<Hamster>();
            var exA = hdb.ExerciseAreas.ToArray().First();
            var cage = hdb.Cages.ToArray();

            foreach (var item in hdb.Cages)
            {
                for (int i = 0; i < item.hamsters.Count; i++)
                {
                    hamsters.Add(item.hamsters[i]);
                }
            }
            var orderedList = hamsters.Select(c => c).OrderBy(c => c.TimeOfLastExercise).OrderBy(c => c.OldCageId).ToList();
            for (int i = 0; i < orderedList.Count; i++)
            {
                if (!exA.IsFull)
                {
                    if (exA.Gender == Gender.Male && orderedList[i].Gender == Gender.Male)
                    {
                        exA.hamsters.Add(orderedList[i]);
                        orderedList[i].OldCageId = orderedList[i].CageId;
                        orderedList[i].CageId = null;
                        orderedList[i].CurrentActivity = "Exercising";
                        orderedList[i].ExerciseAreaId = 1;

                        for (int j = 0; j < cage.Length; j++)
                        {
                            if (cage[j].hamsters.Contains(orderedList[i]))
                            {
                                cage[j].hamsters.Remove(orderedList[i]);
                            }
                        }
                    }
                    else if (exA.Gender == Gender.Female && orderedList[i].Gender == Gender.Female)
                    {
                        exA.hamsters.Add(orderedList[i]);
                        orderedList[i].OldCageId = orderedList[i].CageId;
                        orderedList[i].CageId = null;
                        orderedList[i].CurrentActivity = "Exercising";
                        orderedList[i].ExerciseAreaId = 1;

                        for (int j = 0; j < cage.Length; j++)
                        {
                            if (cage[j].hamsters.Contains(orderedList[i]))
                            {
                                cage[j].hamsters.Remove(orderedList[i]);
                            }
                        }
                    }
                }
                hdb.SaveChanges();
            }
        }
        private void ExerciseRemove(object sender, EventArgs e)
        {
            if (ticker.tick == 9 || ticker.tick == 9 + tickMultiplier)
            {
                tickMultiplier += 10;

                var exA = hdb.ExerciseAreas.ToArray().First();
                var hej = exA.hamsters.ToList();
                var hamsters = new List<Hamster>();
                var cage = hdb.Cages.ToArray();

                foreach (var hamster in hej)
                {
                    hamsters.Add(hamster);
                    exA.hamsters.Remove(hamster);
                    hamster.TimeOfLastExercise = time.CurrentTime;
                    for (int i = 0; i < cage.Length; i++)
                    {
                        if (cage[i].Id == hamster.OldCageId)
                        {
                            cage[i].hamsters.Add(hamster);
                            hamster.CageId = cage[i].Id;
                            hamster.CurrentActivity = "In Cage";
                            hamster.ExerciseAreaId = null;
                            hamster.OldCageId = null;
                        }
                    }
                    hdb.SaveChanges();
                }
            }
        }
    }
}
