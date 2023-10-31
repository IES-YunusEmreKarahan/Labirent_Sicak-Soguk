class Algorithm
{

    public static List<Node> AStar(string[,] Maze, Position start, Position end)
    {
        int rows = Maze.GetLength(0);
        int cols = Maze.GetLength(1);

        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        var openList = new List<Node>();
        var closedList = new List<Node>();

        openList.Add(new Node(start, null, 0, CalculateHeuristic(start, end)));

        while (openList.Any())
        {
            var current = openList.OrderBy(node => node.Cost).First();

            if (current.Position.Equals(end))
            {
                return ReconstructPath(current);
            }

            openList.Remove(current);
            closedList.Add(current);

            for (int i = 0; i < 4; i++)
            {
                int newRow = current.Position.Row + dx[i];
                int newCol = current.Position.Col + dy[i];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols
                    && Maze[newRow, newCol] != "■"
                    && !closedList.Any(node => node.Position.Row == newRow && node.Position.Col == newCol))
                {
                    var neighbor = new Position(newRow, newCol);
                    var g = current.G + 1;
                    var h = CalculateHeuristic(neighbor, end);

                    var existingNode = openList.FirstOrDefault(node => node.Position.Row == newRow && node.Position.Col == newCol);

                    if (existingNode == null)
                    {
                        openList.Add(new Node(neighbor, current, g, h));
                    }
                    else if (g + h < existingNode.Cost)
                    {
                        existingNode.Parent = current;
                        existingNode.G = g;
                    }
                }
            }
        }

        return null;
    }

    static List<Node> ReconstructPath(Node node)
    {
        var path = new List<Node>();
        while (node != null)
        {
            path.Add(node);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }

    static int CalculateHeuristic(Position from, Position to)
    {
        // Manhattan mesafesi hesaplama
        return Math.Abs(from.Row - to.Row) + Math.Abs(from.Col - to.Col);
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