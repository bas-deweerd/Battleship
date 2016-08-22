using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Battleship.Models
{
    public class GameModel
    {
        private Player p1 = new Player();
        private BotRandom p2 = new BotRandom();
        private Turn turn;
        private BattleGrid _MySea;
        private BattleGrid _OpponentSea;
        private Game game;


        public GameModel(BattleGrid mysea, BattleGrid opponentsea, Game game)
        {
            this.game = game;
            _MySea = mysea;
            _OpponentSea = opponentsea;

            turn = new Turn(p1, p2);
            _MySea.setPlayer(p1, turn);
            _OpponentSea.setPlayer(p2, turn);
            p2.turn = turn;
            turn.model = this;
        }

        public void SwitchOrientation()
        {
            Orientation oldOrientation = _MySea.PlacingShipsOrientation;
            _MySea.PlacingShipsOrientation = oldOrientation == Orientation.Vertical ? Orientation.Horizontal : Orientation.Vertical;
        }

        internal void SelectionChanged(SelectionChangedEventArgs e)
        {
            _MySea.changeShip((e.AddedItems[0] as System.Windows.Controls.ComboBoxItem).Content.ToString());
        }

        internal void NextPhase()
        {
            if (_MySea.getPhase() == GamePhase.PlacingShips && p1.AllShipsPlaced())
            {
                _MySea.setPhase(GamePhase.Battle);
                p2.PlaceAllShips(_OpponentSea);
                p2.OpponentSea = _MySea;
                _OpponentSea.setPhase(GamePhase.Battle);
                game.NextPhase.Visibility = Visibility.Hidden;
                game.ShipBox.Visibility = Visibility.Hidden;
                game.SwitchOrientationButton.Visibility = Visibility.Hidden;
            }
            else {
                _MySea.setPhase(GamePhase.EndGame);
                _OpponentSea.setPhase(GamePhase.EndGame);
                if (p1.allShipsSunk()) {
                   this.game.NotifyWinner(2);
                    // game.Winner = "Player 2 wins!";
                }
                else if(p2.allShipsSunk())
                {
                    this.game.NotifyWinner(1);
                    // game.Winner = "Player 1 wins!";
                }

            }
        }
    }
}
