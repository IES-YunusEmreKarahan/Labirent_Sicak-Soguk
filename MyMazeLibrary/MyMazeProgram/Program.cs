using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi+
using Colorful; // Renk Eklentisi+

MazeData.completedLevels = 0;

Color DefaultColor = Color.LightGray;

while (true)
{
    MazeData.matrixSize = 5 + MazeData.completedLevels;

    GenerateRandomMaze();

    PrintMaze();

    Console.ReadKey();
}