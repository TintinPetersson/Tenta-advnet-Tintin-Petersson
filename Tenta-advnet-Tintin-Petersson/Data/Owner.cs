using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }

    }
}