public class BinaryTree : GridGraphBuilder
{
    public float coinRatio
    {
        get { return coinRatio; }
        set
        {
            if (value < 0) coinRatio = 0;
            else if (value > 1) coinRatio = 1;
            else coinRatio = value;
        }
    }

    public Corner origin;

    public BinaryTree(float coinRatio = 0.5f, Corner origin = Corner.Left_Down)
    {
        this.coinRatio = coinRatio;
        this.origin = origin;
    }


    private bool FlipCoin()
    {
        Random random = new Random();
        return random.NextSingle() > coinRatio;    
    }

    public override void Build(GridGraph graph)
    {
        for (int i = 0; i < graph.length; i++)
        {
            int y = i / graph.columns;
            int x = i % graph.columns;
            bool result = FlipCoin();

            if (origin == Corner.Left_Down)
            {
                graph.AddAdjacent(i, i - graph.columns);
            }

            else if(origin == Corner.Left_Up)
            {

            }

            else if(origin == Corner.Right_Up)
            {

            }

            else if (origin == Corner.Right_Up)
            {

            }

            
        }
    }

}