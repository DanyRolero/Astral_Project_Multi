public class GridGraph : Graph
{
    public int columns { get; protected set;}
    public int rows { get; protected set; }

    /*-----------------------------------------------------*/
    public GridGraph(int columns = 2, int rows = 2) : base (columns * rows)
    {
        this.columns = columns;
        this.rows = rows;
    }

    public void Build(GridGraphBuilder builder)
    {
        builder.Build(this);
    }


    public void Reset(int columns, int rows)
    {
        this.columns = columns;
        this.rows = rows;
        base.Reset(columns * rows);
    }
}