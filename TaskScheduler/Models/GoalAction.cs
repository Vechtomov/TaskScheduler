using System;

namespace TaskScheduler.Models
{
    public class GoalAction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }

        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}