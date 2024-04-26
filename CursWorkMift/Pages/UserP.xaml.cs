using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        static Books SelectedBookOrd;
        public UserP()
        {
            InitializeComponent();
            var us = App.DB.Clients.Where(a => a.idUser == App.LoggedUser.id).First();
            UsernameTB.Text = "Hello " + us.nameCompany;
        }

        

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }


        private void MyOrdersBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyOrdersP());

        }

        private void SelectBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserOrderP());

        }
    }
}
