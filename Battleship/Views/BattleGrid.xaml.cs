using System;
using System.Collections.Generic;
using System.Drawing;
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
using Battleship.Models;
using Brushes = System.Windows.Media.Brushes;
using Orientation = Battleship.Models.Orientation;
using Size = System.Windows.Size;

namespace Battleship.Views
{
    /// <summary>
    /// Interaction logic for BattleGrid.xaml.
    /// A BattleGrid is the visual representation of a grid with ships.
    /// Each player must get two instances of this, one for each mode(positioning own ships and attacking the opponent).
    /// Both players should share the same grid.
    /// </summary>
    public partial class BattleGrid : UserControl
    {
        public BattleGridModel Grid;
        //private Mode _mode = Mode.Own;
        private GamePhase phase = GamePhase.PlacingShips;
        private Grid _myGrid;
        public int TurnNumber = 0;
        public Orientation PlacingShipsOrientation = Orientation.Horizontal;
        private Player owner;
        public Player Owner { get { return owner; } set { this.owner = value; } }
        public Ship NextToBePlacedShip;
        private Turn turn;
        public Turn TheTurn { get { return turn; } set { this.turn = value; } }

        internal void changeShip(string Ship)
        {
            Ship ship = Grid.ThePlayer.getShip(Ship);
            switch (Ship)
            {
                case "Minesweeper":
                    NextToBePlacedShip = (Minesweeper) ship;
                    break;
                case "Frigato":
                    NextToBePlacedShip = (Frigato)ship;
                    break;
                case "Cruiser":
                    NextToBePlacedShip = (Cruiser)ship;
                    break;
                case "Battleship":
                    NextToBePlacedShip = (Models.Battleship) ship;
                    break;
            }
        }

        

        public BattleGrid()
        {
            
            InitializeComponent();
            _myGrid = new Grid();
            
            for (int i = 0; i < 10; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                ColumnDefinition columnDef = new ColumnDefinition();
                rowDef.Height = new GridLength(50);
                columnDef.Width = new GridLength(50);
                _myGrid.RowDefinitions.Add(rowDef);
                _myGrid.ColumnDefinitions.Add(columnDef);
            }

            for (int i = 0; i < 10; i++)
            {
                for (int ii = 0; ii < 10; ii++)
                {
                    Position pos = new Position(i, ii);
                    //pos.Content = "R:"+i + " C:"+ ii;
                    pos.Content = pos.CurrentState;
                    pos.Width = 50.0;
                    pos.Height = 50.0;
                    pos.Click += new RoutedEventHandler(Position_Click);
                    System.Windows.Controls.Grid.SetRow(pos, i);
                    System.Windows.Controls.Grid.SetColumn(pos, ii);
                    _myGrid.Children.Add(pos);
                    //TODO
                }
            }
            Content = _myGrid;   
        }

        /// <summary>
        /// Defines what happens once a position is clicked on.
        /// In case we are attacking the opponent, we will fire a bomb at the position and try to hit a ship, whilst increasing the turn number.
        /// In case we are positioning our own ships, we will attempt to place to ship in the corresponding position, turn number is not increased.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Position_Click(Object sender, EventArgs e)
        {
            Position pos = (Position)sender;
            int row = pos.GetRow();
            int column = pos.GetColumn();

            Click(row, column);
        }

        public void Click(int row, int column)
        {
            switch (phase)
            {
                case GamePhase.Battle:
                    if (Grid.GetPosition(row, column).CurrentState==State.Sea || Grid.GetPosition(row, column).CurrentState == State.Occupied) { 
                        if (turn.getActivePlayer() != owner)
                        {
                            Grid.Fire(row, column);
                            reconfigureGUIAccordingToModel();

                            turn.SwitchTurn();
                            TurnNumber++;

                        }
                    }
                        break;
                    
                case GamePhase.PlacingShips:
                    if (NextToBePlacedShip.Placed == false)
                    {
                        if (Grid.LocationIsValid(row, column, PlacingShipsOrientation, NextToBePlacedShip))
                        {
                            NextToBePlacedShip.Placed = true;
                            Grid.PlaceShip(row, column, PlacingShipsOrientation, NextToBePlacedShip);
                            reconfigureGUIAccordingToModel();
                            changeShip(NextToBePlacedShip.ToString());
                        }

                        
                    }
                    break;
            }
        }

        private void reconfigureGUIAccordingToModel()
        {
            foreach (Position child in _myGrid.Children)
            {
                int childRow = child.GetRow();
                int childColumn = child.GetColumn();
                Position correspondingModelPosition = this.Grid.GetPosition(childRow, childColumn);

                child.CurrentState = correspondingModelPosition.CurrentState;
                child.Content = correspondingModelPosition.CurrentState;
                child.Background = correspondingModelPosition.Background;
            }
        }

        /// <summary>
        /// Sets the grid. Allows two players or a player with a bot to share one grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        public void setGrid(BattleGridModel grid)
        {
            this.Grid = grid;
        }

        public BattleGridModel getGrid()
        {
            return Grid;
        }



        internal void setPlayer(Player p1, Turn turn)
        {
            Owner = p1;
            Grid = new BattleGridModel(p1);
            this.turn = turn;
        }

        public void setPhase(GamePhase phase)
        {
            this.phase = phase;
        }

        public GamePhase getPhase()
        {
            return this.phase;
        }
    }
}
