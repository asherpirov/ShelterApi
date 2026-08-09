using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Data
{
    public class ShelterDbContext : DbContext
    {
        public ShelterDbContext(DbContextOptions<ShelterDbContext> options)
            :base(options) { }

        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<Shelter> Shelters { get; set; } = null!;
        public DbSet<Inspection> Inspections { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Shelter>()
                .HasOne(s => s.Area)
                .WithMany(s => s.Shelters)
                .HasForeignKey(s => s.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inspection>()
                .HasOne(i => i.Shelter)
                .WithMany(i => i.Inspections)
                .HasForeignKey(i => i.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
