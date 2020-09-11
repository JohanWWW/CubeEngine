using Cube.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Components
{
    /// <summary>
    /// Represents a proportional surface on a cube
    /// </summary>
    public class Surface
    {
        public SquareMatrix Matrix { get; private set; }
        public int SquareCount => Matrix.Count;

        public Square this[int x, int y]
        {
            get => Matrix[x, y];
            set => Matrix[x, y] = value;
        }

        public Surface(int sideLength, SquareColor color)
        {
            Matrix = new SquareMatrix(sideLength);
            for (int y = 0; y < Matrix.SideLength; y++)
                for (int x = 0; x < Matrix.SideLength; x++)
                {
                    Matrix[x, y] = new Square(color);
                }
        }

        /// <summary>
        /// Rotates a part of the cube according to given instruction
        /// </summary>
        /// <param name="rotate"></param>
        public void Rotate(SurfaceRotation rotate)
        {
            int sideLength = Matrix.SideLength;
            var rotatedMatrix = new SquareMatrix(sideLength);

            int maxIndex = sideLength - 1;

            switch (rotate)
            {
                case SurfaceRotation.Clockwise:
                {
                    for (int y = 0; y < sideLength; y++)
                        for (int x = 0; x < sideLength; x++)
                        {
                            rotatedMatrix[maxIndex - y, x] = Matrix[x, y];
                        }
                    break;
                }
                case SurfaceRotation.CounterClockwise:
                {
                    for (int y = 0; y < sideLength; y++)
                        for (int x = 0; x < sideLength; x++)
                        {
                            rotatedMatrix[x, y] = Matrix[maxIndex - y, x];
                        }
                    break;
                }
            }

            Matrix = rotatedMatrix;
        }
    }
}
