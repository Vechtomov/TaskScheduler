using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TaskScheduler.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Task> Tasks { get; set; }
        
        public ApplicationUser()
        {
            Tasks = new List<Task>();
        }
    }
}