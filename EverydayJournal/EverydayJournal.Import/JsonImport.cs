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
    }
}