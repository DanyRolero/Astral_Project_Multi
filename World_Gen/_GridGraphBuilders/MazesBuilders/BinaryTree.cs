public class BinaryTree : GridGraphBuilder
{
    float coinRatio;
    Corner origin;

    Direction horizontalDirection;
    Direction verticalDirection;

    public BinaryTree(float coinRatio = 0.5f, Corner origin = Corner.Left_Down)
    {
        this.coinRatio = coinRatio;
        this.origin = origin;
        SetDirections();
    }

    private void SetDirections()
    {
        if(origin == Corner.Right_Up)
        {
            horizontalDirection = Direction.Left;
            verticalDirection = Direction.Down;
        }
        else if (origin == Corner.Right_Down)
        {
            horizontalDirection = Direction.Left;
            verticalDirection = Direction.Up;
        }
        else if (origin == Corner.Left_Down)
        {
            horizontalDirection = Direction.Right;
            verticalDirection = Direction.Up;
        }
        else if (origin == Corner.Left_Up)
        {
            horizontalDirection = Direction.Right;
            verticalDirection = Direction.Down;
        }
    }

    public override void Build(GridGraph graph)
    {
        
        GridGraph reference = new GridGraph(graph.columns, graph.rows);
        reference.Build(new ConnectedGridGraphBuilder());
        List<int> adjacents = new List<int>();

        for (int i = 0; i < graph.length; i++)
        {
            if (reference.HasAdjacent(i, horizontalDirection))
            {
                adjacents.Add(reference.GetAdjacent(i, horizontalDirection));
            }

            if (reference.HasAdjacent(i, verticalDirection))
            {
                adjacents.Add(reference.GetAdjacent(i, verticalDirection));
            }

            if (adjacents.Count == 1)
            {
                graph.AddAdjacent(i, adjacents[0]);
                graph.AddAdjacent(adjacents[0], i);
            }

            else if (adjacents.Count == 2)
            {
                if (AstralRandom.FlipCoin(coinRatio))
                {
                    graph.AddAdjacent(i, adjacents[0]);
                    graph.AddAdjacent(adjacents[0], i);
                }

                else
                {
                    graph.AddAdjacent(i, adjacents[1]);
                    graph.AddAdjacent(adjacents[1], i);
                }

            }

            adjacents.Clear();
        }

       
    }
}