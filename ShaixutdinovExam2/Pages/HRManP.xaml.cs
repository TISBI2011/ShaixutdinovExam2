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

namespace ShaixutdinovExam2.Pages
{
    /// <summary>
    /// Логика взаимодействия для HRManP.xaml
    /// </summary>
    public partial class HRManP : Page
    {
        
        public HRManP()
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.post.ToList();
            EmployeeListDG.ItemsSource = App.DB.users.ToList();
        }

        private void AddEmpBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeeP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());

        }

        private void EditEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListDG.SelectedItem as users;
            if (selectedEmployee != null)
            {
                NavigationService.Navigate(new EditEmployeeP(selectedEmployee));
            }
            else
            {
                MessageBox.Show("select something");
            }
        }

        private void PostCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPost = PostCB.SelectedItem as post;
            EmployeeListDG.ItemsSource = App.DB.users.Where(a => a.postId == selectedPost.id).ToList();

        }

        private void DropEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListDG.SelectedItem as users;
            if (selectedEmployee != null)
            {
                App.DB.users.Remove(selectedEmployee);
                App.DB.SaveChanges();
            }
            else
            {
                MessageBox.Show("select something");
            }
        }
    }
}
