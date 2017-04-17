namespace EverydayJournal.Data.Store
{
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        private static Person GetPersonByPassword(string password)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Password == password);
            }
        }

        private static Person GetPersonByEmail(string email)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Email == email);
            }
        }

        private static Person GetPersonByName(string name)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Name == name);
            }
        }
    }
}