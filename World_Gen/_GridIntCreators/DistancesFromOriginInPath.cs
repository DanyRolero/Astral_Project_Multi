//Crea matrices de enteros a partir del recorrido de un GridGraphRunner
//Los valores de la matriz representan la distancia con respecto al nodo inicial
//Del recorrido del runner
public class DistancesFromOriginInPathCreator : GridCreator<int>
{
    GridGraphRunner runner;

    int currentAdjacent = 0;
    int largestAdjacent = 0;
    int currentPosition = 0;

    GridGraph graph;
    Grid<int> grid;
    int[] path;

    public DistancesFromOriginInPathCreator(GridGraphRunner runner)
    {
        this.runner = runner;
        this.graph = runner.graph;
        grid = new Grid<int>(-1, graph.columns, graph.rows);
        path = runner.path;
        grid.SetValue(path[0], 0);
    }

    public override Grid<int> Create()
    {
        for (int i = 1; i < path.Length; i++)
        {
            currentPosition = path[i];
            UpdateLargestAdjacent(Direction.Up);
            UpdateLargestAdjacent(Direction.Right);
            UpdateLargestAdjacent(Direction.Down);
            UpdateLargestAdjacent(Direction.Left);
            grid.SetValue(path[i], largestAdjacent + 1);
            largestAdjacent = 0;
        }
        return grid;
    }

    private void UpdateLargestAdjacent(Direction direction)
    {
        if (graph.HasAdjacent(currentPosition, direction))
        {
            currentAdjacent = grid.GetAdjacent(currentPosition, direction);
            if (currentAdjacent > largestAdjacent)
            {
                largestAdjacent = currentAdjacent;
            }
        }
    }

}