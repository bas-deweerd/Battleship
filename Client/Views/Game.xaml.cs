using System.Windows;
using System.Windows.Controls;
using Client.Models;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private GameModel model;

        public Game()
        {
            InitializeComponent();
            this.model = new GameModel(MySea, OpponentSea, this);
        }

        private void SwitchOrientation_OnClick(object sender, RoutedEventArgs e)
        {
            model.SwitchOrientation();
        }

        private void Ship_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.SelectionChanged(e);
        }

        private void NextPhase_OnClick(object sender, RoutedEventArgs e)
        {
            model.NextPhase(); 
        }

        public void NotifyWinner(int i)
        {
            DaWinner.Text = "P" + i +" wins.";
        }
    }
}
