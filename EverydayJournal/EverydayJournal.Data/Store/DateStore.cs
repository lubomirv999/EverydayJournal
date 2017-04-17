namespace EverydayJournal.Data.Store
{
    using Models;
    using System;
    using System.Collections.Generic;

    public class DateStore
    {
        public static void AddDates(IEnumerable<DateDto> dates)
        {
            using (var context = new EverydayJournalContext())
            {
                foreach (var dateDto in dates)
                {
                    if (dateDto.ExactDate == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var date = new Date
                        {
                            ExactDate = dateDto.ExactDate,
                        };

                        context.Dates.Add(date);

                        Console.WriteLine($"Record {date.ExactDate} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
