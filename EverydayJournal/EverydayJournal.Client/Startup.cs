namespace EverydayJournal.Client
{
    using Data;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            EverydayJournalContext.Create();
            var context = new EverydayJournalContext();
            
            Console.WriteLine(context.People.Count());
        }
    }
}