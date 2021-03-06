﻿using System;
using System.Collections.Generic;
using System.Text;
using Cube.Enums;

namespace Cube
{
    /// <summary>
    /// Provides settings to the cube which are applied on instantiation of <see cref="Cube"/>
    /// </summary>
    public class CubeSettings
    {
        public SquareColor FrontColor { get; set; } = SquareColor.Green;
        public SquareColor BackColor { get; set; } = SquareColor.Blue;
        public SquareColor LeftColor { get; set; } = SquareColor.Orange;
        public SquareColor RightColor { get; set; } = SquareColor.Red;
        public SquareColor TopColor { get; set; } = SquareColor.White;
        public SquareColor BottomColor { get; set; } = SquareColor.Yellow;
    }
}
