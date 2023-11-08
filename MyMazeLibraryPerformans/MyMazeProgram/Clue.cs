using MyMazeLibrary;
using System.Drawing;
using static MyMazeLibrary.MazeFunctions;
using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi
using System.Collections.Generic;
using System.Diagnostics;

class Clue
{
    public static void ClueDetector(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.Spacebar) // İpucu fonksiyonu
        {
            MazeData.showclue = true;

            PrintClue();

        }
        else if (MazeData.showclue == true && MazeData.MazeVisible == false)
        {
            PrintClue();
        }
    }

    public static void PrintClue()
    {
        MazeData.AStarStopwatch = new Stopwatch();
        MazeData.BFSStopwatch = new Stopwatch();
        MazeData.GreedyStopwatch = new Stopwatch();

        MazeData.AStarShortestPathLength = 0;
        MazeData.BFSShortestPathLength = 0;
        MazeData.GreedyShortestPathLength = 0;

        MazeData.BackgroundColorChange = false;

        if (MazeData.MazeVisible == true) // Labirent ipucu
        {
            PrintMaze();
            Console.WriteLine("İşlemi başlatmak için herhangi bir tuşa basın.");
            Console.WriteLine("( Önerilen tuş : 'Enter' )");
            Console.ReadKey();

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
            Console.Clear();
            PrintMaze();

            int playerLine = MazeData.playerLine;
            int playerColumn = MazeData.playerColumn;

            if (MazeData.matrixSize <= 300)
            {
                MazeData.AStarStopwatch.Start();
                List<Position> clueAStar = Algorithm.AStar(MazeData.Maze, new Position(playerLine, playerColumn), new Position(MazeData.exitLine, MazeData.exitColumn));
                MazeData.AStarStopwatch.Stop();

                MazeData.AStarShortestPathLength = clueAStar.Count - 1;

                if (clueAStar != null)
                {
                    if (MazeData.matrixSize <= 10)
                    {
                        Console.WriteLine("AStar Labirenti Çözüyor...");
                        Thread.Sleep(1000);
                        foreach (Position node in clueAStar)
                        {
                            if (MazeData.Maze[playerLine, playerColumn] == ".")
                            {
                                MazeData.Maze[playerLine, playerColumn] = "☻";
                            }

                            playerLine = node.Row;
                            playerColumn = node.Col;
                        }
                        Console.Clear();
                        PrintMaze();
                    }
                }
                else
                {
                    Console.WriteLine("Bu Labirent çözülemez.");
                }
            }

            PrintMaze();
            Console.WriteLine("Sıradaki işlemi başlatmak için herhangi bir tuşa basın.");
            Console.WriteLine("( Önerilen tuş : 'Enter' )");
            Console.ReadKey();

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
            Console.Clear();
            PrintMaze();


            playerLine = MazeData.playerLine;
            playerColumn = MazeData.playerColumn;

            MazeData.GreedyStopwatch.Start();
            List<GreedyPosition> clueGreedy = Algorithm.Greedy(MazeData.Maze, new GreedyPosition(playerLine, playerColumn), new GreedyPosition(MazeData.exitLine, MazeData.exitColumn));
            MazeData.GreedyStopwatch.Stop();

            MazeData.GreedyShortestPathLength = clueGreedy.Count - 1;

            if (clueGreedy != null)
            {
                if (MazeData.matrixSize <= 10)
                {
                    Console.WriteLine("Greedy Labirenti Çözüyor...");
                    Thread.Sleep(1000);
                    foreach (GreedyPosition Position in clueGreedy)
                    {
                        if (MazeData.Maze[playerLine, playerColumn] == ".")
                        {
                            MazeData.Maze[playerLine, playerColumn] = "☻";
                        }
                        playerLine = Position.Row;
                        playerColumn = Position.Col;
                    }
                    Console.Clear();
                    PrintMaze();
                }
            }
            else
            {
                Console.WriteLine("Bu Labirent çözülemez.");
            }

            PrintMaze();
            Console.WriteLine("Sıradaki işlemi başlatmak için herhangi bir tuşa basın.");
            Console.WriteLine("( Önerilen tuş : 'Enter' )");
            Console.ReadKey();

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
            Console.Clear();
            PrintMaze();


            playerLine = MazeData.playerLine;
            playerColumn = MazeData.playerColumn;

            MazeData.BFSStopwatch.Start();
            List<BFSNode> clueBFS = Algorithm.BFS(MazeData.Maze, new BFSPosition(playerLine, playerColumn), new BFSPosition(MazeData.exitLine, MazeData.exitColumn));
            MazeData.BFSStopwatch.Stop();

            MazeData.BFSShortestPathLength = clueBFS.Count - 1;

            if (clueBFS != null)
            {
                if (MazeData.matrixSize <= 10)
                {
                    Console.WriteLine("BFS Labirenti Çözüyor...");
                    Thread.Sleep(1000);
                    foreach (BFSNode node in clueBFS)
                    {
                        if (MazeData.Maze[playerLine, playerColumn] == ".")
                        {
                            MazeData.Maze[playerLine, playerColumn] = "☻";
                        }
                        playerLine = node.Position.Row;
                        playerColumn = node.Position.Col;
                    }
                    Console.Clear();
                    PrintMaze();
                }
            }
            else
            {
                Console.WriteLine("Bu Labirent çözülemez.");
            }
        }
    }
}
