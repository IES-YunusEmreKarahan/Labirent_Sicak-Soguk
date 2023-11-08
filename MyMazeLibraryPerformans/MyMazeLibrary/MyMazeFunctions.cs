using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi
using System.Drawing;
using System.Xml.Linq;
using System.Collections;
using System.Diagnostics;

namespace MyMazeLibrary
{
    public class MazeFunctions
    {

        public class MazeData
        {
            public static string[,] Maze { get; set; }
            public static int playerLine { get; set; }
            public static int playerColumn { get; set; }
            public static int exitLine { get; set; }
            public static int exitColumn { get; set; }
            public static int playerStep { get; set; }
            public static int newLine { get; set; }
            public static int newColumn { get; set; }
            public static int completedLevels { get; set; }
            public static int matrixSize { get; set; }
            public static bool MazeVisible { get; set; }
            public static bool showclue { get; set; }
            public static List<string> ClueList { get; set; }
            public static Stopwatch AStarStopwatch { get; set; }
            public static int AStarShortestPathLength { get; set; }
            public static Stopwatch BFSStopwatch { get; set; }
            public static int BFSShortestPathLength { get; set; }
            public static Stopwatch GreedyStopwatch { get; set; }
            public static int GreedyShortestPathLength { get; set; }
            public static bool BackgroundColorChange { get; set; }

        }

        public static void GenerateRandomMaze()
        {
            MazeData.playerStep = 0;
            MazeData.Maze = new string[MazeData.matrixSize, MazeData.matrixSize];
            Random random = new Random();

            for (int i = 0; i < MazeData.matrixSize; i++)
            {
                for (int j = 0; j < MazeData.matrixSize; j++)
                {
                    int randomNumber = random.Next(4);
                    if (randomNumber == 0)
                    {
                        MazeData.Maze[i, j] = "■"; // Duvar
                    }
                    else
                    {
                        MazeData.Maze[i, j] = "."; // Yol
                    }
                }
            }

            // random oyuncu ve çıkış konumları belirle
            MazeData.playerLine = 0;
            MazeData.playerColumn = 0;
            MazeData.exitLine = MazeData.matrixSize - 1;
            MazeData.exitColumn = MazeData.matrixSize - 1;

            // Oyuncu ve çıkış işaretlerini yerleştir
            MazeData.Maze[MazeData.playerLine, MazeData.playerColumn] = "☺";
            MazeData.Maze[MazeData.exitLine, MazeData.exitColumn] = "X";
        }

        public static void PrintMaze()
        {
            Color DefaultColor = Color.LightGray;

            StyleSheet styleSheet = new StyleSheet(Color.LightGray);
            styleSheet.AddStyle("☺", Color.Yellow, match => match.ToUpper());
            styleSheet.AddStyle("X", Color.Red, match => match.ToUpper());
            styleSheet.AddStyle("☻", Color.Green, match => match.ToUpper());

            Console.Clear();

            string[,] Maze = MazeData.Maze;

            int rows = Maze.GetLength(0);
            int columns = Maze.GetLength(1);

            if (MazeData.matrixSize <= 10)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.WriteStyled(Maze[i, j] + " ", styleSheet);
                    }
                    Console.WriteLine();
                }
            }

            if (MazeData.AStarStopwatch != null && MazeData.BFSStopwatch != null && MazeData.GreedyStopwatch != null)
            {
                Console.WriteLine("AStar = Çalışma süresi: " + MazeData.AStarStopwatch.Elapsed.TotalMilliseconds + " Milisaniye / Adım Sayısı: " + MazeData.AStarShortestPathLength);
                Console.WriteLine("Greedy = Çalışma süresi: " + MazeData.GreedyStopwatch.Elapsed.TotalMilliseconds + " Milisaniye / Adım Sayısı: " + MazeData.GreedyShortestPathLength);
                Console.WriteLine("BFS = Çalışma süresi: " + MazeData.BFSStopwatch.Elapsed.TotalMilliseconds + " Milisaniye / Adım Sayısı: " + MazeData.BFSShortestPathLength);
            }

        }

        public static bool IsMazeSolvable(string[,] Maze)
        {
            int rows = Maze.GetLength(0);
            int columns = Maze.GetLength(1);
            bool[,] visited = new bool[rows, columns];

            Queue<(int, int)> queue = new Queue<(int, int)>();
            int startX = 0;
            int startY = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Maze[i, j] == "☺")
                    {
                        startX = i;
                        startY = j;
                        break;
                    }
                }
            }

            queue.Enqueue((startX, startY));
            visited[startX, startY] = true;

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                if (Maze[x, y] == "X")
                {
                    return true;
                }

                if (x > 0 && (Maze[x - 1, y] == "." || Maze[x - 1, y] == "X") && !visited[x - 1, y])
                {
                    queue.Enqueue((x - 1, y));
                    visited[x - 1, y] = true;
                }

                if (x < rows - 1 && (Maze[x + 1, y] == "." || Maze[x + 1, y] == "X") && !visited[x + 1, y])
                {
                    queue.Enqueue((x + 1, y));
                    visited[x + 1, y] = true;
                }

                if (y > 0 && (Maze[x, y - 1] == "." || Maze[x, y - 1] == "X") && !visited[x, y - 1])
                {
                    queue.Enqueue((x, y - 1));
                    visited[x, y - 1] = true;
                }

                if (y < columns - 1 && (Maze[x, y + 1] == "." || Maze[x, y + 1] == "X") && !visited[x, y + 1])
                {
                    queue.Enqueue((x, y + 1));
                    visited[x, y + 1] = true;
                }
            }

            return false;
        }

    }
}