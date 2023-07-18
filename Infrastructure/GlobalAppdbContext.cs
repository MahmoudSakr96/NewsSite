using Microsoft.EntityFrameworkCore;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure
{
    public class GlobalAppdbContext : IdentityDbContext<ApplicationUser, ApplicationRole , int>
    {
        public GlobalAppdbContext(DbContextOptions<GlobalAppdbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=NewsSiteDB;Integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationRole>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser { Id= 10, UserName = "MahmoudSakr", Email = "sakrmahmoud21@gmail.com", EmailConfirmed = true, PasswordHash = "Mahmoud@1234", SecurityStamp = "DC21D266-C24A-4676-BDAE-345D0EE14766" });
        }

    }
}
