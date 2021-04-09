using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    internal enum Activities { CheckIn, Exercise, DayCage, CheckOut }
    internal class Activity
    {
        internal int Id { get; set; }
        internal Activities ActivityType { get; set; }
        internal DateTime? StartTime { get; set; }
        internal DateTime? EndTime { get; set; }
        internal TimeSpan? Duration { get => EndTime - StartTime; }
        internal int? ActivityLogId { get; set; }
        internal virtual ActivityLog ActivityLog { get; set; }
    }
}