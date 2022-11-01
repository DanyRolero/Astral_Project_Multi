public class RandomRangeGridIntBuilder : Builder<int>
{
    public int min;
    public int max;

    public RandomRangeGridIntBuilder(int min = 0, int max = 1)
    {
        this.min = min;
        this.max = max;
    }


    public override void Build(Grid<int> grid)
    {
        Random random;
        for (int i = 0; i < grid.length; i++)
        {
            random = new Random();
            grid.SetValue(i, random.Next(min,max+1));
        }
    }
}