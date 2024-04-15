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
    /// Логика взаимодействия для EditEmployeeP.xaml
    /// </summary>
    public partial class EditEmployeeP : Page
    {
        users context;
        public EditEmployeeP(users editedUs)
        {
            InitializeComponent();
            PostIdCB.ItemsSource = App.DB.post.ToList();
            context = editedUs;
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HRManP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            if(context.id == 0)
            {
                App.DB.users.Add(context);
            }
            App.DB.SaveChanges();
            MessageBox.Show("succes");
            NavigationService.Navigate(new HRManP());
        }
    }
}
