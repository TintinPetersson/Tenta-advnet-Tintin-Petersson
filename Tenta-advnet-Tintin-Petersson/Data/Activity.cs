using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public enum Activities { CheckIn, Exercise, DayCage, CheckOut }
    public class Activity
    {
        public int Id { get; set; }
        public Activities ActivityType { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get => EndTime - StartTime; }
        public int? ActivityLogId { get; set; }
        public virtual ActivityLog ActivityLog { get; set; }
    }
}