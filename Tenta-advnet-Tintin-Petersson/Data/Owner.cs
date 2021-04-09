using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    internal class Owner
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal virtual ICollection<Hamster> Hamsters { get; set; }

    }
}