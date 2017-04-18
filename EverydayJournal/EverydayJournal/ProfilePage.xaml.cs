namespace EverydayJournal
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Data;

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
                //TODO logged user should be used here
                var username = context.People.Where(n => n.Name == "martotko").FirstOrDefault();
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

                if (password == passwordConfirmation)
                {
                    //TODO Should be changed with the currently logged User
                    //Updating the user with ID=22 for the tests
                    context.People.Find(21).Name = username;
                    context.People.Find(21).Email = email;

                    context.SaveChanges();

                    MessageBox.Show("Successfully updated!");
                    UsernameChange.Clear();
                    EmailChange.Clear();
                }
            }
        }
    }
}
