using System;
using System.Collections.Generic;

namespace Tenta_advnet_Tintin_Petersson
{
    public enum Gender { Male, Female }
    public class Hamster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public string CurrentActivity { get; set; }
        public int? CageId { get; set; }
        public int? OldCageId { get; set; }
        public int? ExerciseAreaId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? TimeOfLastExercise { get; set; }
        public virtual Cage Cage { get; set; }
        public virtual ExerciseArea ExerciseArea { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogger { get; set; }
    }
}