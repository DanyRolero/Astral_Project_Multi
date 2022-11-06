using System;

public class OddEvenConnector : GridGraphBuilder
{
    Grid<int> adjacentsMask;

    public OddEvenConnector(Grid<int> adjacentsMask)
    {
        this.adjacentsMask = adjacentsMask;
    }

    public override void Build(GridGraph graph)
    {
        for (int i = 0; i < graph.length; i++)
        {
            int y = i / graph.columns;
            int x = i % graph.columns;

            if (y > 0)
            {
                if (adjacentsMask[i] % 2 == adjacentsMask[i - graph.columns] % 2)
                {
                    graph.AddAdjacent(i, i - graph.columns);
                }
            }

            if (x > 0) 
            {
                if (adjacentsMask[i] % 2 == adjacentsMask[i - 1] % 2)
                {
                    graph.AddAdjacent(i, i-1);
                } 
            }

            if (x < graph.columns - 1) 
            {
                if (adjacentsMask[i] % 2 == adjacentsMask[i + 1] % 2)
                {
                    graph.AddAdjacent(i, i + 1);
                }
            }

            
            if (y < graph.rows - 1) 
            {
                if (adjacentsMask[i] % 2 == adjacentsMask[i + graph.columns] % 2)
                {
                    graph.AddAdjacent(i, i + graph.columns);
                }
            }
            
            
        }
    }

    protected bool IsEqualOddOrEvenTwoValues(int value1, int value2) 
    {
        return false;
    }

    public GridGraph Create()
    {
        GridGraph graph = new GridGraph(adjacentsMask.columns, adjacentsMask.rows);
        Build(graph);
        return graph;
    }
}
