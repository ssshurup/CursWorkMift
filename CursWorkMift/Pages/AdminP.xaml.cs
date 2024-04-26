using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
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
    /// Логика взаимодействия для AdminP.xaml
    /// </summary>
    public partial class AdminP : Page
    {
        public AdminP()
        {
            InitializeComponent();
            UsernameTB.Text = "Hello " + App.LoggedUser.login;
        }


        private void CreateBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateP());
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void ListOrderBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllOrdersAdmP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookEditorP());
        }
    }
}
