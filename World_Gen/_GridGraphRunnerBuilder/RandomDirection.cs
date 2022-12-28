//Recorre un grafo según en orden aleatorio
public class RandomDirection : GridGraphRunnerBuilder
{
    GridGraph graph = new GridGraph();
    List<int> stack = new List<int>();
    bool[] visited = Array.Empty<bool>();

    int currentNode = 0;

    int randomAdjacent;
    int currentAdjacent = 0;

    int currentWay = 0;
    bool isBackTracking = false;

    List<int> possibleAdjacents = new List<int>();

    /*------------------------------------------------------------------------*/
    public override void Build(GridGraphRunner runner)
    {
        graph = runner.graph;
        stack.Add(runner.initialNode);

        visited = new bool[graph.length];
        visited[runner.initialNode] = true;

        runner.AddNodeToPath(runner.initialNode);

        runner.AddWay();
        runner.AddNodeToWay(0, runner.initialNode);

        while (stack.Count > 0)
        {
            
            //Update current node
            currentNode = stack[stack.Count - 1];
            possibleAdjacents.Clear();
            
            //GetPossibleAdjacents
            GetPossibleAdjacent(Direction.Up);
            GetPossibleAdjacent(Direction.Down);
            GetPossibleAdjacent(Direction.Left);
            GetPossibleAdjacent(Direction.Right);

            if (possibleAdjacents.Count == 0)
            {
                isBackTracking = true;
                stack.RemoveAt(stack.Count - 1);
                continue;
            }

            if (possibleAdjacents.Count == 1)
            {
                currentAdjacent = possibleAdjacents[0];
            }

            if (possibleAdjacents.Count > 1)
            {
                randomAdjacent = AstralRandom.IntRange(0, possibleAdjacents.Count - 1);
                currentAdjacent = possibleAdjacents[randomAdjacent];
            }

            if (isBackTracking)
            {
                runner.AddWay();
                currentWay = runner.ways.Count - 1;
                runner.AddNodeToWay(currentWay, currentNode);
                isBackTracking = false;
            }

            visited[currentAdjacent] = true;
            stack.Add(currentAdjacent);

            //Update path
            runner.AddNodeToPath(currentAdjacent);

            //Update way
            runner.AddNodeToWay(currentWay, currentAdjacent);
        }
    }


    /*------------------------------------------------------------------------*/
    public void GetPossibleAdjacent(Direction direction)
    {
        if (graph.HasAdjacent(currentNode, direction))
        {
            if (!visited[graph.GetAdjacent(currentNode, direction)])
            {
                possibleAdjacents.Add(graph.GetAdjacent(currentNode, direction));
            }
        }
    }

}