using System;
using EverydayJournal.Models;

namespace EverydayJournal
{
    using System.Windows;
    using System.Windows.Controls;
    using Data;

    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            var name = NameInput.Text;
            var password = PasswordInput.Password;
            var email = EmailInput.Text;

            if (name.Length < 4)
            {
                MessageBox.Show("The name should be greater than 3 symbols!");
            }
            else if (password.Length < 6)
            {
                MessageBox.Show("The password should be greater than 6 symbols!");
            }
            else if (!email.Contains("@"))
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
                        MessageBox.Show("Successfully logged in!");
                        
                        UserHomePage homePage = new UserHomePage();
                        this.NavigationService.Navigate(homePage);
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
    }
}
