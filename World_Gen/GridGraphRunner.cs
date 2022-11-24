public class GridGraphRunner
{
    public int initialNode { get; protected set; }
    public GridGraph graph;

    public int[] path;

    public GridGraphRunner(GridGraph graph, int initialNode = 0)
    {
        this.initialNode = initialNode;
        this.graph = graph;

        path = new int[graph.length];
    }


    public void Build(GridGraphRunnerBuilder builder)
    {
        builder.Build(this);
    }


    public override string ToString()
    {
        string str = "Recorrido de GridGraph Runner:\n";

        for (int i = 0; i < path.Length; i++)
        {
            str += path[i].ToString() + " -> ";
        }
        str += "\n";

        return str;
    }
}