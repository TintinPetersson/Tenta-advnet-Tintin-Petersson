using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_advnet_Tintin_Petersson
{
    public class HamsterDbContext : DbContext
    {
        DbSet<Hamster> Hamsters { get; set; }
        DbSet<Cage> Cages { get; set; }
        DbSet<ExerciseArea> ExerciseAreas { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Logg_Activities> Logg_Activities { get; set; }
        DbSet<Cage_Buddies> Cage_Buddies { get; set; }
        DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=advTintinPetersson;Trusted_Connection=True;");
            }
        }

    }
}
