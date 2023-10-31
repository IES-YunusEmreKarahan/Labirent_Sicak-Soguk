using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi


MazeData.completedLevels = 0;
MazeData.MazeVisible = false;
MazeData.showclue = false;

Color DefaultColor = Color.LightGray;

while (true)
{
    MazeData.matrixSize = 5 + MazeData.completedLevels;

    GenerateRandomMaze();

    if (!IsMazeSolvable(MazeData.Maze))
    {
        continue;
    }

    List<Node> shortestPath = Algorithm.AStar(MazeData.Maze, new Position(MazeData.playerLine, MazeData.playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));

    int shortestPathLength;
    try
    {
        if (shortestPath != null)
        {
            shortestPathLength = shortestPath.Count - 1; // Başlangıç ve bitiş noktalarını çıkartın
        }
        else
        {
            shortestPathLength = 0;
        }
    }
    catch
    {
        shortestPathLength = 0;
    }

    bool BackgroundColorChange = true;
    List<Node> exitDistance = Algorithm.AStar(MazeData.Maze, new Position(MazeData.playerLine, MazeData.playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));

    int exitDistanceLength = exitDistance.Count - 1; // Başlangıç ve bitiş noktalarını çıkartın
    PrintMaze(BackgroundColorChange, shortestPathLength, exitDistanceLength);

    Console.ForegroundColor = Color.FromArgb(255, 255, 255);
    Console.WriteLine("Oyuncuyu 'W' (yukarı), 'S' (aşağı), 'A' (sol), 'D' (sağ) tuşlarıyla hareket ettirin.");
    Console.WriteLine("Çıkmak için 'Q' tuşuna basın. / İpucu almak için 'İ' tuşuna basın.");
    Console.WriteLine("Oyun modunu değiştirmek için 'L' tuşuna basın.");
    Console.ForegroundColor = DefaultColor;

    if (shortestPath != null)
    {
        Console.WriteLine("En kısa yol uzunluğu: " + shortestPathLength);
    }
    else
    {
        Console.WriteLine("Bu Labirent çözülemez.");
    }

    while (true)
    {
        var key = Console.ReadKey(true);

        exitDistance = Algorithm.AStar(MazeData.Maze, new Position(MazeData.playerLine, MazeData.playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));
        exitDistanceLength = exitDistance.Count - 1; // Başlangıç ve bitiş noktalarını çıkartın

        MazeControls.Controls(key, BackgroundColorChange, shortestPathLength, exitDistanceLength); // Tuş Atamaları! -------------------------------

        exitDistance = Algorithm.AStar(MazeData.Maze, new Position(MazeData.playerLine, MazeData.playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));
        exitDistanceLength = exitDistance.Count - 1; // Başlangıç ve bitiş noktalarını çıkartın

        Clue.ClueDetector(key, shortestPathLength, exitDistanceLength, exitDistance);

        BackgroundColorChange = false;
        PrintMaze(BackgroundColorChange, shortestPathLength, exitDistanceLength);

        if (MazeData.playerLine == MazeData.exitLine && MazeData.playerColumn == MazeData.exitColumn)
        {
            MazeData.completedLevels++;
            Console.WriteLine("Seviye Geçildi. Tamamlanan Seviye: " + MazeData.completedLevels);
            if (shortestPath != null)
            {
                Console.WriteLine("En kısa yol uzunluğu: " + shortestPathLength + ", Oyuncu Adım Sayısı: " + MazeData.playerStep);
            }
            else
            {
                Console.WriteLine("Bu Labirent çözülemez.");
            }

            MazeData.playerStep = 0;
            MazeData.matrixSize = 5 + MazeData.completedLevels;
            MazeData.showclue = false;

            Console.WriteLine("Yeni bir Labirent oluşturuluyor...");
            Console.ReadKey();
            Console.Clear();
            break;
        }
    }
}
