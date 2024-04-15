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
    /// Логика взаимодействия для AddEmployeeP.xaml
    /// </summary>
    public partial class AddEmployeeP : Page
    {
        users context;
        public AddEmployeeP()
        {
            InitializeComponent();
            PostIdCB.ItemsSource = App.DB.post.ToList();
            context = new users();
            DataContext = context;
        }

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            var tryRegistredUs = App.DB.users.Where(a => a.login == context.login).ToList();
            if(tryRegistredUs.Any())
            {
                MessageBox.Show("This login already used");
                return;
            }
            else
            {
                try
                {
                    var selectedPost = PostIdCB.SelectedItem as post;
                    context.postId = selectedPost.id;
                    App.DB.users.Add(context);
                    App.DB.SaveChanges();
                    MessageBox.Show("Succes");
                    NavigationService.Navigate(new HRManP());
                }
                catch
                {
                    MessageBox.Show("Something wrong");
                }
            }
        }

        private void BackBT_Click(RoutedEventArgs e)
        {

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HRManP());
        }
    }
}
