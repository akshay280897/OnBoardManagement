using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnBoardManagement.Models
{
    public class OnBoardDb : DbContext
    {
        public OnBoardDb():base("DefaultConnection")
        {
            Database.SetInitializer<OnBoardDb>(new CreateDatabaseIfNotExists<OnBoardDb>());
        }

        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<OnBoarder> OnBoarders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
