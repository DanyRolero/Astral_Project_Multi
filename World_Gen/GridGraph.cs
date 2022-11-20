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

    /*-----------------------------------------------------*/
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

    /*-----------------------------------------------------*/
    public bool HasAdjacent(int node, Direction adjacent) => adjacent switch
    {
        Direction.Up => nodes[node].adjacents.Contains(node - columns),
        Direction.Right => nodes[node].adjacents.Contains(node + 1),
        Direction.Down => nodes[node].adjacents.Contains(node + columns),
        Direction.Left => nodes[node].adjacents.Contains(node - 1),
        _ => throw new ArgumentOutOfRangeException(nameof(adjacent), $"Not expected direction value: {adjacent}"),
    };

    public int GetAdjacent(int node, Direction adjacent) => adjacent switch
    {
        Direction.Up => node - columns,
        Direction.Right => node + 1,
        Direction.Down => node + columns,
        Direction.Left => node - 1,
        _ => throw new ArgumentOutOfRangeException(nameof(adjacent), $"Not expected direction value: {adjacent}"),
    };
}