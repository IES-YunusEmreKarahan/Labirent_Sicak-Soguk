using Console = Colorful.Console; // Renk Eklentisi+
using Colorful; // Renk Eklentisi+
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
            public static int matrixSize { get; set; }
            public static int playerStep { get; set; }
            public static int completedLevels { get; set; }
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

        public static void PrintMaze()
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
    }
}