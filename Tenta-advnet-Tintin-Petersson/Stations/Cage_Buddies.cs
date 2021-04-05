using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Cage_Buddies
    {
        private List<Hamster> hamsters;
        public int Id { get; set; }
        public int MaxCapacity { get; private set; }
        public bool IsFull { get => MaxCapacity - hamsters.Count <= 0; }
        public Gender? Gender { get; set; }
        public int CageId { get; set; }
        public virtual Cage Cage { get; set; }
        public Cage_Buddies()
        {
            hamsters = new List<Hamster>();
            MaxCapacity = 3;
        }
    }
}