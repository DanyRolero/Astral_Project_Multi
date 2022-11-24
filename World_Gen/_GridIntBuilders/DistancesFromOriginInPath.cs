//Construye matriz enteros desde recorrido de GridGraphRunner
public class DistancesFromOriginInPath : Builder<int>
{
    GridGraphRunner runner;

    public DistancesFromOriginInPath(GridGraphRunner runner)
    {
        this.runner = runner;
    }

    public override void Build(Grid<int> grid)
    {
        GridGraph graph = runner.graph;
        int currentAdjacent = 0;

        grid.Reset(graph.columns, graph.rows);

    }
}


