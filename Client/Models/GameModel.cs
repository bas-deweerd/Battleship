using System.Windows;
using System.Windows.Controls;
using Client.Views;
using Orientation = Client.Models.Orientation;

namespace Client.Models
{
    public class GameModel
    {
        private Player _p1 = new Player();
        private BotRandom _p2 = new BotRandom();
        private Turn _turn;
        private BattleGrid _mySea;
        private BattleGrid _opponentSea;
        private Game _game;

        public GameModel(BattleGrid mysea, BattleGrid opponentsea, Game game)
        {
            this._game = game;
            _mySea = mysea;
            _opponentSea = opponentsea;

            _turn = new Turn(_p1, _p2);
            _mySea.SetPlayer(_p1, _turn);
            _opponentSea.SetPlayer(_p2, _turn);
            _p2.Turn = _turn;
            _turn.Model = this;
        }

        public void SwitchOrientation()
        {
            Orientation oldOrientation = _mySea.PlacingShipsOrientation;
            _mySea.PlacingShipsOrientation = oldOrientation == Orientation.Vertical ? Orientation.Horizontal : Orientation.Vertical;
        }

        internal void SelectionChanged(SelectionChangedEventArgs e)
        {
            _mySea.ChangeShip((e.AddedItems[0] as ComboBoxItem).Content.ToString());
        }

        internal void NextPhase()
        {
            if (_mySea.GetPhase() == GamePhase.PlacingShips && _p1.AllShipsPlaced())
            {
                _mySea.SetPhase(GamePhase.Battle);
                _p2.PlaceAllShips(_opponentSea);
                _p2.OpponentSea = _mySea;
                _opponentSea.SetPhase(GamePhase.Battle);
                _game.NextPhase.Visibility = Visibility.Hidden;
                _game.ShipBox.Visibility = Visibility.Hidden;
                _game.SwitchOrientationButton.Visibility = Visibility.Hidden;
                _game.NextShipToPlaceTextBlock.Visibility = Visibility.Hidden;
            }
            else {
                _mySea.SetPhase(GamePhase.EndGame);
                _opponentSea.SetPhase(GamePhase.EndGame);
                if (_p1.AllShipsSunk()) {
                   this._game.NotifyWinner(2);
                    // game.Winner = "Player 2 wins!";
                }
                else if(_p2.AllShipsSunk())
                {
                    this._game.NotifyWinner(1);
                    // game.Winner = "Player 1 wins!";
                }

            }
        }
    }
}
