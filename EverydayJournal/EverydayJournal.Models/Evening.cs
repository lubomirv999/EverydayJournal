namespace EverydayJournal.Models
{
    public class Evening
    {
        public int Id { get; set; }

        public virtual Food Food { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

        public int DateId { get; set; }

        public virtual Date Date { get; set; }
    }
}
