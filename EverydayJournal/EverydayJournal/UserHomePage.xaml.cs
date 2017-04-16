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

namespace EverydayJournal
{
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Page
    {
        public UserHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();

            this.NavigationService.Navigate(profilePage);
        }

        private void Button_Click_Tasks(object sender, RoutedEventArgs e)
        {
            TasksPage taskPage = new TasksPage();
            this.NavigationService.Navigate(taskPage);
        }

        private void Button_Click_FoodByDate(object sender, RoutedEventArgs e)
        {
            FoodByDatePage foodPage = new FoodByDatePage();

            this.NavigationService.Navigate(foodPage);
        }

        private void Button_Click_PhysicalConditions(object sender, RoutedEventArgs e)
        {
            PhysicalConditionsPage conditionsPage = new PhysicalConditionsPage();

            this.NavigationService.Navigate(conditionsPage);
        }
    }
}
