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
                    if (personDto.Name == null || personDto.Email == null || personDto.Password == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var firstName = PersonName(personDto.Name);
                        var email = PersonEmail(personDto.Email);
                        var password = PersonPassword(personDto.Password);

                        var person = new Person
                        {
                            Name = personDto.Name,
                            Email = personDto.Email,
                            Password = personDto.Password
                        };

                        context.People.Add(person);

                        Console.WriteLine($"Record {person.Name} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        }

        private static object PersonPassword(string password)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Password == password);
            }
        }

        private static object PersonEmail(string email)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Email == email);
            }
        }

        private static object PersonName(string name)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.People.FirstOrDefault(a => a.Name == name);
            }
        }
    }
}
