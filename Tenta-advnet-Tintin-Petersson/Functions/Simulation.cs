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
        private UI UI;
        private HamsterDbContext hdb;
        private int tickMultiplier = 1;
        private int month;
        private int day;
        private int daysToSimulate;
        private int speed;
        public Simulation()
        {
            time = new Time();
            ticker = Ticker.GetInstance();
            UI = new UI();
            hdb = new HamsterDbContext();

        }
        public async Task Start()
        {
            //Subscribers
            #region Subscribers
            StartClock += StartTicker;

            ticker.Tiktok += time.CalculateCurrentTime;
            ticker.Tiktok += StatusReport;
            ticker.Tiktok += ChangeGenderOnExArea;
            ticker.Tiktok += ExerciseRemove;
            ticker.Tiktok += ExerciseAdd;
            #endregion

            //Asking user for month, day, days to simulate and speed of program
            daysToSimulate = UI.GetAmountOfDays();
            month = UI.GetMonth();
            day = UI.GetDay();
            speed = UI.GetSpeed();
            await Task.Run(() => time.CalculateStartTime(month, day));
            await Task.Run(() => RemoveActivities());
            await Task.Run(() => RemoveLog());
            await Task.Run(() => AddHamsters());

            //Invoking the event/simulation to start
            await Task.Run(() => StartClock?.Invoke(this, EventArgs.Empty));
        }
        private async void StartTicker(object sender, EventArgs e)
        {
            //Runs the event "Ticking", which has numerous subscribers
            while (ticker.tick <= 100 * daysToSimulate + 1)
            {
                if (time.CurrentTime == time.StartTime.AddHours(10) && daysToSimulate > 1)
                {
                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => this.UI.PrintReport(dailyReport));

                    ticker.counter += 1;
                    ticker.tick = 0;
                    daysToSimulate--;
                    tickMultiplier = 0;

                    await Task.Run(() => RemoveHamsters());
                    time.StartTime = time.CurrentTime.AddHours(14);
                    await Task.Run(() => AddHamsters());
                    await Task.Run(() => ticker.Ticking(speed));
                }
                else if (time.CurrentTime == time.StartTime.AddHours(10) && daysToSimulate <= 1)
                {
                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => this.UI.PrintReport(dailyReport));
                    await Task.Run(() => RemoveHamsters());
                    break;
                }
                else
                {
                    await Task.Run(() => ticker.Ticking(speed));
                }
            }
        }
        private void AddHamsters()
        {
            var hamster = hdb.Hamsters.ToList();
            var cage = hdb.Cages.ToArray();

            var female = hamster
                .Select(c => c)
                .Where(c => c.Gender == Gender.Male)
                .OrderBy(c => c.Name)
                .ToList();

            var male = hamster
                .Select(c => c)
                .Where(c => c.Gender == Gender.Female)
                .OrderBy(c => c.Name)
                .ToList();

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

                        var activity = new Activity { ActivityType = Activities.CheckIn, StartTime = time.StartTime };
                        var log = new ActivityLog { Hamster = male[mCounter], Date = time.DateString, Activities = new List<Activity>() };

                        log.Activities.Add(activity);

                        if (male[mCounter].ActivityLogger == null)
                        {
                            male[mCounter].ActivityLogger = new List<ActivityLog>();
                        }

                        male[mCounter].ActivityLogger.Add(log);

                        cage[i].hamsters[statsToAdd].OldCageId = null;
                        cage[i].hamsters[statsToAdd].TimeOfLastExercise = null;
                        cage[i].hamsters[statsToAdd].CageId = cage[i].Id;
                        cage[i].hamsters[statsToAdd].CheckInTime = time.StartTime;
                        cage[i].hamsters[statsToAdd].CurrentActivity = "In cage";

                        statsToAdd++;
                        mCounter++;
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsters.Add(female[fCounter]);

                        var activity = new Activity { ActivityType = Activities.CheckIn, StartTime = time.StartTime };
                        var log = new ActivityLog { Hamster = female[fCounter], Date = time.DateString, Activities = new List<Activity>() };

                        log.Activities.Add(activity);

                        if (female[fCounter].ActivityLogger == null)
                        {
                            female[fCounter].ActivityLogger = new List<ActivityLog>();
                        }

                        female[fCounter].ActivityLogger.Add(log);

                        cage[i].hamsters[statsToAdd].OldCageId = null;
                        cage[i].hamsters[statsToAdd].TimeOfLastExercise = null;
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
        private void RemoveHamsters()
        {
            var cage = hdb.Cages.ToArray();
            int counter = 0;

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsters.Count != 0)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        var activity = new Activity { ActivityType = Activities.CheckOut, StartTime = time.CurrentTime };

                        var log = hdb.ActivityLogs
                            .Select(c => c)
                            .Where(c => c.HamsterId == cage[i].hamsters[counter].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLog = log;
                        log.Activities.Add(activity);

                        var endTime = log.Activities
                            .Select(c => c)
                            .Where(c => c.ActivityType == Activities.DayCage)
                            .OrderBy(c => c.StartTime)
                            .Last();

                        endTime.EndTime = time.CurrentTime;

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
                        var activity = new Activity { ActivityType = Activities.CheckOut, StartTime = time.CurrentTime };

                        var log = hdb.ActivityLogs
                            .Select(c => c)
                            .Where(c => c.HamsterId == cage[i].hamsters[counter].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLog = log;
                        log.Activities.Add(activity);

                        var endTime = log.Activities
                            .Select(c => c)
                            .Where(c => c.ActivityType == Activities.DayCage)
                            .OrderBy(c => c.StartTime)
                            .Last();

                        endTime.EndTime = time.CurrentTime;

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
            var orderedList = hamsters
                .Select(c => c)
                .OrderBy(c => c.TimeOfLastExercise)
                .ToList();

            for (int i = 0; i < orderedList.Count; i++)
            {
                if (!exA.IsFull && time.CurrentTime != time.StartTime.AddHours(10))
                {
                    if (exA.Gender == Gender.Male && orderedList[i].Gender == Gender.Male)
                    {
                        //Adding hamster
                        exA.hamsters.Add(orderedList[i]);

                        //Adding activity
                        var activity = new Activity { ActivityType = Activities.Exercise, StartTime = time.CurrentTime };

                        var log = hdb.ActivityLogs
                            .Select(c => c)
                            .Where(c => c.HamsterId == orderedList[i].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLog = log;
                        log.Activities.Add(activity);

                        if (log.Activities.Count > 2)
                        {
                            var endTime = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.DayCage)
                                .OrderBy(c => c.StartTime)
                                .Last();

                            endTime.EndTime = time.CurrentTime;
                        }
                        else
                        {
                            var endTime = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.CheckIn)
                                .First();

                            endTime.EndTime = time.CurrentTime;
                        }

                        //Setting properties
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
                        //Adding hamster
                        exA.hamsters.Add(orderedList[i]);

                        //Adding activity
                        var activity = new Activity { ActivityType = Activities.Exercise, StartTime = time.CurrentTime };

                        var log = hdb.ActivityLogs
                            .Select(c => c)
                            .Where(c => c.HamsterId == orderedList[i].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLog = log;
                        log.Activities.Add(activity);

                        if (log.Activities.Count > 2)
                        {
                            var endTime = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.DayCage)
                                .OrderBy(c => c.StartTime)
                                .Last();

                            endTime.EndTime = time.CurrentTime;
                        }
                        else
                        {
                            var endTime = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.CheckIn)
                                .First();

                            endTime.EndTime = time.CurrentTime;
                        }

                        //Setting properties
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
            if (time.CurrentTime == time.StartTime.AddHours(tickMultiplier))
            {
                tickMultiplier += 1;

                var exA = hdb.ExerciseAreas.ToArray().First();
                var ham = exA.hamsters.ToList();
                var hamsters = new List<Hamster>();
                var cage = hdb.Cages.ToArray();

                foreach (var hamster in ham)
                {
                    //Adding to temporary list
                    hamsters.Add(hamster);

                    //Adding new activity and setting endtime for last activity
                    var activity = new Activity { ActivityType = Activities.DayCage, StartTime = time.CurrentTime };

                    var log = hdb.ActivityLogs
                        .Select(c => c)
                        .Where(c => c.HamsterId == hamster.Id)
                        .Where(c => c.Date == time.DateString)
                        .First();

                    activity.ActivityLog = log;
                    log.Activities.Add(activity);

                    var endTime = log.Activities
                        .Select(c => c)
                        .Where(c => c.ActivityType == Activities.Exercise)
                        .OrderBy(c => c.StartTime)
                        .Last();

                    endTime.EndTime = time.CurrentTime;

                    //Removing from exercise area
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
        private void RemoveLog()
        {
            if (hdb.ActivityLogs != null)
            {
                var rows = hdb.ActivityLogs.Select(logger => logger).ToList();
                foreach (var row in rows)
                {
                    hdb.ActivityLogs.Remove(row);
                }
            }
            hdb.SaveChanges();
        }
        private void RemoveActivities()
        {
            if (hdb.Activities != null)
            {
                var rows = hdb.Activities.Select(activity => activity).ToList();
                foreach (var row in rows)
                {
                    hdb.Activities.Remove(row);
                }
            }
            hdb.SaveChanges();
        }
        private void ChangeGenderOnExArea(object sender, EventArgs e)
        {
            var exA = hdb.ExerciseAreas.ToArray().First();

            if (time.CurrentTime == time.StartTime || time.CurrentTime == time.StartTime.AddHours(6))
            {
                exA.Gender = Gender.Male;
            }
            else if (time.CurrentTime == time.StartTime.AddHours(3) || time.CurrentTime == time.StartTime.AddHours(9))
            {
                exA.Gender = Gender.Female;
            }
            return;
        }
        private async void StatusReport(object sender, EventArgs e)
        {
            var gender = hdb.ExerciseAreas.Select(c => c.Gender).First();
            var exA = hdb.ExerciseAreas.ToArray();
            var cage = hdb.Cages.Select(c => c.hamsters).ToList();

            int exACounter = 0;
            int counter = 1;

            for (int i = 0; i < exA.Length; i++)
            {
                exACounter = exA[i].hamsters.Count;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tick: {ticker.tick}");
            sb.AppendLine($"Day: {ticker.counter}");
            sb.AppendLine($"Current time: { time.CurrentTime.ToString()}");
            cage.Select(c => c.Count).ToList().ForEach(c => sb.AppendLine($"Cage: {counter++.ToString().PadLeft(1).PadRight(2)} | Amount : {c.ToString().PadLeft(1).PadRight(2)}"));
            sb.AppendLine($"Amount in exercise area: {exACounter} | Gender: {gender}");

            string send = sb.ToString();
            await Task.Run(() => this.UI.StatusReport(send));
        }
        private string DailyReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hamster in hdb.Hamsters)
            {
            
                //Time before firt exercise and check in
                var timeBeforeExercise = hamster.ActivityLogger
                    .Select(c => c)
                    .OrderBy(c => c.Date)
                    .Last().Activities
                    .Select(c => c)
                    .Where(c => c.ActivityType == Activities.CheckIn)
                    .First().Duration;

                var fixedTimeFormat = string.Format("{0:hh} Hours", timeBeforeExercise);

                //Amount of activities for the day
                var count = hamster.ActivityLogger
                    .Select(c => c)
                    .Where(c => c.Hamster == hamster)
                    .ToList()
                    .OrderBy(c => c)
                    .Last().Activities
                    .Where(c => c.ActivityType == Activities.Exercise)
                    .Count();

                if (hamster.Gender == Gender.Male) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                else { Console.ForegroundColor = ConsoleColor.DarkCyan; }

                //Creating stringbuilder
                sb.AppendLine($"\t\tName: {hamster.Name.PadLeft(5).PadRight(15)} " +
                $"| Wait for exercise: {fixedTimeFormat.PadLeft(5).PadRight(15)} | " +
                $"Amount of activities: {count.ToString()}");
                Console.ResetColor();
            }
            return sb.ToString();
        }
        
    }
}
