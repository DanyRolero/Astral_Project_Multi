public class BinaryTree : GridGraphBuilder
{
    float coinRatio;
    Corner origin;

    GridGraph graph;
    Direction horizontalDirection;
    Direction verticalDirection;


    public BinaryTree(float coinRatio = 0.5f, Corner origin = Corner.Left_Down)
    {
        this.coinRatio = coinRatio;
        this.origin = origin;
        SetDirections();
    }

    public override void Build(GridGraph graph)
    {
        this.graph = graph;
        
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
}