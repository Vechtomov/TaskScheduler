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

        public int? Priority { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}