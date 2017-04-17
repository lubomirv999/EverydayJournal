namespace EverydayJournal.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PhysicalCondition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Kilograms { get; set; }
    }
}
