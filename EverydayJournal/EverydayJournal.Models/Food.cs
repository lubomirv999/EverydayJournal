namespace EverydayJournal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual int DateId { get; set; }

        public virtual Date Date { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}