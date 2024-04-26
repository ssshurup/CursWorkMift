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
    /// Логика взаимодействия для UserOrderP.xaml
    /// </summary>
    public partial class UserOrderP : Page
    {
        static Books SelectedBookOrd;

        public UserOrderP()
        {
            InitializeComponent();
            UsernameTB.Text = "Hello " + App.LoggedUser.login;
            BookGrid.ItemsSource = App.DB.Books.ToList();
        }
        private void SelectBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookGrid.SelectedItem as Books;
            if (selectedBook != null)
            {
                SelectedBookOrd = selectedBook;
            }
        }
        private void CreateBT_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBookOrd == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            try
            {
                Orders newOrder = new Orders();
                newOrder.idUser = App.LoggedUser.id;
                newOrder.idStatus = 1;
                newOrder.orderDate = DateTime.Now;
                newOrder.count = Convert.ToInt32(CountTB.Text);
                App.DB.Orders.Add(newOrder);
                App.DB.SaveChanges();

                OrderBook BookInOrder = new OrderBook();

                BookInOrder.idOrder = newOrder.id;
                BookInOrder.idBook = SelectedBookOrd.id;
                App.DB.OrderBook.Add(BookInOrder);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
    }
}
