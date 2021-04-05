using System;

namespace Tenta_advnet_Tintin_Petersson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancing the simulation to start
            Simulations sim = new Simulations();
            sim.Start();
            Console.ReadLine();
        }
    }
}
