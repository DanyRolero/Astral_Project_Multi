    public class SubGraphsIdentifier : Builder<int>
    {
        GridGraph graph;

        public SubGraphsIdentifier(GridGraph graph)
        {
            this.graph = graph;
        }

        public override void Build(Grid<int> grid)
        {
            int index = 0;

            for (int s = 0; s < graph.totalSubgraps; s++)
            {
                for (int n = 0; n < graph.GetTotalNodesFromSubgraphs(s); n++)
                {
                    index = graph.GetNodeFromSubgraph(s, n);
                    grid.SetValue(index, s);
                }
            }
        }
    }

