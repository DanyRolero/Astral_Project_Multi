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

            if (y > 0 && IsEqualOddOrEvenTwoValues(adjacentsMask[i], adjacentsMask[i - graph.columns]))
            {
                graph.AddAdjacent(i, i - graph.columns);
            }

            if (x > 0 && IsEqualOddOrEvenTwoValues(adjacentsMask[i], adjacentsMask[i - 1]))
            {
                graph.AddAdjacent(i, i - 1);
            }

            if (x < graph.columns - 1 && IsEqualOddOrEvenTwoValues(adjacentsMask[i], adjacentsMask[i + 1]))
            {
                graph.AddAdjacent(i, i + 1);
            }

            if (y < graph.rows - 1 && IsEqualOddOrEvenTwoValues(adjacentsMask[i], adjacentsMask[i + graph.columns]))
            {
                graph.AddAdjacent(i, i + graph.columns);
            }
        }
    }

    protected bool IsEqualOddOrEvenTwoValues(int value1, int value2)
    {
        if (value1 % 2 == value2 % 2) return true;
        return false;
    }
}
