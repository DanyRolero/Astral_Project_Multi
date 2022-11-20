public class MazeRunner
{
    public int initialNode { get; protected set; }
    public List<int> path = new List<int>();
    public GridGraph maze { get; protected set; }

    public MazeRunner(GridGraph maze, int initialNode = 0)
    {
        this.initialNode = initialNode;
        this.maze = maze;

        path.Add(initialNode);
    }

    public void Build(MazeRunnerBuilder builder)
    {
        builder.Build(this);
    }


    public override string ToString()
    {
        string str = "Recorrido del Maze Runner:\n";

        for (int i = 0; i < path.Count; i++)
        {
            str += path[i].ToString() + ", ";
        }
        return str;
    }
}