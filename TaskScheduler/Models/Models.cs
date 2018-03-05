using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskScheduler.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<GoalAction> GoalActions { get; set; }
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}