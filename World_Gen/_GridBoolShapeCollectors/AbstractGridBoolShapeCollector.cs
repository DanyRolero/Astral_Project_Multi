public abstract class GridBoolShapeCollector
{
    public int units { get; internal set; }
    internal List<GridCreator<bool>> creators = new List<GridCreator<bool>>();

    public abstract List<GridCreator<bool>> Collect();
}