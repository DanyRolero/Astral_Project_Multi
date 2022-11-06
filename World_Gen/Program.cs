Grid<int> grid = new Grid<int>(4, 4);
grid.Build(new RandomRangeGridIntBuilder(1, 4));
OddEvenConnector builder = new OddEvenConnector(grid);
GridGraph graph = builder.Create();

Console.WriteLine(grid.ToString());
Console.WriteLine(graph.ToString());