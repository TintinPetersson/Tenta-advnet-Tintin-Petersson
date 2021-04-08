using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int? HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}