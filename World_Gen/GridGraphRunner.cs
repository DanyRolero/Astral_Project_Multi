public class GridGraphRunner
{
    public int initialNode { get; protected set; }
    public GridGraph graph;

    public int[] path;
    public List<SubGraph> ways;

    public GridGraphRunner(GridGraph graph, int initialNode = 0)
    {
        this.initialNode = initialNode;
        this.graph = graph;

        path = new int[graph.length];
        ways = new List<SubGraph>();
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

        for (int i = 0; i < path.Length; i++)
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
}