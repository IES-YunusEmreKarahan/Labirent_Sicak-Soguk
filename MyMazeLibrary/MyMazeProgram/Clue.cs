using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi
using System.Collections.Generic;
class Clue
{
    public static void ClueDetector(ConsoleKeyInfo key, int shortestPathLength, int exitDistanceLength, List<Node> exitDistance)
    {
        if (key.KeyChar == 'i' || key.KeyChar == 'İ') // İpucu fonksiyonu
        {
            MazeData.showclue = true;

            PrintClue(shortestPathLength, exitDistanceLength, exitDistance);

        }
        else if (MazeData.showclue == true && MazeData.MazeVisible == false)
        {
            PrintClue(shortestPathLength, exitDistanceLength, exitDistance);
        }
    }

    public static void PrintClue(int shortestPathLength, int exitDistanceLength, List<Node> exitDistance)
    {
        if (MazeData.MazeVisible == true) // Labirent ipucu
        {

            for (int i = 0; i < MazeData.matrixSize; i++)
            {
                for (int j = 0; j < MazeData.matrixSize; j++)
                {
                    if (MazeData.Maze[i, j] == "☻")
                    {
                        MazeData.Maze[i, j] = ".";
                    }
                }
            }

            int playerLine = MazeData.playerLine;
            int playerColumn = MazeData.playerColumn;

            List<Node> clue = Algorithm.AStar(MazeData.Maze, new Position(playerLine, playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));

            if (clue != null)
            {
                foreach (Node node in clue)
                {
                    if (MazeData.Maze[playerLine, playerColumn] == ".")
                    {
                        MazeData.Maze[playerLine, playerColumn] = "☻";
                    }

                    playerLine = node.Position.Row;
                    playerColumn = node.Position.Col;

                    Console.Clear();
                    bool BackgroundColorChange = false;
                    PrintMaze(BackgroundColorChange, shortestPathLength, exitDistanceLength);

                    Thread.Sleep(10);
                }
            }
            else
            {
                Console.WriteLine("Bu Labirent çözülemez.");
            }
        }
        else // Sıcak/Soğuk ipucu
        {
            if (exitDistance != null)
            {
                MazeData.ClueList = new List<string>();
                for (int i = 1; i < exitDistance.Count; i++)
                {
                    int deltaX = exitDistance[i].Position.Col - exitDistance[i - 1].Position.Col;
                    int deltaY = exitDistance[i].Position.Row - exitDistance[i - 1].Position.Row;

                    if (deltaX == 1)
                    {
                        MazeData.ClueList.Add("Sağ");
                    }
                    else if (deltaX == -1)
                    {
                        MazeData.ClueList.Add("Sol");
                    }
                    else if (deltaY == 1)
                    {
                        MazeData.ClueList.Add("Aşağı");
                    }
                    else if (deltaY == -1)
                    {
                        MazeData.ClueList.Add("Yukarı");
                    }

                }
            }

        }
    }
}
