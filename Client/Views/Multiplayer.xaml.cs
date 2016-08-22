using System;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Client.ServiceReference1;
using Client.ViewModels;
using ServiceLibrary;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {
        public Server Server;
        public CallbackService Callback;

        public Multiplayer(Server server, CallbackService callback)
        {
            InitializeComponent();

            this.Server = server;
            this.Callback = callback;
            
            GetGames();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Server.CreateNewGame(Context.Username);
            
            GetGames();
        }

        private void GetGames()
        {
            Server.GetAllGames();
            
            GamesComboBox.Items.Clear();
            if (Callback.Games != null)
            {
                foreach (var VARIABLE in Callback.Games)
                {
                    string game = VARIABLE.ToString() + System.Environment.NewLine;
                    GamesComboBox.Items.Add(game);
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetGames();
        }

        private void GamesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesComboBox.SelectedItem != null)
            {
                int id = Int32.Parse(Regex.Match(GamesComboBox.SelectedItem.ToString(), "[0-9]+").Value);
                string username = Context.Username;
                Server.JoinGame(id, username);
                new Chat(Server, Callback).Show();
            }
        }
    }
}
