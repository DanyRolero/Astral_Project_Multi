//Conecta todos los nodos adyacentes de un grafo en forma de grilla
public class ConnectedGridGraphBuilder : GridGraphBuilder
{
    public override void Build(GridGraph graph)
    {
        for (int i = 0; i < graph.length; i++)
        {
            int y = i / graph.columns;
            int x = i % graph.columns;

            if (y > 0) graph.AddAdjacent(i, i - graph.columns);
            if (x > 0) graph.AddAdjacent(i, i - 1);
            if (x < graph.columns - 1) graph.AddAdjacent(i, i + 1);
            if (y < graph.rows - 1) graph.AddAdjacent(i, i + graph.columns);
        }
    }
}