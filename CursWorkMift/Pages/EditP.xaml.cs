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
    /// Логика взаимодействия для EditP.xaml
    /// </summary>
    public partial class EditP : Page
    {
        Books context;
        public EditP( Books editedBook)
        {
            InitializeComponent();
            AuthorCB.ItemsSource = App.DB.Authors.ToList();
            GenreCB.ItemsSource = App.DB.Genre.ToList();
            context = editedBook;
            DataContext = context;
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var selectedAuthor = AuthorCB.SelectedItem as Authors;
                context.idAuthor = selectedAuthor.id;
                var selectedGenre = GenreCB.SelectedItem as Genre;
                context.idGenre = selectedGenre.id;
                if (context.id == 0)
                {
                    App.DB.Books.Add(context);
                    App.DB.SaveChanges();
                }
                NavigationService.Navigate(new AdminP());
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());

        }
    }
}
