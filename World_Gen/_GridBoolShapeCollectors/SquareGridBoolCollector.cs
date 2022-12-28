public class SquareGridBoolShape : GridBoolShapeCollector
{
    public SquareGridBoolShape(int units)
    {
        this.units = units;
    }

    public override List<GridCreator<bool>> Collect()
    {
        int intSquareRoot = (int)Math.Sqrt(units);

        creators.Clear();
        creators = new List<GridCreator<bool>>();

        if (intSquareRoot * intSquareRoot == units)
        {
            creators.Add(new Square(intSquareRoot));
        }

        else
        {
            creators.Add(new Square(intSquareRoot + 1));
        }

        return creators;
    }
}