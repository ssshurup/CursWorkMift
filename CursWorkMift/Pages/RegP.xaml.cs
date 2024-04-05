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
    /// Логика взаимодействия для RegP.xaml
    /// </summary>
    public partial class RegP : Page
    {
        static bool IsLogin = false;
        Users contextUs;
        public RegP()
        {
            InitializeComponent();
          

            contextUs = new Users();
            contextUs.idRole = 1;
            DataContext = contextUs;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            var Registreduser = App.DB.Users.Where(a => a.login == contextUs.login);
            if (Registreduser.Any())
            {
                MessageBox.Show("Incorrect login");
            }
            else
            {
                try
                {
                    contextUs.login = LogTB.Text;
                    contextUs.password = LogTB.Text;
                    App.RegistredUser = contextUs;
                }
                catch
                {
                    MessageBox.Show("Something wrong");
                }
                finally
                {
                    NavigationService.Navigate(new RegStepTP());
                }
            }
           
        }


    }
}
