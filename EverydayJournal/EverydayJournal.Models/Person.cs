namespace EverydayJournal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public int PhysicalConditionId { get; set; }

        public virtual PhysicalCondition PhysicalCondition { get; set; }
    }
}