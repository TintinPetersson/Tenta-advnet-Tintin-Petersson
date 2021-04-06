using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Cage
    {
        public List<Hamster> hamsters;
        public int Id { get; set; }
        public int MaxCapacity { get; private set; }
        public bool IsFull { get => MaxCapacity - hamsters.Count <= 0; }
        public Gender? Gender { get; set; }
        public Cage()
        {
            hamsters = new List<Hamster>();
            MaxCapacity = 3;
        }
        //public int AddHamster(Hamster hamster)
        //{
        //    if (!IsFull)
        //    {
        //        hamsters.Add(hamster);
        //    }
        //    else
        //    {
        //    }
        //}
    }
}