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
    /// Логика взаимодействия для MyOrdersP.xaml
    /// </summary>
    public partial class MyOrdersP : Page
    {
        public MyOrdersP()
        {
            InitializeComponent();
            OrderDG.ItemsSource = App.DB.Orders.Where(a => a.idUser == App.LoggedUser.id).ToList();
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {

            var selectedOrder = OrderDG.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                App.DB.Orders.Remove(selectedOrder);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                OrderDG.ItemsSource = App.DB.Orders.Where(a => a.idUser == App.LoggedUser.id).ToList();
            }
            else
            {
                MessageBox.Show("Выберите что-то");
                return;
            }

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
    }
}
