public class PyramidGridBoolBuilder : Builder<bool>
{
    private int widthStep;
    private int heightStep;
    private int totalFloors;
    /*-----------------------------------------------------*/
    public PyramidGridBoolBuilder(int widthStep = 1, int heightStep = 1, int totalFloors = 2)
    {
        this.widthStep = widthStep;
        this.heightStep = heightStep;
        this.totalFloors = totalFloors;
    }

    /*-----------------------------------------------------*/
    public override void Build(Grid<bool> grid)
    {
        int rows = heightStep * totalFloors;
        int columns = (widthStep * totalFloors) + widthStep * (totalFloors - 1);

        grid.Reset(columns, rows);

        int padding = 0;

        for (int y = 0; y < grid.rows; y++)
        {
            padding = (y / heightStep) * widthStep;
            for (int x = padding; x < grid.columns - padding; x++)
            {
                grid.SetValue(x, y, true);
            }
        }   
    }
}