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
    public partial class RegStepTP : Page
    {
        Clients context;
        public RegStepTP()
        {
            InitializeComponent();
            CountryCB.ItemsSource = App.DB.Country.ToList();
            context = new Clients();
            DataContext = context;
        }
        private void CountryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CityCB.ItemsSource = App.DB.City.Where(a => a.idCountry == CountryCB.SelectedIndex + 1).ToList();
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.idCity = CityCB.SelectedIndex + 1;
                context.idUser = App.RegistredUser.id;
                App.DB.Clients.Add(context);
                App.DB.Users.Add(App.RegistredUser);
                App.DB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Something error");

            }
            finally
            {
                NavigationService.Navigate(new LoginP());
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }
    }
}
