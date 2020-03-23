using Cube.Enums;
using Cube.Components;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Cube
{
    /// <summary>
    /// A 3x3x3 puzzle
    /// </summary>
    public class Cube
    {
        private readonly CubeSettings _settings;
        private readonly IDictionary<SurfaceFacing, Surface> _surfaces;

        public Cube(CubeSettings settings)
        {
            _surfaces = new Dictionary<SurfaceFacing, Surface>
            {
                [SurfaceFacing.Fourth] = new Surface(3, settings.FrontColor),
                [SurfaceFacing.Away] = new Surface(3, settings.BackColor),
                [SurfaceFacing.Left] = new Surface(3, settings.LeftColor),
                [SurfaceFacing.Right] = new Surface(3, settings.RightColor),
                [SurfaceFacing.Down] = new Surface(3, settings.BottomColor),
                [SurfaceFacing.Up] = new Surface(3, settings.TopColor)
            };
            _settings = settings;
        }

        public void Move(params CubeNotation[] notations)
        {
            foreach (CubeNotation notation in notations)
                Move(notation);
        }

        public void Move(CubeNotation notation)
        {
            const int size = 3;
            const int maxIndex = size - 1;

            // Rotate the 3x3x1 piece
            switch (notation)
            {
                case CubeNotation.LC: // Left clockwise
                    {
                        _surfaces[SurfaceFacing.Left].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][0, i];
                            _surfaces[SurfaceFacing.Fourth][0, i] = _surfaces[SurfaceFacing.Up][0, i];
                            _surfaces[SurfaceFacing.Up][0, i] = _surfaces[SurfaceFacing.Away][2, maxIndex - i];
                            _surfaces[SurfaceFacing.Away][2, maxIndex - i] = _surfaces[SurfaceFacing.Down][0, i];
                            _surfaces[SurfaceFacing.Down][0, i] = cache;
                        }
                        break;
                    }
                case CubeNotation.LCC: // Left counter clockwise
                    {
                        _surfaces[SurfaceFacing.Left].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][0, i];
                            _surfaces[SurfaceFacing.Fourth][0, i] = _surfaces[SurfaceFacing.Down][0, i];
                            _surfaces[SurfaceFacing.Down][0, i] = _surfaces[SurfaceFacing.Away][2, maxIndex - i];
                            _surfaces[SurfaceFacing.Away][2, maxIndex - i] = _surfaces[SurfaceFacing.Up][0, i];
                            _surfaces[SurfaceFacing.Up][0, i] = cache;
                        }
                        break;
                    }
                case CubeNotation.RC: // Right clockwise
                    {
                        _surfaces[SurfaceFacing.Right].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][2, i];
                            _surfaces[SurfaceFacing.Fourth][2, i] = _surfaces[SurfaceFacing.Down][2, i];
                            _surfaces[SurfaceFacing.Down][2, i] = _surfaces[SurfaceFacing.Away][0, maxIndex - i];
                            _surfaces[SurfaceFacing.Away][0, maxIndex - i] = _surfaces[SurfaceFacing.Up][2, i];
                            _surfaces[SurfaceFacing.Up][2, i] = cache;
                        }
                        break;
                    }
                case CubeNotation.RCC: // Right counter clockwise
                    {
                        _surfaces[SurfaceFacing.Right].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][2, i];
                            _surfaces[SurfaceFacing.Fourth][2, i] = _surfaces[SurfaceFacing.Up][2, i];
                            _surfaces[SurfaceFacing.Up][2, i] = _surfaces[SurfaceFacing.Away][0, maxIndex - i];
                            _surfaces[SurfaceFacing.Away][0, maxIndex - i] = _surfaces[SurfaceFacing.Down][2, i];
                            _surfaces[SurfaceFacing.Down][2, i] = cache;
                        }
                        break; 
                    }
                case CubeNotation.UC: // Up clockwise
                    {
                        _surfaces[SurfaceFacing.Up].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][i, 0];
                            _surfaces[SurfaceFacing.Fourth][i, 0] = _surfaces[SurfaceFacing.Right][i, 0];
                            _surfaces[SurfaceFacing.Right][i, 0] = _surfaces[SurfaceFacing.Away][i, 0];
                            _surfaces[SurfaceFacing.Away][i, 0] = _surfaces[SurfaceFacing.Left][i, 0];
                            _surfaces[SurfaceFacing.Left][i, 0] = cache;
                        }
                        break;
                    }
                case CubeNotation.UCC: // Up counter clockwise
                    {
                        _surfaces[SurfaceFacing.Up].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][i, 0];
                            _surfaces[SurfaceFacing.Fourth][i, 0] = _surfaces[SurfaceFacing.Left][i, 0];
                            _surfaces[SurfaceFacing.Left][i, 0] = _surfaces[SurfaceFacing.Away][i, 0];
                            _surfaces[SurfaceFacing.Away][i, 0] = _surfaces[SurfaceFacing.Right][i, 0];
                            _surfaces[SurfaceFacing.Right][i, 0] = cache;
                        }
                        break;
                    }
                case CubeNotation.DC: // Down clockwise
                    {
                        _surfaces[SurfaceFacing.Down].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][i, 2];
                            _surfaces[SurfaceFacing.Fourth][i, 2] = _surfaces[SurfaceFacing.Left][i, 2];
                            _surfaces[SurfaceFacing.Left][i, 2] = _surfaces[SurfaceFacing.Away][i, 2];
                            _surfaces[SurfaceFacing.Away][i, 2] = _surfaces[SurfaceFacing.Right][i, 2];
                            _surfaces[SurfaceFacing.Right][i, 2] = cache;
                        }
                        break;
                    }
                case CubeNotation.DCC: // Down counter clockwise
                    {
                        _surfaces[SurfaceFacing.Down].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Fourth][i, 2];
                            _surfaces[SurfaceFacing.Fourth][i, 2] = _surfaces[SurfaceFacing.Right][i, 2];
                            _surfaces[SurfaceFacing.Right][i, 2] = _surfaces[SurfaceFacing.Away][i, 2];
                            _surfaces[SurfaceFacing.Away][i, 2] = _surfaces[SurfaceFacing.Left][i, 2];
                            _surfaces[SurfaceFacing.Left][i, 2] = cache;
                        }
                        break;
                    }
                case CubeNotation.FC: // Front clockwise
                    {
                        _surfaces[SurfaceFacing.Fourth].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Up][i, 2];
                            _surfaces[SurfaceFacing.Up][i, 2] = _surfaces[SurfaceFacing.Left][2, maxIndex - i];
                            _surfaces[SurfaceFacing.Left][2, maxIndex - i] = _surfaces[SurfaceFacing.Down][maxIndex - i, 0];
                            _surfaces[SurfaceFacing.Down][maxIndex - i, 0] = _surfaces[SurfaceFacing.Right][0, i];
                            _surfaces[SurfaceFacing.Right][0, i] = cache;
                        }
                        break;
                    }
                case CubeNotation.FCC: // Front counter clockwise
                    {
                        _surfaces[SurfaceFacing.Fourth].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Up][i, 2];
                            _surfaces[SurfaceFacing.Up][i, 2] = _surfaces[SurfaceFacing.Right][0, i];
                            _surfaces[SurfaceFacing.Right][0, i] = _surfaces[SurfaceFacing.Down][maxIndex - i, 0];
                            _surfaces[SurfaceFacing.Down][maxIndex - i, 0] = _surfaces[SurfaceFacing.Left][2, maxIndex - i];
                            _surfaces[SurfaceFacing.Left][2, maxIndex - i] = cache;
                        }
                        break;
                    }
                case CubeNotation.BC: // Back clockwise
                    {
                        _surfaces[SurfaceFacing.Away].Rotate(SurfaceRotation.Clockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Up][i, 0];
                            _surfaces[SurfaceFacing.Up][i, 0] = _surfaces[SurfaceFacing.Right][2, i];
                            _surfaces[SurfaceFacing.Right][2, i] = _surfaces[SurfaceFacing.Down][maxIndex - i, 2];
                            _surfaces[SurfaceFacing.Down][maxIndex - i, 2] = _surfaces[SurfaceFacing.Left][0, maxIndex - i];
                            _surfaces[SurfaceFacing.Left][0, maxIndex - i] = cache;
                        }
                        break;
                    }
                case CubeNotation.BCC: // Back counter clockwise
                    {
                        _surfaces[SurfaceFacing.Away].Rotate(SurfaceRotation.CounterClockwise);
                        for (int i = 0; i < size; i++)
                        {
                            var cache = _surfaces[SurfaceFacing.Up][i, 0];
                            _surfaces[SurfaceFacing.Up][i, 0] = _surfaces[SurfaceFacing.Left][0, maxIndex - i];
                            _surfaces[SurfaceFacing.Left][0, maxIndex - i] = _surfaces[SurfaceFacing.Down][maxIndex - i, 2];
                            _surfaces[SurfaceFacing.Down][maxIndex - i, 2] = _surfaces[SurfaceFacing.Right][2, i];
                            _surfaces[SurfaceFacing.Right][2, i] = cache;
                        }
                        break;
                    }
            }
        }

        public Surface GetSurface(SurfaceFacing facing) => _surfaces[facing];
    }
}
