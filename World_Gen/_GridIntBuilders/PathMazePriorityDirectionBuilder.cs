public class PathMazePriorityDirection : Builder<int>
{
    GridGraph maze;
    Direction[] directionsPriority = new Direction[4];
    List<int> stack = new List<int>();
    bool[] visited;
    public int[] path;


    int initialNode;
    int currentNode = 0;
    int currentPosition = 0;
    bool hasAdjacent = false;
    int currentAdjacent = 0;
    
    /*-----------------------------------------------------*/
    public PathMazePriorityDirection(GridGraph maze, int initialNode = 0)
    {
        this.maze = maze;
        this.initialNode = initialNode;
        path = new int[maze.length];
        path[currentPosition] = initialNode;

        visited = new bool[maze.length];
        visited[initialNode] = true;
        stack.Add(initialNode);

        directionsPriority[0] = Direction.Up;
        directionsPriority[1] = Direction.Right;
        directionsPriority[2] = Direction.Down;
        directionsPriority[3] = Direction.Left;
    }

    /*-----------------------------------------------------*/
    public void SetPriority(Direction direction, int priority)
    {
        int oldPosition = 0;

        for (int i = 0; i < directionsPriority.Length; i++)
        {
            if (directionsPriority[i] == direction) oldPosition = i;
        }

        directionsPriority[oldPosition] = directionsPriority[priority];
        directionsPriority[priority] = direction;
    }

    /*-----------------------------------------------------*/
    public override void Build(Grid<int> grid)
    {
        if (grid.length != maze.length) grid.Reset(maze.columns, maze.rows);

        grid.SetValue(initialNode, currentPosition);

        while (stack.Count > 0)
        {
            hasAdjacent = false;
            currentNode = stack[stack.Count - 1];

            for (int i = 0; i < directionsPriority.Length; i++)
            {
                if (maze.HasAdjacent(currentNode, directionsPriority[i]))
                {
                    currentAdjacent = maze.GetAdjacent(currentNode, directionsPriority[i]);

                    if (!visited[currentAdjacent])
                    {
                        hasAdjacent = true;
                        visited[currentAdjacent] = true;
                        currentPosition++;
                        grid.SetValue(currentAdjacent, currentPosition);
                        stack.Add(currentAdjacent);
                        path[currentPosition] = currentAdjacent;
                        break;
                    }
                }
            }

            if (!hasAdjacent) stack.RemoveAt(stack.Count - 1);
        }
    }
}