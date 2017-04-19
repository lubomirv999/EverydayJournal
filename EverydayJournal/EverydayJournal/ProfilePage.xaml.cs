

namespace EverydayJournal
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Data;
    using Utilities;
    using System;
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            //Loading logged used credentials in the text boxes
            using (var context = new EverydayJournalContext())
            {
                var username = context.People.Where(n => n.Id == LoggerUtility.UserId).FirstOrDefault();
                UsernameChange.Text = username.Name;
                EmailChange.Text = username.Email;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EverydayJournalContext())
            {
                //Getting current values of the text boxes
                var username = UsernameChange.Text;
                var email = EmailChange.Text;
                var password = Password.Text;
                var passwordConfirmation = ConfirmPassword.Text;
                //Getting user password for the check
                var userPassword = context.People.Find(LoggerUtility.UserId);

                if (password == passwordConfirmation && userPassword.Password == password)
                {
                    try
                    {
                        //Updating the user
                        context.People.Find(LoggerUtility.UserId).Name = username;
                        context.People.Find(LoggerUtility.UserId).Email = email;

                        context.SaveChanges();

                        MessageBox.Show("Successfully updated information!");
                        UserHomePage userHomePage = new UserHomePage();
                        this.NavigationService.Navigate(userHomePage);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please, try again with correct information!");
                        EmailChange.Clear();
                        UsernameChange.Clear();
                        Password.Clear();
                        ConfirmPassword.Clear();
                    }
                }
            }
        }
    }
}
