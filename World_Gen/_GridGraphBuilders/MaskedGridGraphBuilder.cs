//Conecta los nodos de un grafo en forma de grilla.
//Deja aislados los nodos enmascarados.
public class MaskedGridGraphBuilder : GridGraphBuilder
{
    public Grid<bool> mask;

    public MaskedGridGraphBuilder(Grid<bool> mask)
    {
        this.mask = mask;
    }

    public override void Build(GridGraph graph)
    {
        if(mask.columns != graph.columns || mask.rows != graph.rows)
        {
            graph.Reset(mask.columns, mask.rows);
        }
        
        for (int i = 0; i < graph.length; i++)
        {
            if (mask[i])
            {
                int y = i / graph.columns;
                int x = i % graph.columns;

                if (y > 0 && mask[i - graph.columns]) graph.AddAdjacent(i, i - graph.columns);
                if (x > 0 && mask[i - 1]) graph.AddAdjacent(i, i - 1);
                if (x < graph.columns - 1 && mask[i + 1]) graph.AddAdjacent(i, i + 1);
                if (y < graph.rows - 1 && mask[i + graph.columns]) graph.AddAdjacent(i, i + graph.columns);
            }
        }

    }
}