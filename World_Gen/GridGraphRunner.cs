public class GridGraphRunner
{
    public int initialNode { get; protected set; }
    public GridGraph graph;

    public List<int> path = new List<int>();
    public List<SubGraph> ways;

    public GridGraphRunner(GridGraph graph, int initialNode = 0)
    {
        this.initialNode = initialNode;
        this.graph = graph;

        ways = new List<SubGraph>();
    }
    /*------------------------------------------------------------------------*/
    public void AddNodeToPath(int node)
    {
        path.Add(node);
    }

    /*------------------------------------------------------------------------*/
    public void AddWay()
    {
        ways.Add(new SubGraph());
    }

    public void AddNodeToWay(int way, int node)
    {
        ways[way].AddIdNode(node);
    }

    /*------------------------------------------------------------------------*/
    public void Build(GridGraphRunnerBuilder builder)
    {
        builder.Build(this);
    }

    /*------------------------------------------------------------------------*/
    public override string ToString()
    {
        string str = "Recorrido de GridGraph Runner:\n";

        for (int i = 0; i < path.Count; i++)
        {
            str += path[i].ToString() + " -> ";
        }
        str += "\nCaminos:\n";

        for (int i = 0; i < ways.Count; i++)
        {
            str += "Camino " + i.ToString() + " -> ";
            for(int j = 0; j < ways[i].idNodes.Count; j++)
            {
                str += ways[i].idNodes[j].ToString() + " ";
            }
            str += "\n";
        }

        return str;
    }

    public void PrintOnConsole()
    {
        Console.WriteLine(ToString());
    }
}