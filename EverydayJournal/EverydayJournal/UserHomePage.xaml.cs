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
            HomePageTitle.Content = "Hello " + (LoggerUtility.UserName??"User") + " !";
        }
        
        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            //Navigate to Profile page
            ProfilePage profilePage = new ProfilePage();
            this.NavigationService?.Navigate(profilePage);
        }

        private void Button_Click_Tasks(object sender, RoutedEventArgs e)
        {
            //Navigate to Tasks page
            TasksPage taskPage = new TasksPage();
            this.NavigationService?.Navigate(taskPage);
        }

        private void Button_Click_FoodByDate(object sender, RoutedEventArgs e)
        {
            //Navigate to Food page
            FoodByDatePage foodPage = new FoodByDatePage();
            this.NavigationService?.Navigate(foodPage);
        }

        private void Button_Click_PhysicalConditions(object sender, RoutedEventArgs e)
        {
            //Navigate to Physical Condition page
            PhysicalConditionsPage conditionsPage = new PhysicalConditionsPage();
            this.NavigationService?.Navigate(conditionsPage);
        }

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            //Logout
            MessageBox.Show($"{LoggerUtility.UserName} successful logout.");
            LoggerUtility.UserName = "";
            LoggerUtility.UserId = null;

            //Navigate to Login Page
            LoginPage loginPage = new LoginPage();
            this.NavigationService?.Navigate(loginPage);
        }
    }
}
