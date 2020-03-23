using System;
using Xunit;
using Cube;
using Cube.Enums;
using Tests.Extensions;

namespace Tests
{
    public class CubeUnitTests
    {
        [Fact]
        public void ShouldBeExpectedStateAfterScramble()
        {
            // Arrange
            var cube = GetTestCube();

            // Act
            cube.Move(
                CubeNotation.LC,
                CubeNotation.DCC,
                CubeNotation.BCC,
                CubeNotation.RC,
                CubeNotation.BCC,
                CubeNotation.RCC,
                CubeNotation.BC,
                CubeNotation.UCC,
                CubeNotation.DC,
                CubeNotation.DC,
                CubeNotation.LC,
                CubeNotation.FCC,
                CubeNotation.FC,
                CubeNotation.UC,
                CubeNotation.LCC
            );

            // Assert
            var front = cube.GetSurface(SurfaceFacing.Fourth);
            var back = cube.GetSurface(SurfaceFacing.Away);
            var left = cube.GetSurface(SurfaceFacing.Left);
            var right = cube.GetSurface(SurfaceFacing.Right);
            var bottom = cube.GetSurface(SurfaceFacing.Down);
            var top = cube.GetSurface(SurfaceFacing.Up);

            front[0, 0].Color.ShouldHaveValue(SquareColor.White);
            front[1, 0].Color.ShouldHaveValue(SquareColor.Green);
            front[2, 0].Color.ShouldHaveValue(SquareColor.Green);
            front[0, 1].Color.ShouldHaveValue(SquareColor.White);
            front[1, 1].Color.ShouldHaveValue(SquareColor.Green);
            front[2, 1].Color.ShouldHaveValue(SquareColor.Green);
            front[0, 2].Color.ShouldHaveValue(SquareColor.Orange);
            front[1, 2].Color.ShouldHaveValue(SquareColor.Blue);
            front[2, 2].Color.ShouldHaveValue(SquareColor.Orange);

            back[0, 0].Color.ShouldHaveValue(SquareColor.Blue);
            back[1, 0].Color.ShouldHaveValue(SquareColor.Green);
            back[2, 0].Color.ShouldHaveValue(SquareColor.Blue);
            back[0, 1].Color.ShouldHaveValue(SquareColor.White);
            back[1, 1].Color.ShouldHaveValue(SquareColor.Blue);
            back[2, 1].Color.ShouldHaveValue(SquareColor.Blue);
            back[0, 2].Color.ShouldHaveValue(SquareColor.Red);
            back[1, 2].Color.ShouldHaveValue(SquareColor.Red);
            back[2, 2].Color.ShouldHaveValue(SquareColor.Red);

            left[0, 0].Color.ShouldHaveValue(SquareColor.Orange);
            left[1, 0].Color.ShouldHaveValue(SquareColor.Blue);
            left[2, 0].Color.ShouldHaveValue(SquareColor.Red);
            left[0, 1].Color.ShouldHaveValue(SquareColor.Orange);
            left[1, 1].Color.ShouldHaveValue(SquareColor.Orange);
            left[2, 1].Color.ShouldHaveValue(SquareColor.Orange);
            left[0, 2].Color.ShouldHaveValue(SquareColor.White);
            left[1, 2].Color.ShouldHaveValue(SquareColor.Blue);
            left[2, 2].Color.ShouldHaveValue(SquareColor.Blue);

            right[0, 0].Color.ShouldHaveValue(SquareColor.White);
            right[1, 0].Color.ShouldHaveValue(SquareColor.Orange);
            right[2, 0].Color.ShouldHaveValue(SquareColor.Yellow);
            right[0, 1].Color.ShouldHaveValue(SquareColor.Red);
            right[1, 1].Color.ShouldHaveValue(SquareColor.Red);
            right[2, 1].Color.ShouldHaveValue(SquareColor.Red);
            right[0, 2].Color.ShouldHaveValue(SquareColor.Green);
            right[1, 2].Color.ShouldHaveValue(SquareColor.Green);
            right[2, 2].Color.ShouldHaveValue(SquareColor.Green);

            bottom[0, 0].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[1, 0].Color.ShouldHaveValue(SquareColor.Red);
            bottom[2, 0].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[0, 1].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[1, 1].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[2, 1].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[0, 2].Color.ShouldHaveValue(SquareColor.Blue);
            bottom[1, 2].Color.ShouldHaveValue(SquareColor.Yellow);
            bottom[2, 2].Color.ShouldHaveValue(SquareColor.Yellow);

            top[0, 0].Color.ShouldHaveValue(SquareColor.White);
            top[1, 0].Color.ShouldHaveValue(SquareColor.Orange);
            top[2, 0].Color.ShouldHaveValue(SquareColor.Red);
            top[0, 1].Color.ShouldHaveValue(SquareColor.White);
            top[1, 1].Color.ShouldHaveValue(SquareColor.White);
            top[2, 1].Color.ShouldHaveValue(SquareColor.Yellow);
            top[0, 2].Color.ShouldHaveValue(SquareColor.Green);
            top[1, 2].Color.ShouldHaveValue(SquareColor.White);
            top[2, 2].Color.ShouldHaveValue(SquareColor.Orange);
        }

        private Cube.Cube GetTestCube()
        {
            var settings = new CubeSettings
            {
                FrontColor = SquareColor.Green,
                BackColor = SquareColor.Blue,
                LeftColor = SquareColor.Orange,
                RightColor = SquareColor.Red,
                BottomColor = SquareColor.Yellow,
                TopColor = SquareColor.White
            };

            return new Cube.Cube(settings);
        }
    }
}
