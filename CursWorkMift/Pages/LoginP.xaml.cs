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

namespace CursWorkMift.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        Users context;
        public LoginP()
        {
            InitializeComponent();
            context = new Users();
            DataContext = context;
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegP());
        }

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            var LoggedUser = App.DB.Users.Where(a => a.login == context.login && a.password == context.password);
            if(LoggedUser.Any())
            {
                App.LoggedUser = LoggedUser.First();
                if (App.LoggedUser.idRole == 1)
                {
                    NavigationService.Navigate(new UserP());
                }else NavigationService.Navigate(new AdminP());

            }
            else
            {
                MessageBox.Show("Incorrect data");
            }
        }
    }
}
