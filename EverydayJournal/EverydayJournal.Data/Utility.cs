namespace EverydayJournal.Data
{
    public class Utility
    {
        public static void InitDB()
        {
            var context = new EverydayJournalContext();
            context.Database.Initialize(true);
        }
    }
}