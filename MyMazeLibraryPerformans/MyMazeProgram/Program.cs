using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi


MazeData.completedLevels = 10;
MazeData.MazeVisible = true;
MazeData.showclue = false;

Color DefaultColor = Color.LightGray;

while (true) 
{
    MazeData.matrixSize = MazeData.completedLevels;

    GenerateRandomMaze();

    if (!IsMazeSolvable(MazeData.Maze))
    {
        continue;
    }

    PrintMaze();

    Console.ForegroundColor = Color.FromArgb(255, 255, 255);
    Console.WriteLine("Oyuncuyu 'W' (yukarı), 'S' (aşağı), 'A' (sol), 'D' (sağ) tuşlarıyla hareket ettirin.");
    Console.WriteLine("Çıkmak için 'Q' tuşuna basın. / Algoritmaların performansını ölçmek için 'Spacebar'(Boşluk) tuşuna basın.");
    Console.WriteLine("Seviye'yi geçmek için 'P' tuşuna basın.");
    Console.ForegroundColor = DefaultColor;

    while (true)
    {
        var key = Console.ReadKey(true);

        MazeControls.Controls(key); // Tuş Atamaları! -------------------------------

        Clue.ClueDetector(key);

        PrintMaze();

        if (MazeData.playerLine == MazeData.exitLine && MazeData.playerColumn == MazeData.exitColumn)
        {
            Console.WriteLine("Seviye Geçildi. Tamamlanan Seviye: " + MazeData.completedLevels);
            Console.WriteLine("Oyuncu Adım Sayısı: " + MazeData.playerStep);
            MazeData.completedLevels = MazeData.completedLevels * 10;

            MazeData.playerStep = 0;
            MazeData.matrixSize = MazeData.completedLevels;
            MazeData.showclue = false;

            Console.WriteLine("Yeni bir Labirent oluşturuluyor...");
            Console.ReadKey();
            Console.Clear();
            break;
        }
    }
}
