using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CursWorkMift
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PublishingEntities DB = new PublishingEntities();
        public static Users LoggedUser;
        public static Users RegistredUser;

    }
}
