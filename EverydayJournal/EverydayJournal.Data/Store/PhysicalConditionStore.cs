namespace EverydayJournal.Data.Store
{
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhysicalConditionStore
    {
        public static void AddConditions(IEnumerable<PhysicalConditionDto> conditions)
        {
            using (var context = new EverydayJournalContext())
            {
                foreach (var physicalConditionDto in conditions)
                {
                    if (physicalConditionDto.Name == null || physicalConditionDto.Kilograms == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var name = ConditionName(physicalConditionDto.Name);
                        var kilograms = ConditionKilograms(physicalConditionDto.Kilograms);

                        var condition = new PhysicalCondition
                        {
                            Name = physicalConditionDto.Name,
                            Kilograms = physicalConditionDto.Kilograms,
                        };

                        context.PhysicalConditions.Add(condition);

                        Console.WriteLine($"Record {condition.Name} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        }

        private static object ConditionKilograms(string kilograms)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.PhysicalConditions.FirstOrDefault(a => a.Kilograms == kilograms);
            }
        }

        private static object ConditionName(string name)
        {
            using (var context = new EverydayJournalContext())
            {
                return context.PhysicalConditions.FirstOrDefault(a => a.Name == name);
            }
        }
    }
}
