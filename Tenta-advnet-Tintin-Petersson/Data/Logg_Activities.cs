﻿using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class Logg_Activities
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }

    }
}