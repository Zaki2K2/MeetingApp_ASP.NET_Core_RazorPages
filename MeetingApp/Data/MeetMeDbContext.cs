using MeetingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MeetingApp.Data
{
    public class MeetMeDbContext : DbContext
    {
        public MeetMeDbContext() {}
        public MeetMeDbContext(DbContextOptions<MeetMeDbContext> options) : base(options) { }

        public DbSet<Information> Informations { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Information>()
                .HasKey(i => i.Info_id); // Ensure primary key is defined

            modelBuilder.Entity<User>()
                .HasKey(u => u.U_id); // Ensure primary key is defined
        }

    }
}
