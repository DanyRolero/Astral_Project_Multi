using System;

public class RandomActivatesFromAmountUnits : Builder<bool>
{
    int amountsUnits;
    int remainingUnit;
    int initialCell;

    int currentCell;
    int currentAdjacent;

    public Grid<bool> grid;

    int[] unitsDistributionBetweenColumns;

    List<int> stack = new List<int>();

    List<int> possibleDirection = new List<int>();

    public RandomActivatesFromAmountUnits(int amountsUnits)
    {
        this.amountsUnits = amountsUnits;
        this.grid = new Grid<bool>();
        this.unitsDistributionBetweenColumns = new int[grid.columns];
    }

    public override void Build(Grid<bool> grid)
    {
        this.grid = grid;

        Initialization();
        InitialDistributionUnits();
        RemainingDistributionUnits();
    }

    private void Initialization()
    {
        this.unitsDistributionBetweenColumns = new int[grid.columns];
        this.remainingUnit = amountsUnits - grid.columns;
        this.initialCell = AstralRandom.IntRange(0, grid.length - 1);

        grid.SetValue(initialCell, true);
        stack.Add(initialCell);
        currentCell = stack[stack.Count - 1];
    }

    private void InitialDistributionUnits()
    {
        for (int i = 0; i < unitsDistributionBetweenColumns.Length; i++)
        {
            unitsDistributionBetweenColumns[i] = 1;
        }
    }

    private void RemainingDistributionUnits()
    {
        for (int i = 0; i < remainingUnit; i++)
        {
            int randomColumn = AstralRandom.IntRange(0, grid.columns - 1);
            unitsDistributionBetweenColumns[randomColumn] += 1;
        }
    }

    private bool CheckPossibleDirection(Direction direction)
    {       
        bool hasAdjacent = grid.HasAdjacent(currentCell, direction);
        bool hasToDistribute = CheckHasUnitsOnColumn(direction);

        if (hasAdjacent && hasToDistribute)
        {
            if (!grid.HasAdjacent(currentCell, direction)) return true;
        }

        return false;
    }

    public bool CheckHasUnitsOnColumn(Direction direction) => direction switch
    {
        Direction.Up => unitsDistributionBetweenColumns[currentCell] > 0,
        Direction.Right => unitsDistributionBetweenColumns[currentCell + 1] > 0,
        Direction.Down => unitsDistributionBetweenColumns[currentCell] > 0,
        Direction.Left => unitsDistributionBetweenColumns[currentCell - 1] > 0,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
    };

}