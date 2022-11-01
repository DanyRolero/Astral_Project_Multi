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
            if (adjacentsMask[i] != -1)
            {
                int y = i / graph.columns;
                int x = i % graph.columns;

                if (y > 0) graph.AddAdjacent(i, i - graph.columns);
                if (x > 0) graph.AddAdjacent(i, i - 1);
                if (x < graph.columns - 1) graph.AddAdjacent(i, i + 1);
                if (y < graph.rows - 1) graph.AddAdjacent(i, i + graph.columns);


            }
        }
    }

    public GridGraph Create(Grid<int> mask)
    {
        GridGraph graph = new GridGraph(mask.columns, mask.rows);


        return graph;
    } 
}
