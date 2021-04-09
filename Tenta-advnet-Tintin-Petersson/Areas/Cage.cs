using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    internal class Cage
    {
        internal List<Hamster> hamsters;
        internal int Id { get; set; }
        internal int MaxCapacity { get; private set; }
        internal bool IsFull { get => MaxCapacity - hamsters.Count <= 0; }
        internal Gender? Gender { get; set; }
        internal Cage()
        {
            hamsters = new List<Hamster>();
            MaxCapacity = 3;
        }
    }
}