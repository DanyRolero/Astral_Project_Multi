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

    public DistanceFromOrigin()
    {
    }

    public override void Build(Grid<int> grid)
    {
        throw new NotImplementedException();
    }
}


