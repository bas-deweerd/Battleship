using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Client.ViewModels;
using ServiceLibrary;
using Client.ServiceReference1;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        public Server Server;
        public CallbackService Callback;
        
        public LoginP()
        {
            InitializeComponent();
            DataContext = new UserViewModel();

            Callback = new CallbackService();
            
            Server = new Server(new InstanceContext(Callback));
            
        }

        public LoginP(Server server, CallbackService callback)
        {
            InitializeComponent();
            DataContext = new UserViewModel();

            this.Callback = callback;
            this.Server = server;
        }

        private void ButtonClickRegister(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterP(Server, Callback));
        }

        private void ButtonClickLogin(object sender, RoutedEventArgs e)
        {
            Server.Login(this.Email.Text, this.Password.Text);

            if (Callback.Authenticated)
            {
                this.NavigationService.Navigate(new Lobby(Server, Callback));
                Context.Username = this.Email.Text;
            }
            else
            {
                this.ErrorText.Text = "Please enter the correct details.";
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
