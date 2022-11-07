Grid<int> grid = new Grid<int>(3, 3);
grid.Build(new RandomRangeGridIntBuilder(1, 4));
GridGraph graph = new GridGraph(3,3);
graph.Build(new OddEvenConnector(grid));
graph.Build(new ExtractUnconnectedSubgraphs());

Console.WriteLine(grid.ToString());
Console.WriteLine(graph.ToString());
