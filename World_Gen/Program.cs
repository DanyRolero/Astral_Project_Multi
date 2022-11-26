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

//Creamos un grafo en forma de grilla y lo buildeamos como laberinto (arbol)
GridGraph maze = new GridGraph(columns, rows);
maze.Build(new BinaryTree());
Console.WriteLine(maze.ToString());

//Creamos un corredor de grafo de grilla y lo buildeamos para que recorra por prioridades
GridGraphRunner runner = new(maze);
runner.Build(new PriorityDirecction());
Console.WriteLine(runner.ToString());



