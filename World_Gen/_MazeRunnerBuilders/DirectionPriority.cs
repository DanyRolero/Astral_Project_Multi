public class DirectionPriority : MazeRunnerBuilder
{
    Direction[] directionsPriority;

    public DirectionPriority()
    {
        directionsPriority = new Direction[4];
        directionsPriority[0] = Direction.Up;
        directionsPriority[1] = Direction.Right;
        directionsPriority[2] = Direction.Down;
        directionsPriority[3] = Direction.Left;
    }

    public void SetPriority(Direction direction, int position)
    {
        int oldPosition = 0;

        for (int i = 0; i < directionsPriority.Length; i++)
        {
            if (directionsPriority[i] == direction) oldPosition = i;
        }

        directionsPriority[oldPosition] = directionsPriority[position];
        directionsPriority[position] = direction;        
    }

    public override void Build(MazeRunner runner)
    {
        throw new NotImplementedException();
    }
}