using System.Collections.Generic;

public class SubGraph
{
    public int length { get; protected set; }
    public List<int> idNodes { get; protected set; }
    public int this[int indexIdNode] => idNodes[indexIdNode];

    /*-----------------------------------------------------*/
    public SubGraph()
    {
        length = 0;
        idNodes = new List<int>();
    }

    /*-----------------------------------------------------*/
    public void AddIdNode(int id)
    {
        idNodes.Add(id);
        this.length = idNodes.Count;
    }

    public void AddListIdNodes(List<int> idNodesList)
    {
        idNodes.AddRange(idNodesList);
        length = idNodes.Count;
    }

    /*-----------------------------------------------------*/
}