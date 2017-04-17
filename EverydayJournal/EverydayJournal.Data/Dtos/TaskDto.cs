namespace EverydayJournal.Data.Dtos
{
    public class TaskDto
    {
        public string Name { get; set; }

        public virtual int DateId { get; set; }

        public virtual int PersonId { get; set; }
    }
}