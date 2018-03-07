using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.Models
{
    public class Goal
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public string Level { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime? CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? Progress { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<GoalAction> Actions { get; set; }

        public Goal()
        {
            Actions = new List<GoalAction>();
        }
    }
}