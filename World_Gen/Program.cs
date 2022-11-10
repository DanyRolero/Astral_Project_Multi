int columns = 3;
int rows = 3;

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