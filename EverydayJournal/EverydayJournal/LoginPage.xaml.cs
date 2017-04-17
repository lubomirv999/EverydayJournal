namespace EverydayJournal
{
    using System.Windows;
    using System.Windows.Controls;
    using Data;
    using System.Linq;

    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
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
                    MessageBox.Show("Successfully logged!");

                    //Navigate to UserHomePage
                    UserHomePage userHomePage = new UserHomePage();
                    this.NavigationService.Navigate(userHomePage);
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
