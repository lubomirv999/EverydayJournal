using System;
using EverydayJournal.Models;

namespace EverydayJournal.Data.Migrations
{
    using System.Data.Entity.Migrations;

   public sealed class Configuration : DbMigrationsConfiguration<EverydayJournal.Data.EverydayJournalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EverydayJournal.Data.EverydayJournalContext";
        }

        protected override void Seed(EverydayJournalContext context)
        {
            // if add or update doesn't work use if statement
            // if (!context.Dates.Any())
            // {
            var people = new Person[]
            {
                new Person()
                {
                    Name = "Ivan Stanislavov",
                    Date = new Date() {ExactDate = new DateTime(2017, 4, 15)},
                    Foods =
                    {
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 15)
                            },
                            Name = "Salamche"
                        },
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 14)
                            },
                            Name = "Avocado salad"
                        },
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 13)
                            },
                            Name = "Shopska salad with kebapche"
                        }
                    },
                    Tasks =
                    {
                        new Task()
                        {
                            Date = new Date() {ExactDate = new DateTime(2017, 4, 15)},
                            Name = "Clean the house"
                        },
                        new Task()
                        {
                            Date = new Date() {ExactDate = new DateTime(2017, 4, 15)},
                            Name = "Go for a walk"
                        },
                        new Task()
                        {
                            Date = new Date() {ExactDate = new DateTime(2017, 4, 10)},
                            Name = "Check my friend"
                        }
                    },
                    PhysicalCondition =
                        new PhysicalCondition()
                        {
                            ChestSize = 120.00m,
                            WaistSize = 90.00m,
                            Kilograms = 78.9m
                        }
                },
                new Person()
                {
                    Name = "Mariika Petrova",
                    Date = new Date() {ExactDate = new DateTime(2017, 4, 15)},
                    Foods =
                    {
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 15)
                            },
                            Name = "Marakuya juice"
                        },
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 14)
                            },
                            Name = "Yogurt"
                        },
                        new Food()
                        {
                            Date = new Date()
                            {
                                ExactDate = new DateTime(2017, 4, 13)
                            },
                            Name = "Fruit salad"
                        }
                    },
                    Tasks =
                    {
                        new Task()
                        {
                            Date = new Date() {ExactDate = new DateTime(2017, 4, 11)},
                            Name = "Take my dog for a walk"
                        },
                        new Task()
                        {
                            Date = new Date() {ExactDate = new DateTime(2017, 4, 10)},
                            Name = "Finish my project"
                        }
                    },
                    PhysicalCondition =
                        new PhysicalCondition()
                        {
                            ChestSize = 83.2m,
                            WaistSize = 60.00m,
                            Kilograms = 50.00m
                        }
                }
            };

            foreach (var person in people)
            {
                context.People.AddOrUpdate(
                    p => p.Name, person);
            }
            // }
        }
    }
}