using System;
using System.Collections.Generic;
using System.Text;
using Cube.Enums;

namespace Cube.Components
{
    /// <summary>
    /// A proportional matrix of squares
    /// </summary>
    public class SquareMatrix
    {
        public Square[,] Matrix { get; }
        public int SideLength { get; }
        public int Count => Matrix.Length;

        public Square this[int x, int y]
        {
            get => Matrix[x, y];
            set => Matrix[x, y] = value;
        }

        public SquareMatrix(int sideLength)
        {
            SideLength = sideLength;
            Matrix = new Square[sideLength, sideLength];
        }
    }
}
