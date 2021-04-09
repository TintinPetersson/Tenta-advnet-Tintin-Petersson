using System;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    class Program
    {
        static void Main()
        {
            //Calls the "new" main method, to make it async
            MainAsync().GetAwaiter().GetResult();
        }
        private static async Task MainAsync()
        {
            //If database exists it wont do anything. Otherwise it will UPDATE-DATABASE and create it.
            var dbContext = new HamsterDbContext();
            await Task.Run(() => dbContext.Database.EnsureCreatedAsync());

            Simulation sim = new Simulation();
            await Task.Run(() => sim.Start());
            Console.ReadLine();
        }
    }
}
