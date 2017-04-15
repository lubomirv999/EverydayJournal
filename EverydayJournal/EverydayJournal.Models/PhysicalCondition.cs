namespace EverydayJournal.Models
{
    public class PhysicalCondition
    {
        public int Id { get; set; }

        public decimal ChestSize { get; set; }

        public decimal WaistSize { get; set; }

        public decimal Kilograms { get; set; }

        public int ConditionByDateId { get; set; }

        public virtual Date ConditionByDate { get; set; }
    }
}
