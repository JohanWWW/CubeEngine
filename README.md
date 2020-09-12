# CubeEngine

A 3x3x3 puzzle engine library.
With this library it is possible to create your own 3x3x3 puzzles in e.g. Unity.

## Terms used in this library
![Diagram describing the frequently used terms in this project](/Images/CubeEngineTermsDiagram.png)
*Diagram describing the frequently used terms in this project*

**Relationships (top-down)**
- ONE cube has MANY surfaces. 
- ONE surface contains ONE square matrix. 
- ONE square matrix contains MANY squares.

## Usage

### Quick Start
```csharp
var settings = new CubeSettings();
var cube = new Cube.Cube(settings);

// Move right clockwise
cube.Move(CubeNotation.RC);

// Move back counter clockwise
cube.Move(CubeNotation.BCC);

// Make multiple moves
cube.Move(
  CubeNotation.LC,
  CubeNotation.LC,
  CubeNotation.DC,
  CubeNotation.BCC,
  CubeNotation.DCC
);
```

### Custom Colours
It is possible to customize each square matrice's default colour with the help of the ``CubeSettings`` class.
Setting custom colour values overrides default values. Default colour values are:
- Front: Green
- Back: Blue
- Left: Orange
- Right: Red
- Top: White
- Bottom: Yellow

**Example**
```csharp
// Override default colours
var settings = new CubeSettings
{
  FrontColor = SquareColor.Red,
  BackColor = SquareColor.Orange,
  LeftColor = SquareColor.Yellow,
  RightColor = SquareColor.Green,
  TopColor = SquareColor.Blue,
  BottomColor = SquareColor.White
};

// Pass the settings instance to the cube's constructor
var cube = new Cube.Cube(settings);
```

### Track Positions
You might want to retrieve the cube's state in order to notify the graphical interface where each sqaure is after each move or to determine if the cube is solved or not.
This is possible with the instance method ``GetSurface(...)`` which retrieves a specified surface on the cube. 
A ``SurfaceFacing`` enum constant value which represents which direction each surface is facing from the observer's point of view, should be passed on to the method.

```csharp
// Retrieve surface on the back of the cube (facing away from the observer)
var back = cube.GetSurface(SurfaceFacing.Away);

// Retrieve surface on the bottom of the cube (facing down)
var bottom = cube.GetSurface(SurfaceFacing.Down);
```

A square is retrieved by passing the square's coordinates (origin at top left) on to the surface instance's indexer method.
When surface rotates, it's matrix mapping stays the same. 
Let's say that the front surface is rotated clockwise, then the top left square (0,0) moves to the top right corner (2,0).
Center pieces are stationary and will always have coordinates {1, 1}.

```csharp
// Matrix mapping
// | 0,0 | 1,0 | 2,0 |
// -------------------
// | 0,1 | 1,1 | 2,1 |
// -------------------
// | 0,2 | 1,2 | 2,2 |

// Get the front surface
var front = cube.GetSurface(SurfaceFacing.Fourth);

// Get the center piece
var centerPiece = front[1, 1];

// Get top right piece
var topRightPiece = front[2, 0];
```
## Mapping
The square matrices are mapped according to the diagram below.
![Diagram showing how matrices are mapped on the cube](/Images/CubeEngineCubeMapping.png)
*Diagram showing how matrices are mapped on the cube*

Opposite matrices are mirrored projections of each other except top and bottom which are horizontally and vertically flipped projections. Matrices always remain stationary.
