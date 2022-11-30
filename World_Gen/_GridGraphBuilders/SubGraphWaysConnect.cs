//Conecta nodo entre dos subgrafos a partir del recorrido de un runner
public class SubGraphWaysConnect : GridGraphBuilder
{
    GridGraph graph;
    Grid<int> gridSubGraphsIds;
    List<SubGraph> ways;

    List<int> subgraphsVisited = new List<int>();

    int currentNode;
    int nextNode;

    public SubGraphWaysConnect(GridGraphRunner runner, Grid<int> gridSubGraphsIds)
    {
        this.graph = new GridGraph();
        this.gridSubGraphsIds = gridSubGraphsIds;
        this.ways = runner.ways;
    }

    public override void Build(GridGraph graph)
    {
        this.graph = graph;
        int firstIdSubgraph = ways[0][0];
        subgraphsVisited.Add(firstIdSubgraph);

        for (int i = 0; i < ways.Count; i++)
        {
            for(int j = 0; j < ways[i].length - 1; j++)
            {
                currentNode = ways[i][j];
                nextNode = ways[i][j + 1];

                if (gridSubGraphsIds[currentNode] == gridSubGraphsIds[nextNode]) continue;
                if (subgraphsVisited.Contains(gridSubGraphsIds[nextNode])) continue;

                subgraphsVisited.Add(gridSubGraphsIds[nextNode]);
                graph.AddAdjacent(currentNode, nextNode);
            }
        }
    }
}