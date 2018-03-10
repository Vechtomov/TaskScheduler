using System;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.Models
{
    public class GoalAction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }

        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}