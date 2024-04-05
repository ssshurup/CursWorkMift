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
    /// Логика взаимодействия для AllOrdersAdmP.xaml
    /// </summary>
    public partial class AllOrdersAdmP : Page
    {
        public AllOrdersAdmP()
        {
            InitializeComponent();
            OrderDG.ItemsSource = App.DB.Orders.ToList();

        }
        private void DropBT_Click(object sender, RoutedEventArgs e)
        {

            var selectedOrder = OrderDG.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                App.DB.Orders.Remove(selectedOrder);
                App.DB.SaveChanges();
                MessageBox.Show("Succes");
                OrderDG.ItemsSource = App.DB.Orders.Where(a => a.idUser == App.LoggedUser.id).ToList();
            }
            else
            {
                MessageBox.Show("Select anything");
                return;
            }

        }


        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrderDG.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                var selectedOrderBook = App.DB.OrderBook.Where(a => a.idOrder == selectedOrder.id);
                string selectedBook = "";
                foreach (OrderBook item in selectedOrderBook)
                {
                    selectedBook += "\n" + item.Books.title;
                }
                MessageBox.Show("Books to buy:" + selectedBook);
            }
            else
            {
                MessageBox.Show("Select anything");
                return;
            }

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void StatusBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrderDG.SelectedItem as Orders;
            if (selectedOrder != null)
            {
               if(selectedOrder.idStatus < 3)
                {
                    selectedOrder.idStatus += 1;
                    if (selectedOrder.id == 0)
                    {
                        App.DB.Orders.Add(selectedOrder);
                    }
                    App.DB.SaveChanges();
                    MessageBox.Show("succes");
                    OrderDG.ItemsSource = App.DB.Orders.ToList();
                }
                else
                {
                    MessageBox.Show("Order is already complete ");
                }
            }
        }
    }
}
