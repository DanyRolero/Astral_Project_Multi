public abstract class MazeRunner
{
    int initialNode;
    public List<int> path = new List<int>();
    GridGraph maze;

    public MazeRunner(GridGraph maze, int initialNode = 0)
    {
        this.initialNode = initialNode;
        this.maze = maze;

        path.Add(initialNode);
    }

    
}
