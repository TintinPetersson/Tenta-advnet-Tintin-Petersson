using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    internal enum Gender { Male, Female }
    internal class Hamster
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal Gender Gender { get; set; }
        internal int Age { get; set; }
        internal int OwnerId { get; set; }
        internal string CurrentActivity { get; set; }
        internal int? CageId { get; set; }
        internal int? OldCageId { get; set; }
        internal int? ExerciseAreaId { get; set; }
        internal DateTime? CheckInTime { get; set; }
        internal DateTime? TimeOfLastExercise { get; set; }
        internal virtual Cage Cage { get; set; }
        internal virtual ExerciseArea ExerciseArea { get; set; }
        internal virtual Owner Owner { get; set; }
        internal virtual ICollection<ActivityLog> ActivityLogger { get; set; }
    }
}