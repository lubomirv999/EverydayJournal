namespace EverydayJournal.Import
{
    using Data.Store;
    using Data.Dtos;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;

    public class JsonImport
    {
        public static void ImportPeople()
        {
            var json = File.ReadAllText("../../../datasets/people.json");
            var people = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            PersonStore.AddPeople(people);
        }

        public static void ImportFoods()
        {
            var json = File.ReadAllText("../../../datasets/foods.json");
            var foods = JsonConvert.DeserializeObject<IEnumerable<FoodDto>>(json);
            FoodStore.AddFoods(foods);
        }

        public static void ImportDates()
        {
            var json = File.ReadAllText("../../../datasets/dates.json");
            var dates = JsonConvert.DeserializeObject<IEnumerable<DateDto>>(json);
            DateStore.AddDates(dates);
        }

        public static void ImportTasks()
        {
            var json = File.ReadAllText("../../../datasets/tasks.json");
            var tasks = JsonConvert.DeserializeObject<IEnumerable<TaskDto>>(json);
            TaskStore.AddTasks(tasks);
        }
    }
}