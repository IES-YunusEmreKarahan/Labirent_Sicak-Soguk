using Console = Colorful.Console; // Renk Eklentisi
using Colorful; // Renk Eklentisi
using System.Drawing;
using System.Xml.Linq;
using System.Collections;

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
            MazeData.playerLine = random.Next(MazeData.matrixSize);
            MazeData.playerColumn = random.Next(MazeData.matrixSize);
            MazeData.exitLine = random.Next(MazeData.matrixSize);
            MazeData.exitColumn = random.Next(MazeData.matrixSize);

            // Oyuncu ve çıkış işaretlerini yerleştir
            MazeData.Maze[MazeData.playerLine, MazeData.playerColumn] = "☺";
            MazeData.Maze[MazeData.exitLine, MazeData.exitColumn] = "X";
        }

        public static void PrintMaze(bool BackgroundColorChange, int shortestPathLength, int exitDistanceLength)
        {

            Color DefaultColor = Color.LightGray;

            StyleSheet styleSheet = new StyleSheet(Color.LightGray);
            styleSheet.AddStyle("☺", Color.Yellow, match => match.ToUpper());
            styleSheet.AddStyle("X", Color.Red, match => match.ToUpper());
            styleSheet.AddStyle("☻", Color.Green, match => match.ToUpper());
            StyleSheet bgstyleSheet = new StyleSheet(Color.LightGray);
            bgstyleSheet.AddStyle("■_çok_kolay", Color.FromArgb(47, 76, 4), match => match.ToUpper());
            bgstyleSheet.AddStyle("■_kolay", Color.FromArgb(140, 134, 0), match => match.ToUpper());
            bgstyleSheet.AddStyle("■_zor", Color.FromArgb(140, 68, 0), match => match.ToUpper());
            bgstyleSheet.AddStyle("■_çok_zor", Color.FromArgb(73, 8, 0), match => match.ToUpper());

            Console.Clear();

            if (BackgroundColorChange == true)
            {
                if (shortestPathLength <= 2)
                {
                    Console.BackgroundColor = Color.FromArgb(47, 76, 4);
                }
                else if (shortestPathLength <= 5)
                {
                    Console.BackgroundColor = Color.FromArgb(140, 134, 0);
                }
                else if (shortestPathLength <= 8)
                {
                    Console.BackgroundColor = Color.FromArgb(140, 68, 0);
                }
                else if (shortestPathLength > 8)
                {
                    Console.BackgroundColor = Color.FromArgb(73, 8, 0);
                }
                Console.Clear();
            }

            if (MazeData.MazeVisible == true)
            {
                string[,] Maze = MazeData.Maze;

                int rows = Maze.GetLength(0);
                int columns = Maze.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.WriteStyled(Maze[i, j] + " ", styleSheet);
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                if (exitDistanceLength <= 2)
                {
                    Console.ForegroundColor = Color.FromArgb(196, 16, 0);
                    Console.WriteLine("Çok Sıcak");
                    Console.ForegroundColor = DefaultColor;
                }
                else if (exitDistanceLength <= 5)
                {
                    Console.ForegroundColor = Color.FromArgb(216, 199, 49);
                    Console.WriteLine("Sıcak");
                    Console.ForegroundColor = DefaultColor;
                }
                else if (exitDistanceLength <= 8)
                {
                    Console.ForegroundColor = Color.FromArgb(120, 214, 198);
                    Console.WriteLine("Soğuk");
                    Console.ForegroundColor = DefaultColor;
                }
                else if (exitDistanceLength > 8)
                {
                    Console.ForegroundColor = Color.FromArgb(48, 133, 195);
                    Console.WriteLine("Çok Soğuk");
                    Console.ForegroundColor = DefaultColor;
                }

                Console.WriteLine("Mesafe: " + exitDistanceLength);


                if (MazeData.showclue == true)
                {
                    Console.WriteLine("(ipucu aktif) İzlemeniz gereken yol:");
                    foreach (string ipucu in MazeData.ClueList)
                    {
                        Console.Write(ipucu + " ");
                    }
                }
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