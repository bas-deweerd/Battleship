﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    /// <summary>
    /// Defines the orientation of a ship.
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// Horizontal; implies that a ship is placed horizontally on the <see cref="BattleGridModel"/>.
        /// </summary>
        Horizontal,
        /// <summary>
        /// The vertical; implies that a ship is placed vertically on the <see cref="BattleGridModel"/>.
        /// </summary>
        Vertical
    }
}
