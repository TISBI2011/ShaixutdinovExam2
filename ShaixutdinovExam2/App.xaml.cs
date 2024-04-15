using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShaixutdinovExam2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Exam2ShaixutdinovEntities DB = new Exam2ShaixutdinovEntities();
        public static users LoggedUser; 
    }
}
