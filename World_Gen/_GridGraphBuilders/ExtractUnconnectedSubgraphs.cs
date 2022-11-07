public class ExtractUnconnectedSubgraphs : GridGraphBuilder
{
    int lastVisitedCell = 0;
    List<int> currentAdjacents = new List<int>();
    bool[] visitedCells;

    Graph graph;

    public override void Build(GridGraph graph)
    {
        this.graph = graph;
        visitedCells = new bool[graph.length];
        int node = 0;
        int adjacent = 0;

        while(AreNonVisitedCells())
        {
            for (int n = 0; n < currentAdjacents.Count; n++)
            {
                node = currentAdjacents[n];
                for(int a = 0; a < graph.GetTotalAdjacentsFromNode(node); a++) 
                {
                    adjacent = graph[node, a];
                    if (!currentAdjacents.Contains(adjacent))
                    {
                        currentAdjacents.Add(adjacent);
                        visitedCells[adjacent] = true;
                    }
                }
            }
            graph.subgraphs[graph.subgraphs.Count - 1].AddListIdNodes(currentAdjacents);
        }
    }

    private bool AreNonVisitedCells()
    {
        for (int i = lastVisitedCell; i < graph.length; i++)
        {
            if (!visitedCells[i])
            {
                lastVisitedCell = i;
                visitedCells[i] = true;
                currentAdjacents.Clear();
                currentAdjacents.Add(i);
                graph.subgraphs.Add(new SubGraph());
                return true;
            }
        }

        return false;
    }
}