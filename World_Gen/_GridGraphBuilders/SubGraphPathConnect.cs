//Conecta nodo entre dos subgrafos a partir del recorrido de un runner
public class SubGraphPathConnect : GridGraphBuilder
{
    GridGraph graph;
    Grid<int> gridSubGraphsIds;
    int[] path;

    List<int> subgraphsVisited = new List<int>();

    public SubGraphPathConnect(GridGraphRunner runner, Grid<int> gridSubGraphsIds)
    {
        this.graph = new GridGraph();
        this.gridSubGraphsIds = gridSubGraphsIds;
        this.path = runner.path;
    }

    public override void Build(GridGraph graph)
    {
        this.graph = graph;
        subgraphsVisited.Add(gridSubGraphsIds[0]);

        for (int i = 0; i < path.Length - 1; i++)
        {
            int currentNode = path[i];
            int nextNode = path[i + 1];

            if (gridSubGraphsIds[currentNode] == gridSubGraphsIds[nextNode]) continue;

            if(!subgraphsVisited.Contains(gridSubGraphsIds[nextNode]))
            {
                subgraphsVisited.Add(gridSubGraphsIds[nextNode]);
                graph.AddAdjacent(currentNode, nextNode);
            }

        }
    }
}