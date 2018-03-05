using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Статус")]
        public bool IsCompleted { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}