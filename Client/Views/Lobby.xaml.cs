using System.Windows;
using System.Windows.Controls;
using Client.Models;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Page
    {
        Server Server;
        CallbackService Callback;

        public Lobby(Server server, CallbackService callback)
        {
            InitializeComponent();
            this.Callback = callback;
            this.Server = server;

        }

        private void SinglePlayerGame_Click(object sender, RoutedEventArgs e)
        {
            new Game().Show();
        }

        private void MultiPlayerGame_Click(object sender, RoutedEventArgs e)
        {
            new Multiplayer(Server, Callback).Show();
        }
    }
}
