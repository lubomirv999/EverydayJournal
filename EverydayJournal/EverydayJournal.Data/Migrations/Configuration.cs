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
            // use the if statement id AddOrUpdate method doesn't work

            // if (!context.Dates.Any())
            // {
            var dates = new Date[]
            {
                new Date() {ExactDate = new DateTime(2017, 4, 15)},
                new Date() {ExactDate = new DateTime(2017, 4, 14)},
                new Date() {ExactDate = new DateTime(2017, 4, 13)},
                new Date() {ExactDate = new DateTime(2017, 4, 12)},
                new Date() {ExactDate = new DateTime(2017, 4, 11)},
                new Date() {ExactDate = new DateTime(2017, 4, 10)},
                new Date() {ExactDate = new DateTime(2017, 4, 9)},
                new Date() {ExactDate = new DateTime(2017, 4, 8)},
                new Date() {ExactDate = new DateTime(2017, 4, 7)},
                new Date() {ExactDate = new DateTime(2017, 4, 6)},
                new Date() {ExactDate = new DateTime(2017, 4, 5)},
                new Date() {ExactDate = new DateTime(2017, 4, 4)},
                new Date() {ExactDate = new DateTime(2017, 4, 3)},
                new Date() {ExactDate = new DateTime(2017, 4, 2)},
                new Date() {ExactDate = new DateTime(2017, 4, 1)}
            };

            //foreach (var date in dates)
            //{
            //    context.Dates.AddOrUpdate(d => d.ExactDate, date);
            //}

            var tasksNames = new string[]
            {
                "Go for a walk",
                "Clean the house",
                "Change my diet",
                "Go to the gym",
                "Skip gym today",
                "Buy vegetables",
                "Finish the project",
                "Eat healthy",
                "Cook dinner",
                "Get my kid from school",
                "Buy beer",
                "Do the laundry",
                "Call mom",
                "Water the flowers",
                "Edit my journal",
                "Drink more water",
                "Go out with friends",
                "Search for good restaurant",
                "Go to dances",
                "Relax",
                "Code"
            };

            var foodsNames = new string[]
            {
                "Avocado",
                "Fruit salad",
                "Vegetable salad",
                "Marakuya",
                "Mango",
                "Strawberries",
                "Blueberries",
                "Shopska salad",
                "Chicken",
                "Chicken with rice",
                "Green vegetables",
                "Carrots",
                "Yogurt",
                "Peppers",
                "Spinach"
            };

            //for (int i = 0; i < dates.Length; i++)
            //{
            //    context.Tasks.AddOrUpdate(t => t.Name, new Task() {Name = tasksNames[i], DateId = i + 1});
            //    context.Foods.AddOrUpdate(f => f.Name, new Food() {Name = foodsNames[i], DateId = i + 1});
            //}
            //context.SaveChanges();
            // }
        }
    }
}