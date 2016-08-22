namespace Client.Models
{
    /// <summary>
    /// Models the battle grid.
    /// It is the logical representation of the grid on which ships can be placed.
    /// Contains a 10x10 grid.
    /// Every position on the grid has one of the following states:
    /// <list type="bullet">
    /// <item><description>Sea (no ship, no bomb)</description></item>
    /// <item><description>Occupied (by a ship, not yet bombed)</description></item>
    /// <item><description>Hit (position occupied by a ship, bombed)</description></item>
    /// <item><description>Miss (no ship, bombed)</description></item>
    /// </list>
    /// </summary>
    public class BattleGridModel
    {
        private Position[,] array2D;
        private Player player;
        public Player ThePlayer { get { return player; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleGridModel"/> class.
        /// </summary>
        public BattleGridModel(Player player)
        {
            array2D = new Position[10,10];

            for (int i = 0; i < 10; i++)
            {
                for (int ii = 0; ii < 10; ii++)
                {
                    array2D[i, ii] = new Position(i, ii);
                }
            }
            this.player = player;
        }

        /// <summary>
        /// Sets sea in the specified coordinate.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        private void SetSea(int row, int column)
        {
            array2D[row,column].CurrentState = State.Sea;
        }

        /// <summary>
        /// Places a ship on the specified coordinate.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="ship">The ship to be placed.</param>
        private void SetOccupied(int row, int column, Ship ship)
        {
            var myObject = player as BotRandom;
            if (myObject == null)
            {
                array2D[row, column].CurrentState = State.Occupied;
                array2D[row, column].OwnedShip = ship;
            }
            else {
                array2D[row, column].CurrentState = State.OccupiedHidden;
                array2D[row, column].OwnedShip = ship;
            }


        }

        /// <summary>
        /// Fires a bomb on the coordinates x and y.
        /// If a ship has been hit, state changes to hit.
        /// If bomb was a miss, state changes to miss.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public void Fire(int row, int column)
        { 
            array2D[row, column].Hit();

        }

        /// <summary>
        /// Changes the state of the corresponding coordinates.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="state">The state.</param>
        private void SetState(int row, int column, State state)
        {
            array2D[row, column].CurrentState = state;       
        }

        /// <summary>
        /// Places any ship on the specified coordinates.
        /// The coordinate represents the most top left placing of the ship.
        /// If the location is not valid (any part of the ship goes out of bounds), the ship is not placed.
        /// </summary>
        /// <param name="row">The row (top left of ship).</param>
        /// <param name="column">The column (top left of ship).</param>
        /// <param name="orientation">The orientation; either horizontal or vertical.</param>
        /// <param name="ship">The ship.</param>
        public void PlaceShip(int row, int column, Orientation orientation, Ship ship)
        {
            if (!LocationIsValid(row, column, orientation, ship)) {
                return;
            }
           
            switch (orientation)
            {
                case Orientation.Horizontal:
                    for (int i = 0; i < ship.Length; i++)
                    {
                        SetOccupied(row, column, ship);
                        column++;
                    }
                    break;
                case Orientation.Vertical:
                    for (int i = 0; i < ship.Length; i++)
                    {
                        SetOccupied(row, column, ship);
                        row++;
                    }
                    break;
            }
        }

        /// <summary>
        /// Checks if the location of the ship is valid.
        /// </summary>
        /// <param name="row">The row (top left of the ship).</param>
        /// <param name="column">The column (top left of the ship).</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="ship">The ship to be placed.</param>
        /// <returns>Whether or not the top left location of the ship is a valid location.</returns>
        public bool LocationIsValid(int row, int column, Orientation orientation, Ship ship)
        {
            // First checks if it is out of bounds, then if any of the positions are already occupied.
            if (row < 0 || row > 9 || column < 0 || column > 9 || ship==null) return false;
            switch (orientation)
            {
                case Orientation.Horizontal:
                    int endColumn = column + ship.Length - 1;
                    if (endColumn > 9) return false;
                    while (column != endColumn + 1)
                    {
                        State placeState = GetPosition(row, column).CurrentState;
                        if (placeState == State.Occupied || placeState == State.OccupiedHidden){return false;}
                        column++;
                    }
                    return true;
                case Orientation.Vertical:
                    int endRow = row + ship.Length - 1;
                    if (endRow > 9) return false;
                    while (row != endRow + 1)
                    {
                        State placeState = GetPosition(row, column).CurrentState;
                        if (placeState == State.Occupied || placeState == State.OccupiedHidden) { return false; }
                        row++;
                    }
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the position object of the coordinates.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>Returns the position object of the coordinates.</returns>
        public Position GetPosition(int row, int column)
        {
            return array2D[row,column];
        }
    }
}