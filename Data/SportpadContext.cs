
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sportpad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Data
{
    public class SportpadContext: IdentityDbContext<ApplicationUser>
    {
        public SportpadContext(DbContextOptions<SportpadContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<EventUser> EventsUser { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Sport>().ToTable("Sport");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<EventUser>().ToTable("EventUser");

        }
    }
}
