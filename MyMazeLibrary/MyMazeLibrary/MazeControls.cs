using System.Xml.Linq;
using static MyMazeLibrary.MazeFunctions;

namespace MyMazeLibrary
{
    public class MazeControls
    {

        public static void Controls(ConsoleKeyInfo key, bool BackgroundColorChange, int shortestPathLength, int exitDistanceLength)
        {
            MazeData.newLine = MazeData.playerLine;
            MazeData.newColumn = MazeData.playerColumn;

            if (key.Key == ConsoleKey.W && MazeData.playerLine > 0 && (MazeData.Maze[MazeData.playerLine - 1, MazeData.playerColumn] == "." || MazeData.Maze[MazeData.playerLine - 1, MazeData.playerColumn] == "X" || MazeData.Maze[MazeData.playerLine - 1, MazeData.playerColumn] == "☻"))
            {
                MazeData.newLine--;
                MazeData.playerStep++;

            }
            else if (key.Key == ConsoleKey.S && MazeData.playerLine < MazeData.matrixSize - 1 && (MazeData.Maze[MazeData.playerLine + 1, MazeData.playerColumn] == "." || MazeData.Maze[MazeData.playerLine + 1, MazeData.playerColumn] == "X" || MazeData.Maze[MazeData.playerLine + 1, MazeData.playerColumn] == "☻"))
            {
                MazeData.newLine++;
                MazeData.playerStep++;

            }
            else if (key.Key == ConsoleKey.A && MazeData.playerColumn > 0 && (MazeData.Maze[MazeData.playerLine, MazeData.playerColumn - 1] == "." || MazeData.Maze[MazeData.playerLine, MazeData.playerColumn - 1] == "X" || MazeData.Maze[MazeData.playerLine, MazeData.playerColumn - 1] == "☻"))
            {
                MazeData.newColumn--;
                MazeData.playerStep++;

            }
            else if (key.Key == ConsoleKey.D && MazeData.playerColumn < MazeData.matrixSize - 1 && (MazeData.Maze[MazeData.playerLine, MazeData.playerColumn + 1] == "." || MazeData.Maze[MazeData.playerLine, MazeData.playerColumn + 1] == "X" || MazeData.Maze[MazeData.playerLine, MazeData.playerColumn + 1] == "☻"))
            {
                MazeData.newColumn++;
                MazeData.playerStep++;

            }

            else if (key.KeyChar == 'q' || key.KeyChar == 'Q') // Oyunu Sonlandırmak
            {
                Console.WriteLine("Oyun bitti. Toplam Skor: " + MazeData.completedLevels);
                MazeData.completedLevels = 0;
                MazeData.playerStep = 0;
                Console.WriteLine("Çıkış yapmak için bir tuşa basın.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            else if (key.KeyChar == 'l' || key.KeyChar == 'L') // Labirenti Görünüm Modunu Ayarlamak için (Görünmez/Görünür)
            {
                MazeData.MazeVisible = !MazeData.MazeVisible;

                if (MazeData.MazeVisible == true)
                {
                    BackgroundColorChange = false;
                    PrintMaze(BackgroundColorChange, shortestPathLength, exitDistanceLength);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Labirent Görünmez Halde");
                }
            }

            try
            {
                MazeData.Maze[MazeData.playerLine, MazeData.playerColumn] = ".";
                MazeData.playerLine = MazeData.newLine;
                MazeData.playerColumn = MazeData.newColumn;
                MazeData.Maze[MazeData.playerLine, MazeData.playerColumn] = "☺";
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("HATA");
            }

        }

    }

    class Node
    {
        public Position Position { get; }
        public Node Parent { get; set; }
        public int G { get; set; }
        public int H { get; }
        public int Cost => G + H;

        public Node(Position position, Node parent, int g, int h)
        {
            Position = position;
            Parent = parent;
            G = g;
            H = h;
        }
    }

    class Position
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool Equals(Position other)
        {
            return Row == other.Row && Col == other.Col;
        }
    }
}
