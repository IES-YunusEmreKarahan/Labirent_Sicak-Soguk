class Algorithm
{

    // AStar
    public static List<Position> AStar(string[,] maze, Position start, Position end)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        var openList = new List<Node>();
        var closedList = new List<Node>();

        openList.Add(new Node(start, null, 0, CalculateHeuristic(start, end)));

        while (openList.Count > 0)
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
                    && maze[newRow, newCol] != "■"
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

    static List<Position> ReconstructPath(Node node)
    {
        var path = new List<Position>();
        while (node != null)
        {
            path.Add(node.Position);
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

    // BFS
    public static List<BFSNode> BFS(string[,] maze, BFSPosition start, BFSPosition end) // BFS
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        int[] dr = { -1, 1, 0, 0 }; // Yatay yönlendirme
        int[] dc = { 0, 0, -1, 1 }; // Dikey yönlendirme

        Queue<BFSNode> queue = new Queue<BFSNode>();
        queue.Enqueue(new BFSNode(start, null));

        bool[,] visited = new bool[rows, cols];
        visited[start.Row, start.Col] = true;

        while (queue.Count > 0)
        {
            BFSNode current = queue.Dequeue();
            BFSPosition currentPosition = current.Position;

            if (currentPosition.Equals(end))
            {
                return ReconstructPath2(current);
            }

            for (int i = 0; i < 4; i++)
            {
                int newRow = currentPosition.Row + dr[i];
                int newCol = currentPosition.Col + dc[i];

                if (IsValidLocation2(newRow, newCol, rows, cols) && maze[newRow, newCol] != "■" && !visited[newRow, newCol])
                {
                    queue.Enqueue(new BFSNode(new BFSPosition(newRow, newCol), current));
                    visited[newRow, newCol] = true;
                }
            }
        }

        return null; // Hedefe ulaşılamadı
    }

    static bool IsValidLocation2(int row, int col, int numRows, int numCols)
    {
        return row >= 0 && col >= 0 && row < numRows && col < numCols;
    }

    static List<BFSNode> ReconstructPath2(BFSNode node)
    {
        List<BFSNode> path = new List<BFSNode>();
        while (node != null)
        {
            path.Insert(0, node); // Yolu geriye döndürmek için ters sırayla ekliyoruz
            node = node.Parent;
        }
        return path;
    }

    //Greedy
    public static List<GreedyPosition> Greedy(string[,] maze, GreedyPosition start, GreedyPosition end) // Greedy
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        bool[,] visited = new bool[rows, cols];

        List<GreedyPosition> path = new List<GreedyPosition>();
        Queue<GreedyPosition> queue = new Queue<GreedyPosition>();

        queue.Enqueue(start);
        visited[start.Row, start.Col] = true;

        while (queue.Count > 0)
        {
            GreedyPosition current = queue.Dequeue();

            if (current.Equals(end))
            {
                path.Add(current);
                return path;
            }

            foreach (var neighbor in GetNeighbors(current, rows, cols))
            {
                if (!visited[neighbor.Row, neighbor.Col] && maze[neighbor.Row, neighbor.Col] != "■")
                {
                    path.Add(current);
                    queue.Enqueue(neighbor);
                    visited[neighbor.Row, neighbor.Col] = true;
                }
            }
        }

        return null;
    }

    static List<GreedyPosition> GetNeighbors(GreedyPosition position, int rows, int cols)
    {
        List<GreedyPosition> neighbors = new List<GreedyPosition>();

        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int newRow = position.Row + dRow[i];
            int newCol = position.Col + dCol[i];

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
            {
                neighbors.Add(new GreedyPosition(newRow, newCol));
            }
        }

        return neighbors;
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

class BFSNode
{
    public BFSPosition Position { get; }
    public BFSNode Parent { get; }

    public BFSNode(BFSPosition position, BFSNode parent)
    {
        Position = position;
        Parent = parent;
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

class BFSPosition
{
    public int Row { get; }
    public int Col { get; }

    public BFSPosition(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool Equals(BFSPosition other)
    {
        return Row == other.Row && Col == other.Col;
    }
}

class GreedyPosition
{
    public int Row { get; }
    public int Col { get; }

    public GreedyPosition(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool Equals(GreedyPosition other)
    {
        return Row == other.Row && Col == other.Col;
    }
}