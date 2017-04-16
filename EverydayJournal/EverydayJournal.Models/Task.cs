namespace EverydayJournal.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual int DateId { get; set; }

        public virtual Date Date { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
