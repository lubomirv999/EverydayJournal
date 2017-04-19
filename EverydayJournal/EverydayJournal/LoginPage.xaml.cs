namespace EverydayJournal
{
    using System.Windows;
    using System.Windows.Controls;
    using Data;
    using System.Linq;
    using Utilities;
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            //Clear User session before logging again
            LoggerUtility.UserName = "";
            LoggerUtility.UserId = null;
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            //Navigate to Register page if the register button is clicked
            RegisterPage registerPage = new RegisterPage();

            this.NavigationService.Navigate(registerPage);
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            using (var context = new EverydayJournalContext())
            {
                //Getting username and password from the login form
                var username = UsernameInput.Text;
                var password = PasswordInput.Password;
                
                //Check if the data successfully match in the database 
                if (context.People.Any(a => a.Password == password && a.Name == username))
                {
                    var userId = context.People
                        .Where(a => a.Password == password && a.Name == username)
                        .Select(i =>new { i.Id, i.Name})
                        .FirstOrDefault();

                    MessageBox.Show("Successfully logged!");
                    //Saving Id and UserName for the current session.
                    LoggerUtility.UserId = userId.Id;
                    LoggerUtility.UserName = userId.Name;

                    //Navigate to UserHomePage

                    UserHomePage userHomePage = new UserHomePage();
                    this.NavigationService?.Navigate(userHomePage);
                }
                else
                {
                    //Invalid credentials
                    MessageBox.Show("Invalid Username or Password!");
                    UsernameInput.Clear();
                    PasswordInput.Clear();
                }
            }
        }
    }
}
