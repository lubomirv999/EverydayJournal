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

            //Tittle of the Page
            TitleFoods.Content = (LoggerUtility.UserName ?? "User") + " Foods";

            using (var context = new EverydayJournalContext())
            {
                //Getting ID, Name and Date for each food from the DB for the currently logged User
                var foods = context.Foods
                    .Where(x => x.PersonId == LoggerUtility.UserId)
                    .OrderBy(z => z.Date.ExactDate)
                    .Select(y => "Id." + y.Id.ToString() + "    " + y.Name + " - " + y.Date.ExactDate)
                    .ToArray();

                //Loading Foods in the List Box
                Foods.ItemsSource = foods;
            }
        }

        private void Button_Click_UpdateFood(object sender, RoutedEventArgs e)
        {
            try
            {
                var foodToUpdate = 0;

                //Getting selected food Id from the List box 
                foodToUpdate = int.Parse(Foods.SelectedItem.ToString().Substring(3, 5));

                using (var context = new EverydayJournalContext())
                {

                    var updatedFoodName = UpdatedFoodName.Text;

                    //Getting selected Food from the List 
                    var food = context.Foods.FirstOrDefault(x => x.Id == foodToUpdate);

                    //Making check of the new food name andd adding it to the DB
                    if (updatedFoodName.Length > 4 && updatedFoodName != food.Name && foodToUpdate > 0)
                    {
                        food.Name = updatedFoodName;
                        context.SaveChanges();

                        MessageBox.Show("Successfully updated food");

                        //Reloading the page to refresh it 
                        FoodByDatePage foodByDatePage = new FoodByDatePage();
                        this.NavigationService?.Navigate(foodByDatePage);
                    }
                    else
                    {
                        MessageBox.Show("The food should be more than 4 symbols!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please, select Food first!");
            }
        }

        private void Button_Click_AddFood(object sender, RoutedEventArgs e)
        {
            //Getting TextBox value
            var foodToAdd = AddFood.Text;
            //Making check of the new food
            if (foodToAdd.Length < 6 || foodToAdd.Length > 50)
            {
                MessageBox.Show("The food name length should be between 6 and 50 symbols.");
            }
            else
            {
                using (var context = new EverydayJournalContext())
                {
                    //Finding currently logged user
                    var person = context.People.Find(LoggerUtility.UserId);
                    var food = new Food()
                    {
                        Name = foodToAdd,
                        Date = new Date() {ExactDate = DateTime.Now},
                        Person = person
                    };

                    //Adding it to the DB
                    context.Foods.AddOrUpdate(food);
                    context.SaveChanges();

                    MessageBox.Show("Successfully added food");

                    //Reloading the page to refresh it
                    FoodByDatePage foodByDatePage = new FoodByDatePage();
                    this.NavigationService?.Navigate(foodByDatePage);
                }
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedFoodId = 0;
                //Getting selected food Id from the List
                selectedFoodId = int.Parse(Foods.SelectedItem.ToString().Substring(3, 5));

                using (var context = new EverydayJournalContext())
                {
                    var foodToDelete = context.Foods.FirstOrDefault(x => x.Id == selectedFoodId);

                    //Making check before adding to the DB 
                    if (foodToDelete != null && selectedFoodId > 0)
                    {
                        context.Foods.Remove(foodToDelete);
                        context.SaveChanges();

                        MessageBox.Show("Successfully deleted food!");

                        //Reloading the page
                        FoodByDatePage foodByDatePage = new FoodByDatePage();
                        this.NavigationService?.Navigate(foodByDatePage);
                    }
                    else
                    {
                        MessageBox.Show("There is nothing to delete!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please, select food first!");
            }
        }

        private void Button_Click_BackToHomePage(object sender, RoutedEventArgs e)
        {
            UserHomePage homePage = new UserHomePage();
            this.NavigationService?.Navigate(homePage);
        }
    }
}
