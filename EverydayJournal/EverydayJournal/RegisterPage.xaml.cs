namespace EverydayJournal
{
    using System.Windows;
    using System.Windows.Controls;
    using Data;
    using System;
    using System.Linq;
    using Models;
    using Utilities;

    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();

            //Clear User session before register
            LoggerUtility.UserName = "";
            LoggerUtility.UserId = null;
        }

        private void RegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Getting the data from the page
            var name = NameInput.Text;
            var password = PasswordInput.Password;
            var email = EmailInput.Text;

            //Check before using adding to DB
            if (name.Length < 4)
            {
                MessageBox.Show("The name should be greater than 3 symbols!");
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("The password should be greater than 4 symbols!");
            }
            else if (!email.Contains("@") || email.Length < 6)
            {
                MessageBox.Show("Invalid Email!");
            }
            else
            {
                using (var context = new EverydayJournalContext())
                {
                    try
                    {
                        context.People
                        .Add(new Person()
                        {
                            Name = name,
                            Password = password,
                            Email = email
                        });

                        context.SaveChanges();
                        MessageBox.Show("Registration successful!");

                        //Saving Id and UserName for the current session.
                        LoggerUtility.UserId = context.People.Where(n => n.Name == name).Select(x => x.Id).FirstOrDefault();
                        LoggerUtility.UserName = name;

                        UserHomePage homePage = new UserHomePage();
                        this.NavigationService?.Navigate(homePage);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error with registering. Please, try again!");
                        NameInput.Clear();
                        PasswordInput.Clear();
                        EmailInput.Clear();
                    }
                }
            }
        }

        private void Button_Click_BackToLogin(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.NavigationService?.Navigate(loginPage);
        }
    }
}
