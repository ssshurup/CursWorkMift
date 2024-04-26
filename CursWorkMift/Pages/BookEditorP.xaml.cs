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
    /// Логика взаимодействия для BookEditorP.xaml
    /// </summary>
    public partial class BookEditorP : Page
    {
        public BookEditorP()
        {
            InitializeComponent();
            UsernameTB.Text = "Hello " + App.LoggedUser.login;
            BookGrid.ItemsSource = App.DB.Books.ToList();
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookGrid.SelectedItem as Books;
            if (selectedBook != null)
            {
                NavigationService.Navigate(new EditP(selectedBook));
            }
            else
            {
                MessageBox.Show("Выберите что-то");
            }
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookGrid.SelectedItem as Books;
            if (selectedBook != null)
            {
                App.DB.Books.Remove(selectedBook);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                BookGrid.ItemsSource = App.DB.Books.ToList();
            }
        }
        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }
    }
}
