//Crea una grilla booleana con una determinada cantidad de celdas activas
public class RandomAdjacentsCells1 : GridCreator<bool>
{
    Grid<bool> grid;

    public int cellsToActivate;
    public int columns;
    public int rows;

    int initialCell;
    int remainingCells;

    int currentCell;
    int currentAdjacent;
    int randomPosition;

    List<int> possibleAdjacents = new List<int>();
    List<int> stack = new List<int>();


    public RandomAdjacentsCells1(int columns, int rows, int cellsToActivate)
    {
        this.grid = new Grid<bool>();
        this.columns = columns;
        this.rows = rows;
        this.cellsToActivate = cellsToActivate;
        this.remainingCells = cellsToActivate;
    }

    public override Grid<bool> Create()
    {
        this.grid = new Grid<bool>(columns, rows);
        initialCell = AstralRandom.IntRange(0, grid.length - 1);
        grid.SetValue(initialCell, true);
        stack.Add(initialCell);
        remainingCells--;

        while (remainingCells > 0)
        {
            possibleAdjacents.Clear();

            randomPosition = AstralRandom.IntRange(0, stack.Count - 1);
            currentCell = stack[randomPosition];

            GetPossibleAdjacent(Direction.Up);
            GetPossibleAdjacent(Direction.Down);
            GetPossibleAdjacent(Direction.Right);
            GetPossibleAdjacent(Direction.Left);

            if (possibleAdjacents.Count == 0)
            {
                stack.Remove(currentCell);
                continue;
            }

            if (possibleAdjacents.Count == 1)
            {
                currentAdjacent = possibleAdjacents[0];
            }

            if (possibleAdjacents.Count > 1)
            {
                randomPosition = AstralRandom.IntRange(0, possibleAdjacents.Count - 1);
                currentAdjacent = possibleAdjacents[randomPosition];
            }

            grid.SetValue(currentAdjacent, true);
            stack.Add(currentAdjacent);
            remainingCells--;
        }

        return grid;
    }

    private void GetPossibleAdjacent(Direction direction)
    {
        if (!grid.HasAdjacent(currentCell, direction)) return;
        if (grid.GetAdjacent(currentCell, direction)) return;
        possibleAdjacents.Add(grid.GetAdjecentPosition(currentCell, direction));
    }
}