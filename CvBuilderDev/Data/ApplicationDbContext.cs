using System;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<HeaderModel> Header { get; set; }

        public DbSet<WorkExperienceModel> WorkExperience { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserDetailsModel> UserDetails { get; set; }

        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkExperienceModel>()
                 .HasKey(x => x.Id);

            modelBuilder.Entity<UserModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserDetailsModel>()
                .HasKey(x => x.Id);
        }
    }
}

