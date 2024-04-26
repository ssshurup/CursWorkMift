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
    /// Логика взаимодействия для CreateP.xaml
    /// </summary>
    public partial class CreateP : Page
    {
        Users context;
        public CreateP()
        {
            InitializeComponent();
            context = new Users();
            DataContext = context;
            context.idRole = 2;
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.DB.Users.Add(context);
                App.DB.SaveChanges();
                Admin adm = new Admin();
                adm.idUser = context.id;
                adm.name = NameTB.Text;
                App.DB.Admin.Add(adm);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
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
