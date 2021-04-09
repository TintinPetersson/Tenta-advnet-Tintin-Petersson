using System;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }
        private static async Task MainAsync()
        {
            var dbContext = new HamsterDbContext();
            await Task.Run(() => dbContext.Database.EnsureCreatedAsync());

            Simulation sim = new Simulation();
            await Task.Run(() => sim.Start());
            Console.ReadLine();
        }
    }
}
