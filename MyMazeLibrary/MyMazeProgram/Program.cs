using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi

MazeData.completedLevels = 0;
MazeData.MazeVisible = false;

Color DefaultColor = Color.LightGray;

while (true)
{
    MazeData.matrixSize = 5 + MazeData.completedLevels;

    GenerateRandomMaze();

    if (!IsMazeSolvable(MazeData.Maze)) // Labirent Çözülebilirmi?
    {
        continue;
    }

    bool BackgroundColorChange = true;
    PrintMaze(BackgroundColorChange);

    Console.ForegroundColor = Color.FromArgb(255, 255, 255);
    Console.WriteLine("Oyuncuyu 'W' (yukarı), 'S' (aşağı), 'A' (sol), 'D' (sağ) tuşlarıyla hareket ettirin.");
    Console.WriteLine("Çıkmak için 'Q' tuşuna basın. / İpucu almak için 'İ' tuşuna basın.");
    Console.WriteLine("Oyun modunu değiştirmek için 'L' tuşuna basın.");
    Console.ForegroundColor = DefaultColor;

    while (true)
    {
        var key = Console.ReadKey(true);


        MazeControls.Controls(key, BackgroundColorChange); // Tuş Atamaları! -------------------------------


        BackgroundColorChange = false;
        PrintMaze(BackgroundColorChange);

        if (MazeData.playerLine == MazeData.exitLine && MazeData.playerColumn == MazeData.exitColumn)
        {
            MazeData.completedLevels++;
            Console.WriteLine("Seviye Geçildi. Tamamlanan Seviye: " + MazeData.completedLevels);

            MazeData.playerStep = 0;
            MazeData.matrixSize = 5 + MazeData.completedLevels;

            Console.WriteLine("Yeni bir Labirent oluşturuluyor...");
            Console.ReadKey();
            Console.Clear();
            break;
        }
    }
}