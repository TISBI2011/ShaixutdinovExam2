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
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        users context;
        public LoginP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            var tryLoggerUser = App.DB.users.Where(a => a.login == context.login && a.password == context.password);
            if (tryLoggerUser.Any())
            {
                App.LoggedUser = tryLoggerUser.First();
                if (App.LoggedUser.postId == 1) NavigationService.Navigate(new HRManP());
                else if(App.LoggedUser.postId == 2) NavigationService.Navigate(new OwnerCafeP());
                else if(App.LoggedUser.postId == 3) NavigationService.Navigate(new PovarP());
            }
        }
    }
}
