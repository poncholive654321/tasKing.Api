using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Tasking.API.Models;

namespace Tasking.API.DAL
{
    public class TaskingContext : DbContext
    {

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Project> Projects { get; set; }

        public TaskingContext() : base("AuthContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}