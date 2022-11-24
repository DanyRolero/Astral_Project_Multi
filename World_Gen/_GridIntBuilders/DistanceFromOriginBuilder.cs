/*
- Clase constructora para matrices de números enteros.
- Construye una matriz de enteros que representa caminos en un laberinto
(grafo de tipo arbol con forma de grilla) donde cada valor representa la
distancia en nodos que hay desde ese nodo hasta el nodo de origen.

- Se requiere una matriz unidimensional que represente el orden en el que se ha
recorrido cada nodo del laberinto pasando por todos los nodos.
*/

public class DistanceFromOrigin : Builder<int>
{
    int[] path;

    public DistanceFromOrigin(int[] path)
    {
        this.path = path;
    }

    public override void Build(Grid<int> grid)
    {
        grid.Reset(grid.columns, grid.rows);
        int currentDistance = 0;

        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] == i)
            {
                grid.SetValue(i, i);
                continue;
            }

            int y = i / grid.columns;
            int x = i % grid.columns;

            if (y > 0 && grid[i - grid.columns] < i && grid[i - grid.columns] > currentDistance)
            {
                currentDistance = (i - grid.columns) + 1;
            } 
            if (x > 0 && grid[i - 1] < i && grid[i - 1] > currentDistance)
            {
                currentDistance = (i - grid.columns) + 1;
            }

          
           

        }
    }

    //Si la posición y el valor son iguales, la distancia desde origen coincide

    //Si no...
    //Necesito ver de los adjacentes cuales son inferiores y de los que son inferiores
    //cual es el más alto, el valor actual sería ese más la unidad.
}


