public class DirectionPriority : MazeRunnerBuilder
{
    Direction[] directionsPriority;
    List<int> stack = new List<int>();
    bool[] visited;


    public DirectionPriority()
    {
        directionsPriority = new Direction[4];
        directionsPriority[0] = Direction.Up;
        directionsPriority[1] = Direction.Right;
        directionsPriority[2] = Direction.Down;
        directionsPriority[3] = Direction.Left;
    }

    public void SetPriority(Direction direction, int position)
    {
        int oldPosition = 0;


        for (int i = 0; i < directionsPriority.Length; i++)
        {
            if (directionsPriority[i] == direction) oldPosition = i;
        }

        directionsPriority[oldPosition] = directionsPriority[position];
        directionsPriority[position] = direction;
    }

    public override void Build(MazeRunner runner)
    {
        GridGraph maze = runner.maze;
        visited = new bool[maze.length];
        visited[runner.initialNode] = true;

        stack.Add(runner.initialNode);

        //Guardamos el último nodo de la pila
        int currentNode = 0;
        int currentAdjacent = 0;
        bool hasAdjacent;

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
                        runner.path.Add(currentAdjacent);
                        stack.Add(currentAdjacent);
                        break;
                    }
                }
            }

            if(!hasAdjacent) stack.RemoveAt(stack.Count - 1);
        }
    }
}