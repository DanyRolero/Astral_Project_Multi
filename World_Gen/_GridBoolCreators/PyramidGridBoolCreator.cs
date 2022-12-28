//Construye una matriz binaria con forma de pirámide
public class PyramidGridBoolBuilder : GridCreator<bool>
{
    public int widthStep;
    public int heightStep;
    public int totalFloors;
    private int rows;
    private int columns;


    /*-----------------------------------------------------*/
    public PyramidGridBoolBuilder(int columns = 2, int rows = 2, int widthStep = 1, int heightStep = 1, int totalFloors = 2)
    {
        this.widthStep = widthStep;
        this.heightStep = heightStep;
        this.totalFloors = totalFloors;

        this.rows = heightStep * totalFloors;
        this.columns = (widthStep * totalFloors) + widthStep * (totalFloors - 1);
    }

    /*-----------------------------------------------------*/
    public override Grid<bool> Create()
    {
        Grid<bool> grid = new Grid<bool>(columns, rows);

        int padding = 0;

        for (int y = 0; y < grid.rows; y++)
        {
            padding = (y / heightStep) * widthStep;
            for (int x = padding; x < grid.columns - padding; x++)
            {
                grid.SetValue(x, y, true);
            }
        }

        return grid;
    }

}