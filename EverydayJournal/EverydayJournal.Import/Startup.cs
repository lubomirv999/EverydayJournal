using System;
using System.Linq;
using EverydayJournal.Data;
using EverydayJournal.Data.Store;

namespace EverydayJournal.Import
{
    public class Startup
    {
        public static void Main()
        {
            // Date must contain collection of food and tasks in the JSON - idk if needs

            //Importing Data
            
            ////Import Date
            //ImportDates();

            ////Import People
            //JsonImport.ImportPeople();  

            ////Import Food
            //JsonImport.ImportFoods(); 

            ////Import Tasks
            //JsonImport.ImportTasks();

            ////Import random foods to people
            //PersonStore.AddFoods();

            ////Import random tasks to people
            //PersonStore.AddTasks();

            //Check if addfoods and addtasks works properly
            //var context = new EverydayJournalContext();
            //var people = context.People;
            //foreach (var person in people)
            //{
            //    Console.WriteLine(person.Name);


            //    foreach (var food in person.Foods)
            //    {
            //        Console.WriteLine(food.Name);
            //    }
            //    foreach (var task in person.Tasks)
            //    {
            //        Console.WriteLine(task.Name);
            //    }
            //    Console.WriteLine("--------------------");
            //}
        }
    }
}