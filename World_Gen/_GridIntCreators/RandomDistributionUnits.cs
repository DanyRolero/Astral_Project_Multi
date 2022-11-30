public class RandomDistributionUnits : GridCreator<int>
{
    int acountUnitsForDistribute;
    int length;
    int currentCell;

    public float ratioUnits { get; protected set; }

    Grid<int> grid;

    public RandomDistributionUnits(int columns, int rows, float ratioUnits = 0.5f)
    {
        this.length = columns * rows;
        SetRatioUnits(ratioUnits);

        acountUnitsForDistribute = (int)(length * ratioUnits);

        grid = new Grid<int>(columns, rows);
    }

    public override Grid<int> Create()
    {
        while (acountUnitsForDistribute > 0)
        {
            RandomCell();
            grid.SetValue(currentCell, 1);
            acountUnitsForDistribute--;
        }


        return grid;
    }

    public void SetRatioUnits(float ratioUnits)
    {
        if (ratioUnits < 0) ratioUnits = 0;
        if (ratioUnits > 1) ratioUnits = 1;
        this.ratioUnits = ratioUnits;
    }

    private void RandomCell()
    {
        currentCell = AstralRandom.IntRange(0, length - 1);
        if (grid[currentCell] == 1) RandomCell();
    }
}