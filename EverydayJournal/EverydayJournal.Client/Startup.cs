namespace EverydayJournal.Client
{
    using Data;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            EverydayJournalContext.Create();
            var context = new EverydayJournalContext();
            
            Console.WriteLine(context.People.Count());
        }
    }
}
