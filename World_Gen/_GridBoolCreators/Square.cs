public class Square : GridCreator<bool>
{
    public int side { get; internal set; }
    const int MIN_SIDE = 1;

    public Square (int side)
    {
        if (side < MIN_SIDE) side = MIN_SIDE;
        this.side = side;
    }

    public override Grid<bool> Create()
    {
        Grid<bool> grid = new Grid<bool>(true, side, side);
        return grid;
    }
}