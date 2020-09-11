using System;
using System.Collections.Generic;
using System.Text;
using Cube.Enums;

namespace Cube.Components
{
    /// <summary>
    /// Represents the smaller squares of a surface on the cube
    /// </summary>
    public class Square
    {
        public SquareColor Color { get; }
        public SurfaceFacing Home { get; }

        public Square(SquareColor color) => Color = color;

        public Square(SquareColor color, SurfaceFacing home)
        {
            Color = color;
            Home = home;
        }

        public override string ToString() => Color.ToString();
    }
}
