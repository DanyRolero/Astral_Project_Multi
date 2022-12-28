public class AdjacentsRain : GridCreator<bool>
{
    Grid<bool> grid;
    readonly int columns;
    readonly int rows;
    readonly int amountUnits;
    int remainingCells;
    int randomCell;

    public AdjacentsRain(int columns, int rows, int amountUnits)
    {
        this.grid = new Grid<bool>(columns, rows);
        this.columns = columns;
        this.rows = rows;
        this.amountUnits = amountUnits;
        this.remainingCells = amountUnits;
    }
    public override Grid<bool> Create()
    {
        randomCell = AstralRandom.IntRange(0, grid.length - 1);
        grid.SetValue(randomCell, true);
        remainingCells--;

        while (remainingCells > 0)
        {
            Console.WriteLine(randomCell);
            GenRandomCell();
            if (CheckAdjacent(Direction.Up) || CheckAdjacent(Direction.Down) ||
                CheckAdjacent(Direction.Left) || CheckAdjacent(Direction.Right))
            {
                Activate();
                continue;
            }
        }
        return grid;
    }

    private void GenRandomCell()
    {
        randomCell = AstralRandom.IntRange(0, grid.length - 1);
        if (grid[randomCell]) GenRandomCell();
    }

    private bool CheckAdjacent(Direction direction)
    {
        if (!grid.HasAdjacent(randomCell, direction)) return false;
        if (!grid.GetAdjacent(randomCell, direction)) return false;
        return true;
    }

    private void Activate()
    {
        grid.SetValue(randomCell, true);
        remainingCells--;
    }
}