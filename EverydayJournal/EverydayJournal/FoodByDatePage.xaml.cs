namespace EverydayJournal
{
    using System.Linq;
    using System.Windows.Controls;
    using Data;
    using Utilities;
    using System;
    using System.Windows;
    using System.Data.Entity.Migrations;
    using Models;
    /// <summary>
    /// Interaction logic for FoodByDatePage.xaml
    /// </summary>
    public partial class FoodByDatePage : Page
    {
        public FoodByDatePage()
        {
            InitializeComponent();
            using (var context = new EverydayJournalContext())
            {
                var foods = context.Foods
                    .Where(x => x.PersonId == LoggerUtility.UserId)
                    .OrderBy(z => z.Date.ExactDate)
                    .Select(y => "Id." + y.Id.ToString() + "    " + y.Name + " - " + y.Date.ExactDate)
                    .ToArray();

                Foods.ItemsSource = foods;
            }
        }

        private void Button_Click_UpdateFood(object sender, System.Windows.RoutedEventArgs e)
        {
            var foodToUpdate = 0;
            //getting selected food Id
            foodToUpdate = int.Parse(Foods.SelectedItem.ToString().Substring(3, 5));

            using (var context = new EverydayJournalContext())
            {
                var updatedFoodName = UpdatedFoodName.Text;

                var food = context.Foods.FirstOrDefault(x => x.Id == foodToUpdate);

                if (updatedFoodName.Length > 5 && updatedFoodName != food.Name && foodToUpdate > 0)
                {
                    food.Name = updatedFoodName;
                    context.SaveChanges();
                    MessageBox.Show("Successfully updated food");

                    //Reloading the page
                    FoodByDatePage foodByDatePage = new FoodByDatePage();
                    this.NavigationService.Navigate(foodByDatePage);
                }
                else
                {
                    MessageBox.Show("There is no changes or selected Food!");
                }
            }
        }

        private void Button_Click_AddFood(object sender, RoutedEventArgs e)
        {
            var foodToAdd = AddFood.Text;
            if (foodToAdd.Length < 5)
            {
                MessageBox.Show("The food should be at least 5 letters long!");
                return;
            }


            using (var context = new EverydayJournalContext())
            {
                var person = context.People.Find(LoggerUtility.UserId);
                var food = new Food()
                {
                    Name = foodToAdd,
                    Date = new Date() { ExactDate = DateTime.Now },
                    Person = person
                };

                context.Foods.AddOrUpdate(food);
                context.SaveChanges();
                MessageBox.Show("Successfully added food");
                //Reloading the page
                FoodByDatePage foodByDatePage = new FoodByDatePage();
                this.NavigationService.Navigate(foodByDatePage);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var selectedFoodId = 0;
            //getting selected food Id
            selectedFoodId = int.Parse(Foods.SelectedItem.ToString().Substring(3, 5));
            using (var context = new EverydayJournalContext())
            {
                var foodToDelete = context.Foods.Where(x => x.Id == selectedFoodId).FirstOrDefault();
                if (foodToDelete != null)
                {
                    context.Foods.Remove(foodToDelete);
                    context.SaveChanges();

                    MessageBox.Show("Successfully deleted food!");

                    //Reloading the page
                    FoodByDatePage foodByDatePage = new FoodByDatePage();
                    this.NavigationService.Navigate(foodByDatePage);
                }
                else
                {
                    MessageBox.Show("There is nothing to delete!");
                }
            }
        }
    }
}
