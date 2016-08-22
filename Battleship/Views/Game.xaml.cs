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
using System.Windows.Shapes;
using Battleship.Models;
using Orientation = Battleship.Models.Orientation;

namespace Battleship.Views
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void NotifyWinner(int i)
        {
            DaWinner.Text = "P" + i +" wins.";
        }

        public void NotifyOrientation(Orientation orientation)
        {
            
        }
    }
}
