namespace EverydayJournal
{
    using System.Windows.Controls;
    using Data;
    using System.Windows;
    using Utilities;
    /// <summary>
    /// Interaction logic for PhysicalConditionsPage.xaml
    /// </summary>
    public partial class PhysicalConditionsPage : Page
    {
        public PhysicalConditionsPage()
        {
            InitializeComponent();

            TitlePhysical.Content = (LoggerUtility.UserName ?? "User") + " Condition";

            //Loading the current condition in the text box
            using (var context = new EverydayJournalContext())
            {
                var username = context.People.Find(LoggerUtility.UserId);
                PhysicalConditionTextBox.Text = username.PhysicalCondition;
            }
        }

        private void Button_Click_SaveChanges(object sender, RoutedEventArgs e)
        {
            //Updating the condition with the text from the text box
            using (var context = new EverydayJournalContext())
            {
                var updatedCondition = PhysicalConditionTextBox.Text;
                //Updating the user condition
                context.People.Find(LoggerUtility.UserId).PhysicalCondition = updatedCondition;
                context.SaveChanges();

                MessageBox.Show("Successfully updated condition!");
                PhysicalConditionTextBox.Clear();
            }
        }

        private void Button_Click_BackToHomePage(object sender, RoutedEventArgs e)
        {
            //Back to home button
            UserHomePage homePage = new UserHomePage();
            this.NavigationService?.Navigate(homePage);
        }
    }
}
