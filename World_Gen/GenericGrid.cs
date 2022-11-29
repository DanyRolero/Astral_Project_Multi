public class Grid<T>
{
    public int length { get; protected set; }
    public int columns { get; protected set; }
    public int rows { get; protected set; }

    public T this[int index] => grid[index];

    public T this[int x, int y] => grid[(y * columns) + x];

    internal List<T> grid;

    /*-----------------------------------------------------*/
    public Grid(int columns = 2, int rows = 2)
    {
        length = columns * rows;
        this.columns = columns;
        this.rows = rows;

        grid = new List<T>(length);

        for (int i = 0; i < length; i++)
        {
            grid.Add(default(T));
        }

    }

    public Grid(T initialValue, int columns = 2, int rows = 2)
    {
        length = columns * rows;
        this.columns = columns;
        this.rows = rows;

        grid = new List<T>(length);

        for (int i = 0; i < length; i++)
        {
            grid.Add(initialValue);
        }
    }
    /*-----------------------------------------------------*/
    public void SetValue(int index, T value)
    {
        grid[index] = value;
    }

    public void SetValue(int x, int y, T value)
    {
        int index = (y * columns) + x;
        grid[index] = value;
    }

    /*-----------------------------------------------------*/
    public T GetValue(int index)
    {
        return grid[index];
    }

    public T GetValue(int x, int y)
    {
        int index = (y * columns) + x;
        return grid[index];
    }

    /*-----------------------------------------------------*/
    public bool HasAdjacent(int index, Direction adjacent)
    {
        int x = index % columns;
        int y = index / columns;

        if (adjacent == Direction.Up && y > 0) return true;
        if (adjacent == Direction.Right && x < columns - 1) return true;
        if (adjacent == Direction.Down && y < rows - 1) return true;
        if (adjacent == Direction.Left && x > 0) return true;

        return false;
    }

    public T GetAdjacent(int index, Direction adjacent) => adjacent switch
    {
        Direction.Up => grid[index - columns],
        Direction.Right => grid[index + 1],
        Direction.Down => grid[index + columns],
        Direction.Left => grid[index - 1],
        _ => throw new ArgumentOutOfRangeException(nameof(adjacent), $"Not expected direction value: {adjacent}"),
    };

    /*-----------------------------------------------------*/
    public override string ToString()
    {
        string str = "Grilla:\n";

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                str += GetValue(x, y).ToString() + " ";
            }
            str += "\n";
        }
        return str;
    }

    /*-----------------------------------------------------*/
    public void PrintUnityConsole()
    {
        //Debug.Log(ToString());
    }

    public void PrintOnConsole()
    {
        Console.WriteLine(ToString());
    }

    /*-----------------------------------------------------*/
    public void Build(Builder<T> builder)
    {
        builder.Build(this);
    }

    public void Reset(int columns, int rows)
    {
        length = columns * rows;
        this.columns = columns;
        this.rows = rows;

        grid = new List<T>(length);

        for (int i = 0; i < length; i++)
        {
            grid.Add(default(T));
        }
    }
}