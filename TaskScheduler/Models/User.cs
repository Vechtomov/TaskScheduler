using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TaskScheduler.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }

        public ApplicationUser()
        {
            Tasks = new List<Task>();
            Projects = new List<Project>();
            Goals = new List<Goal>();
        }
    }
}