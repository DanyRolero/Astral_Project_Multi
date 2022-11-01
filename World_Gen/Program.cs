Grid<int> grid = new Grid<int>(3, 3);
grid.Build(new RandomRangeGridIntBuilder(1, 4));

Console.WriteLine(grid.ToString());