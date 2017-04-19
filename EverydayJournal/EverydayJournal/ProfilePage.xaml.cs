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

            ProfileTitle.Content = (LoggerUtility.UserName ?? "User") + " Profile";

            //Loading logged used credentials in the text boxes
            using (var context = new EverydayJournalContext())
            {
                var username = context.People.FirstOrDefault(n => n.Id == LoggerUtility.UserId);
                UsernameChange.Text = username?.Name;
                EmailChange.Text = username?.Email;
            }
        }

        private void Button_Click_SaveChanges(object sender, RoutedEventArgs e)
        {
            using (var context = new EverydayJournalContext())
            {
                //Getting current values of the text boxes
                var username = UsernameChange.Text;
                var email = EmailChange.Text;
                var password = Password.Password;
                var passwordConfirmation = ConfirmPassword.Password;
                //Getting user from DB
                var userPassword = context.People.Find(LoggerUtility.UserId);

                if (password == passwordConfirmation 
                    && userPassword?.Password == password 
                    && username.Length > 3 
                    && email.Length > 3)
                {
                    try
                    {
                        //Updating the user
                        userPassword.Name = username;
                        userPassword.Email = email;

                        context.SaveChanges();

                        MessageBox.Show("Successfully updated information!");

                        UserHomePage userHomePage = new UserHomePage();
                        this.NavigationService?.Navigate(userHomePage);
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
                else
                {
                    MessageBox.Show(
                        "Invalid data. Please, try with correct password and Username/Email greater than 4 symbols!");
                }
            }
        }

        private void Button_Click_BackToMainMenu(object sender, RoutedEventArgs e)
        {
            UserHomePage homePage = new UserHomePage();
            this.NavigationService?.Navigate(homePage);
        }
    }
}
