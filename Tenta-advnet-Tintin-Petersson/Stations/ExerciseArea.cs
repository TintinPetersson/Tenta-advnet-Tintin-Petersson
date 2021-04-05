using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class ExerciseArea
    {
        private List<Hamster> hamsters;
        public int Id { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsFull { get => MaxCapacity - hamsters.Count <= 0; }
        public ExerciseArea()
        {
            hamsters = new List<Hamster>();
            MaxCapacity = 6;
        }
    }
}