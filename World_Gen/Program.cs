int columns = 3;
int rows = 3;


//Grilla de enteros a partir de la cual se obtiene una adyacencia de un grafo de grilla
Grid<int> grid = new Grid<int>(columns, rows);
grid.Build(new RandomRangeGridIntBuilder(1, 2));
//grid.PrintOnConsole();

//Grid<int> grid = new RandomDistributionUnits(columns, rows, 0.4f).Create();
//grid.PrintOnConsole();

//Establecer adyacencia a partir de grilla de enteros donde coincida paridad e imparidad
GridGraph graph = new GridGraph(columns, rows);
graph.Build(new OddEvenConnector(grid));

//Establecer subgrafos a partir de conjuntos de nodos conexos
graph.Build(new ExtractUnconnectedSubgraphs());
//Console.WriteLine(graph.ToString());

//Console.WriteLine("Grilla de identificadores de subgrafos");
//Identificar subgrafos de grafo de grilla en orden de aparición en una grilla de enteros
grid.Build(new SubGraphsIdentifier(graph));
grid.PrintOnConsole();


//Establecer adyacencia de cada nodo con nodo de otro subgrafo
//graph.Build(new AdjacentsDesequalGridIntValuesConnector(grid));
//graph.PrintOnConsole();


//Console.WriteLine("Laberinto o grafo de arbol");
//Creamos un grafo en forma de grilla y lo buildeamos como laberinto (arbol)
GridGraph maze = new GridGraph(columns, rows);
maze.Build(new BinaryTree());
//maze.PrintOnConsole();

//Creamos un corredor de grafo de grilla y lo buildeamos para que recorra por prioridades
GridGraphRunner runner = new(maze);
runner.Build(new PriorityDirecction());
runner.PrintOnConsole();


graph.Build(new SubGraphWaysConnect(runner, grid));
graph.PrintOnConsole();

GridGraphRunner runner2 = new GridGraphRunner(graph, runner.path[0]);
runner2.Build(new PriorityDirecction());
runner2.PrintOnConsole();

