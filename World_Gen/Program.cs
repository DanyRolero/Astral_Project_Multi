int columns = 3;
int rows = 3;

/*
Grid<int> grid = new Grid<int>(columns, rows);
grid.Build(new RandomRangeGridIntBuilder(1, 4));
Console.WriteLine(grid.ToString());

GridGraph graph = new GridGraph(columns, rows);
graph.Build(new OddEvenConnector(grid));
graph.Build(new ExtractUnconnectedSubgraphs());
Console.WriteLine(graph.ToString());

grid.Build(new SubGraphsIdentifier(graph));
Console.WriteLine(grid.ToString());

graph.Build(new AdjacentsDesequalGridIntValuesConnector(grid));
Console.WriteLine(graph.ToString());
*/

//Creamos un grafo en forma de grilla
GridGraph maze = new GridGraph(columns, rows);

//Construimos el grafo como laberinto con ese algoritmo
maze.Build(new BinaryTree());
Console.WriteLine(maze.ToString());

//Matriz de enteros que representa el recorrido
Grid<int> mazePath = new Grid<int>(columns, rows);
PathMazePriorityDirection pathBuilder = new PathMazePriorityDirection(maze);
mazePath.Build(pathBuilder);
Console.WriteLine(mazePath.ToString());

for (int i = 0; i < pathBuilder.path.Length; i++)
{
    Console.WriteLine(pathBuilder.path[i].ToString() + " ");
}