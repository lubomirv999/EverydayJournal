using System.Linq;

namespace EverydayJournal.Data.Store
{
    using EverydayJournal.Data.Dtos;
    using Models;
    using System;
    using System.Collections.Generic;

    public class FoodStore
    {
        public static void AddFoods(IEnumerable<FoodDto> foods)
        {
            using (var context = new EverydayJournalContext())
            {
                foreach (var foodDto in foods)
                {
                    if (foodDto.Name == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var food = new Food
                        {
                            Name = foodDto.Name,
                            DateId = foodDto.DateId,
                            PersonId = foodDto.PersonId
                        };

                        context.Foods.Add(food);
                        Console.WriteLine($"Record {food.Name} successfully imported.");
                    }
                }

                context.SaveChanges();
            }
        } 
    }
}
