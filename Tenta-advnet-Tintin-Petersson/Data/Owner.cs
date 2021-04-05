using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }

    }
}