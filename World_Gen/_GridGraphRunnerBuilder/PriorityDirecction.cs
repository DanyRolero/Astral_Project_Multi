//Recorre un grafo según orden de prioridad al elegir direcciones
public class PriorityDirecction : GridGraphRunnerBuilder
{
    GridGraph graph;
    Direction[] directionsPriority = new Direction[4];
    List<int> stack = new List<int>();
    bool[] visited;

    int currentNode = 0;
    int currentPosition = 0;
    bool hasAdjacent = false;
    int currentAdjacent = 0;


    public PriorityDirecction()
    {
        directionsPriority[0] = Direction.Up;
        directionsPriority[1] = Direction.Right;
        directionsPriority[2] = Direction.Down;
        directionsPriority[3] = Direction.Left;
    }

    /*------------------------------------------------------------------------*/
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

    /*------------------------------------------------------------------------*/
    public override void Build(GridGraphRunner runner)
    {
        graph = runner.graph;
        stack.Add(runner.initialNode);
        visited = new bool[graph.length];
        visited[runner.initialNode] = true;
        runner.path[currentPosition] = runner.initialNode;

        while (stack.Count > 0)
        {
            hasAdjacent = false;
            currentNode = stack[stack.Count - 1];

            for (int i = 0; i < directionsPriority.Length; i++)
            {
                if (graph.HasAdjacent(currentNode, directionsPriority[i]))
                {
                    currentAdjacent = graph.GetAdjacent(currentNode, directionsPriority[i]);

                    if (!visited[currentAdjacent])
                    {
                        hasAdjacent = true;
                        visited[currentAdjacent] = true;
                        currentPosition++;
                        stack.Add(currentAdjacent);
                        runner.path[currentPosition] = currentAdjacent;
                        break;
                    }
                }
            }

            if (!hasAdjacent) stack.RemoveAt(stack.Count - 1);
        }
    }
}