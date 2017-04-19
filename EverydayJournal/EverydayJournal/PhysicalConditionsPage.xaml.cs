namespace EverydayJournal
{
    using System.Windows.Controls;
    using Data;
    using System.Linq;
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

            //Loading the current condition in the text box
            using (var context = new EverydayJournalContext())
            {
                var username = context.People.Find(LoggerUtility.UserId);
                PhysicalConditionTextBox.Text = username.PhysicalCondition;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
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
    }
}
