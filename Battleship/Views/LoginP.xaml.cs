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
using Battleship;
using Battleship.ViewModels;
using Battleship.Views;
using Battleship.Models;

namespace Battleship.Views
{
    /// <summary>
    /// Interaction logic for LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        public LoginP()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }

        private void buttonClickRegister(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterP());
        }

        private void buttonClickLogin(object sender, RoutedEventArgs e)
        {
            if (UserAdapter.CredentialsCorrect(this.Email.Text, this.Password.Text))
            {
                this.NavigationService.Navigate(new Lobby());
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
