using System;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Orientation = Client.Models.Orientation;

namespace Client.Views
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
        private GamePhase _phase = GamePhase.PlacingShips;
        private Grid _myGrid;
        public int TurnNumber = 0;
        public Orientation PlacingShipsOrientation = Orientation.Horizontal;
        private Player _owner;
        public Player Owner { get { return _owner; } set { this._owner = value; } }
        public Ship NextToBePlacedShip;
        private Turn _turn;
        public Turn TheTurn { get { return _turn; } set { this._turn = value; } }

        internal void ChangeShip(string Ship)
        {
            // TODO: Fix vague naming ship & Ship
            Ship ship = Grid.ThePlayer.GetShip(Ship);
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
            switch (_phase)
            {
                case GamePhase.Battle:
                    State bombState = Grid.GetPosition(row, column).CurrentState;
                    if (bombState==State.Sea || bombState == State.Occupied || bombState == State.OccupiedHidden) { 
                        if (_turn.GetActivePlayer() != _owner)
                        {
                            Grid.Fire(row, column);
                            ReconfigureGuiAccordingToModel();

                            _turn.SwitchTurn();
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
                            ReconfigureGuiAccordingToModel();
                            ChangeShip(NextToBePlacedShip.ToString());
                        }
                    }
                    break;
            }
        }

        private void ReconfigureGuiAccordingToModel()
        {
            foreach (Position child in _myGrid.Children)
            {
                int childRow = child.GetRow();
                int childColumn = child.GetColumn();
                Position correspondingModelPosition = this.Grid.GetPosition(childRow, childColumn);

                child.CurrentState = correspondingModelPosition.CurrentState;
                if (correspondingModelPosition.CurrentState != State.OccupiedHidden)
                {
                    child.Content = correspondingModelPosition.CurrentState;
                }
                child.Background = correspondingModelPosition.Background;
            }
        }

        /// <summary>
        /// Sets the grid. Allows two players or a player with a bot to share one grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        public void SetGrid(BattleGridModel grid)
        {
            this.Grid = grid;
        }

        public BattleGridModel GetGrid()
        {
            return Grid;
        }

        internal void SetPlayer(Player p1, Turn turn)
        {
            Owner = p1;
            Grid = new BattleGridModel(p1);
            this._turn = turn;
        }

        public void SetPhase(GamePhase phase)
        {
            this._phase = phase;
        }

        public GamePhase GetPhase()
        {
            return this._phase;
        }
    }
}
