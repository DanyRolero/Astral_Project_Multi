//Buildea subgrafos de un grafo a partir de un graph runner y grilla de distancias.
public class SubWaysSubGraphs : GridGraphBuilder
{
    GridGraph graph;
    List<int> path;

    int currentNode;
    int currentWay;
    int previousNode;

    public SubWaysSubGraphs(GridGraphRunner runner)
    {
        this.graph = runner.graph;
        this.path = runner.path.ToList<int>();
    }

    public override void Build(GridGraph graph)
    {
        this.graph = graph;

        graph.AddSubgraph();
        graph.AddSubGraphNode(0, path[0]);

        currentWay = 0;
        
        for (int i = 1; i < path.Count; i++)
        {
            currentNode = path[i];
            previousNode = path[i - 1];

            if (graph.CheckHasAdjacent(currentNode, previousNode))
            {
                graph.AddSubGraphNode(currentWay,currentNode);
                continue;
            }

            graph.AddSubgraph();
            currentWay++;
        }
    }

    private void UpdateLowestPreviousNode(Direction direction)
    {
        if (graph.HasAdjacent(currentNode, direction))
        {
            if (path.IndexOf(graph.GetAdjacent(currentNode, direction)) < currentNode)
            {
                
            }
        }



    }
}


