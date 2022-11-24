//Conecta los nodos de un grafo a partir de una matriz de enteros.
//Dos nodos son adyacentes si sus valores respecto a la matriz no coinciden.
public class AdjacentsDesequalGridIntValuesConnector : GridGraphBuilder
{
    Grid<int> adjMask;

    public AdjacentsDesequalGridIntValuesConnector(Grid<int> adjMask)
    {
        this.adjMask = adjMask;
    }

    public override void Build(GridGraph graph)
    {
        int columns = adjMask.columns;
        int rows = adjMask.rows;

        graph.Reset(columns, rows);

        for (int i = 0; i < graph.length; i++)
        {
            int y = i / columns;
            int x = i % columns;

            if (y > 0 && adjMask[i] != adjMask[i - columns])
            {
                graph.AddAdjacent(i, adjMask[i - columns]);
            }

            if (x > 0 && adjMask[i] != adjMask[i - 1])
            {
                graph.AddAdjacent(i, adjMask[i - 1]);
            }

            if (x < columns - 1 && adjMask[i] != adjMask[i + 1])
            {
                graph.AddAdjacent(i, adjMask[i + 1]);
            }

            if (y < rows - 1 && adjMask[i] != adjMask[i + columns])
            {
                graph.AddAdjacent(i, adjMask[i + columns]);
            }
        }
    }
}