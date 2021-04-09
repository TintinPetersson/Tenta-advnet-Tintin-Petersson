using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    internal class ExerciseArea
    {
        internal List<Hamster> hamsters;
        internal int Id { get; set; }
        internal int MaxCapacity { get; set; }
        internal bool IsFull { get => MaxCapacity - hamsters.Count <= 0; }
        internal Gender? Gender { get; set; }
        internal ExerciseArea()
        {
            hamsters = new List<Hamster>();
            MaxCapacity = 6;
        }
    }
}