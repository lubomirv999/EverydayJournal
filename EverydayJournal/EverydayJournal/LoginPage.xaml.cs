using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EverydayJournal.Data;

namespace EverydayJournal
{
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

                //This is for test purposes only and should be removed when the below Login check is ready
                UserHomePage userHomePage = new UserHomePage();
                this.NavigationService.Navigate(userHomePage);


                //This check should work when the database is ready
                //if (context.People.Any(a => a.Password == password && a.Name == username))
                //{
                //    MessageBox.Show("Successfully logged!");

                //    //Navigate to UserHomePage
                //    UserHomePage userHomePage = new UserHomePage();
                //    this.NavigationService.Navigate(userHomePage);
                //}
                //else
                //{
                //    //Invalid credentials
                //    MessageBox.Show("Invalid Username or Password!");
                //    UsernameInput.Clear();
                //    PasswordInput.Clear();
                //}
            }
        }
    }
}
