public class RandomSizeFromAcountUnits : GridCreator<bool>
{
    public int amountsUnits { get; protected set; }
    public int columns { get; protected set; }
    public int rows { get; protected set; }

    int remainingUnits;

    int minRandomColumns;
    int maxRandomColums;

    int minRandomRows;
    int maxRandomRows;

    public int minColumns = 1;
    public int maxColumns;

    public int minRows = 1;
    public int maxRows;


    public RandomSizeFromAcountUnits(int amountsUnits)
    {
        this.amountsUnits = amountsUnits;
        this.minRandomColumns = 1;
        this.maxRandomColums = amountsUnits;

        this.maxColumns = amountsUnits;
        this.maxRows = amountsUnits;
    }

    public override Grid<bool> Create()
    {
        this.columns = AstralRandom.IntRange(minRandomColumns, maxRandomColums);
        this.remainingUnits = amountsUnits - columns;

        this.minRandomRows = amountsUnits / columns;
        if (amountsUnits % columns > 0) minRandomRows++;

        this.maxRandomRows = remainingUnits + 1;

        this.rows = AstralRandom.IntRange(minRandomRows, maxRandomRows);

        Console.WriteLine(columns);
        Console.WriteLine(rows);

        if (columns > maxColumns) columns = maxColumns;
        if (columns < minColumns) columns = minColumns;
        if (rows > maxRows) rows = maxRows;
        if (rows < minRows) rows = minRows;


        return new Grid<bool>(columns, rows);
    }
}