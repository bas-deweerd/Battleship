namespace Client.Models
{
    /// <summary>
    /// Represents the state of a <see cref="Position"/>.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Sea (no ship, no bomb)
        /// </summary>
        Sea,
        /// <summary>
        /// Occupied (by a ship, not yet bombed)
        /// </summary>
        Occupied,
        /// <summary>
        /// Hit (position occupied by a ship, bombed)
        /// </summary>
        Hit,
        /// <summary>
        /// Miss (no ship, bombed)
        /// </summary>
        Miss,
        /// <summary>
        /// Sunk (Whole ship bombed)
        /// </summary>
        Sunk,
        OccupiedHidden

    }
}
