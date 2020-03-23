using System;
using System.Collections.Generic;
using System.Text;
using Cube.Enums;

namespace Cube.Components
{
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
