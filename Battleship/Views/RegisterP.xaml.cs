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
using Battleship.ViewModels;
using Battleship.Views;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for RegisterP.xaml
    /// </summary>
    public partial class RegisterP : Page
    {
        public RegisterP()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }

        private void RegisterAccount(object sender, RoutedEventArgs e)
        {
            UserAdapter.Register(this.Email.Text, this.Password.Text);
        }

        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginP());
        }
    }
}
