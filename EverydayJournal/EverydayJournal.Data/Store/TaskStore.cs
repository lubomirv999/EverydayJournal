
namespace EverydayJournal.Data.Store
{
    using EverydayJournal.Data.Dtos;
    using Models;
    using System;
    using System.Collections.Generic;

    public class TaskStore
    {
        public static void AddTasks(IEnumerable<TaskDto> tasks)
        {
            using (var context = new EverydayJournalContext())
            {
                foreach (var taskDto in tasks)
                {
                    if (taskDto.Name == null || taskDto.DateId == null || taskDto.PersonId == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var task = new Task
                        {
                            Name = taskDto.Name,
                            DateId = taskDto.DateId,
                            PersonId = taskDto.PersonId
                        };

                        context.Tasks.Add(task);
                        Console.WriteLine($"Record {task.Name} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
