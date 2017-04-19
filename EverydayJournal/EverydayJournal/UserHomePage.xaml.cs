

namespace EverydayJournal
{
    using System.Windows;
    using System.Windows.Controls;
    using Utilities;
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Page
    {
        public UserHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();

            this.NavigationService.Navigate(profilePage);
        }

        private void Button_Click_Tasks(object sender, RoutedEventArgs e)
        {
            TasksPage taskPage = new TasksPage();
            this.NavigationService.Navigate(taskPage);
        }

        private void Button_Click_FoodByDate(object sender, RoutedEventArgs e)
        {
            FoodByDatePage foodPage = new FoodByDatePage();

            this.NavigationService.Navigate(foodPage);
        }

        private void Button_Click_PhysicalConditions(object sender, RoutedEventArgs e)
        {
            PhysicalConditionsPage conditionsPage = new PhysicalConditionsPage();

            this.NavigationService.Navigate(conditionsPage);
        }

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{LoggerUtility.UserName} successful logout.");
            LoggerUtility.UserName = "";
            LoggerUtility.UserId = null;
            LoginPage loginPage = new LoginPage();
            this.NavigationService.Navigate(loginPage);
        }
    }
}
