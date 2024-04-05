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
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        Books context;
        public AddP()
        {
            InitializeComponent();
            AuthorCB.ItemsSource = App.DB.Authors.ToList();
            GenreCB.ItemsSource= App.DB.Genre.ToList();
            context = new Books();
            DataContext = context;
         
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DateDP.SelectedDate == null)
                {
                    MessageBox.Show("Select date");
                    return;
                }
                var selectedAuthor = AuthorCB.SelectedItem as Authors;
                context.idAuthor = selectedAuthor.id;
                var selectedGenre = GenreCB.SelectedItem as Genre;
                context.idGenre =selectedGenre.id;
                
                App.DB.Books.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Succes");
                NavigationService.Navigate(new AdminP());
            }
            catch {
                MessageBox.Show("Something wrong");
            }

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }
    }
}
