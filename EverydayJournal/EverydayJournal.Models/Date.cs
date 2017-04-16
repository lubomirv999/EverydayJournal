namespace EverydayJournal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Date
    {
        public Date()
        {
            this.Foods = new HashSet<Food>();
            this.Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime ExactDate { get; set; }

        public virtual int PhysicalConditionId { get; set; }

        public virtual PhysicalCondition PhysicalCondition { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}