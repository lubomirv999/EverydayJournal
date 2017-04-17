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
                    //Finding user by ID and updating him
                    var currentUser = context.People.Find(21);
                    currentUser.Name = username;
                    currentUser.Email = email;
                }
            }
        }
    }
}
