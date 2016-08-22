using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Client.ServiceReference1;
using Client.ViewModels;
using ServiceLibrary;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for RegisterP.xaml
    /// </summary>
    public partial class RegisterP : Page
    {
        //public ServiceClient Client;

        Server Server;
        CallbackService CallBack;

        public RegisterP(Server server, CallbackService callBack)
        {
            InitializeComponent();
            DataContext = new UserViewModel();

            this.Server = server;
            this.CallBack = callBack;

            //Client = Context.Client;
        }

        private void RegisterAccount(object sender, RoutedEventArgs e)
        {
            Server.Register(this.Email.Text, this.Password.Text);

            //Client.Register(this.Email.Text, this.Password.Text);
        }

        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginP(Server, CallBack));
        }
    }
}
