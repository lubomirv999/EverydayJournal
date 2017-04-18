

using System.Windows;

namespace EverydayJournal
{
    using System.Windows.Controls;
    using Data;
    using System.Linq;

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
                var username = context.People.Find(20);
                PhysicalConditionTextBox.Text = username.PhysicalCondition;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Updating the condition with the text from the text box
            using (var context = new EverydayJournalContext())
            {
                var updatedCondition = PhysicalConditionTextBox.Text;
                //TODO
                //Updating the user with ID=20. Should be changed with the currently logged User
                context.People.Find(20).PhysicalCondition = updatedCondition;
                context.SaveChanges();

                MessageBox.Show("Successfully updated condition!");
                PhysicalConditionTextBox.Clear();
            }
        }
    }
}
