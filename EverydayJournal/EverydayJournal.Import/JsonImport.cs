namespace EverydayJournal.Import
{
    using Data.Store;
    using EverydayJournal.Data.Dtos;
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

        public static void ImportConditions()
        {
            var json = File.ReadAllText("../../../datasets/conditions.json");
            var conditions = JsonConvert.DeserializeObject<IEnumerable<PhysicalConditionDto>>(json);
            PhysicalConditionStore.AddConditions(conditions);
        }
    }
}
