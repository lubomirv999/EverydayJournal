using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EverydayJournal.Data;
using EverydayJournal.Models;
using EverydayJournal.Utilities;
using Task = EverydayJournal.Models.Task;

namespace EverydayJournal
{
    /// <summary>
    /// Interaction logic for TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            using (var context = new EverydayJournalContext())
            {
                var tasks = context.Tasks
                    .Where(x => x.PersonId == LoggerUtility.UserId)
                    .OrderBy(z => z.Date.ExactDate)
                    .Select(y => "Id." + y.Id.ToString() + "    " + y.Name + " - " + y.Date.ExactDate)
                    .ToArray();

                Tasks.ItemsSource = tasks;
            }
        }

        private void Button_Click_UpdateTask(object sender, System.Windows.RoutedEventArgs e)
        {
            var taskToUpdate = 0;
            //getting selected food Id
            taskToUpdate = int.Parse(Tasks.SelectedItem.ToString().Substring(3, 5));

            using (var context = new EverydayJournalContext())
            {
                var updatedTaskName = UpdatedTaskName.Text;

                var task = context.Tasks.FirstOrDefault(x => x.Id == taskToUpdate);

                if (updatedTaskName.Length > 5 && updatedTaskName != task.Name && taskToUpdate > 0)
                {
                    task.Name = updatedTaskName;
                    context.SaveChanges();
                    MessageBox.Show("Successfully updated task");

                    //Reloading the page
                    global::EverydayJournal.TasksPage tasksPage = new global::EverydayJournal.TasksPage();
                    this.NavigationService.Navigate(tasksPage);
                }
                else
                {
                    MessageBox.Show("There is no changes or selected Task!");
                }
            }
        }

        private void Button_Click_AddTask(object sender, RoutedEventArgs e)
        {
            var taskToAdd = AddTask.Text;
            if (taskToAdd.Length < 5)
            {
                MessageBox.Show("The task should be at least 5 letters long!");
                return;
            }


            using (var context = new EverydayJournalContext())
            {
                var person = context.People.Find(LoggerUtility.UserId);
                var task = new Task()
                {
                    Name = taskToAdd,
                    Date = new Date() {ExactDate = DateTime.Now},
                    Person = person
                };

                context.Tasks.AddOrUpdate(task);
                context.SaveChanges();
                MessageBox.Show("Successfully added task");
                //Reloading the page
                global::EverydayJournal.TasksPage tasksPage = new global::EverydayJournal.TasksPage();
                this.NavigationService.Navigate(tasksPage);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var selectedTaskId = 0;
            selectedTaskId = int.Parse(Task.SelectedItem.ToString().Substring(3, 5));
            using (var context = new EverydayJournalContext())
            {
                var taskToDelete = context.Tasks.FirstOrDefault(x => x.Id == selectedTaskId);
                if (taskToDelete != null)
                {
                    context.Tasks.Remove(taskToDelete);
                    context.SaveChanges();

                    MessageBox.Show("Successfully deleted task!");

                    //Reloading the page
                    global::EverydayJournal.TasksPage tasksPage = new global::EverydayJournal.TasksPage();
                    this.NavigationService.Navigate(tasksPage);
                }
                else
                {
                    MessageBox.Show("There is nothing to delete!");
                }
            }
        }
    }
}
