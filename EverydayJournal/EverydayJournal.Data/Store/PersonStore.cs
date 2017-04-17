using System.Linq;

namespace EverydayJournal.Data.Store
{
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;

    public class PersonStore
    {
        public static void AddPeople(IEnumerable<PersonDto> people)
        {
            using (var context = new EverydayJournalContext())
            {
                foreach (var personDto in people)
                {
                    if (personDto.Name == null || 
                        personDto.Email == null || 
                        personDto.Password == null ||
                        personDto.PhysicalCondition == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var person = new Person
                        {
                            Name = personDto.Name,
                            Email = personDto.Email,
                            Password = personDto.Password,
                            PhysicalCondition = personDto.PhysicalCondition
                        };

                        context.People.Add(person);

                        Console.WriteLine($"Record {person.Name} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        }

        public static void AddFoods()
        {
            using (var context = new EverydayJournalContext())
            {
                var people = context.People.ToList();
                var foods = context.Foods.ToList();

                int index = 1;

                foreach (var person in people)
                {
                    if (index == 9)
                    {
                        index = 1;
                    } 

                    person.Foods.Add(foods[index]);
                    person.Foods.Add(foods[index + 1]);
                    
                    index++;
                }
            }
        }

        public static void AddTasks()
        {
            using (var context = new EverydayJournalContext())
            {
                var people = context.People.ToList();
                var tasks = context.Tasks.ToList();

                int index = 1;

                foreach (var person in people)
                {
                    if (index == 9)
                    {
                        index = 1;
                    }

                    person.Tasks.Add(tasks[index]);
                    person.Tasks.Add(tasks[index + 1]);

                    index++;
                }
            }
        }
    }
}