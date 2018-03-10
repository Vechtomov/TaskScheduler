using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }
        public Project()
        {
            Participants = new List<ApplicationUser>();
        }
    }
}