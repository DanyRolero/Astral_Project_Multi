using System.Collections.Generic;

public class Graph { 

    public int length { get; internal set; }
 
    public List<Node> nodes { get; protected set; }

    public List<SubGraph> subgraphs { get; protected set; }

    /*-----------------------------------------------------*/   
    public Graph(int amountNodes = 1)
    {
        length = amountNodes;
        nodes = new List<Node>();

        for (int i = 0; i < length; i++)
        {
            nodes.Add(new Node());
        }

        subgraphs = new List<SubGraph>();
    }

    /*-----------------------------------------------------*/
    public void Build(GraphBuilder builder)
    {
        builder.Build(this);
    }

    public void Reset(int amountNodes)
    {
        length = amountNodes;
        nodes.Clear();

        for (int i = 0; i < length; i++)
        {
            nodes.Add(new Node());
        }
    }

    /*-----------------------------------------------------*/
    public void AddAdjacent(int node, int adjacent)
    {
        nodes[node].adjacents.Add(adjacent);
    }

   /*-----------------------------------------------------*/
    public int GetAdjacent(int node, int adjacent)
    {
        return nodes[node].adjacents[adjacent];
    }

    public List<int> GetAllAdjacentsFromNode(int node)
    {
        return nodes[node].adjacents;
    }

    public bool CheckHasAdjacent(int node, int adjacent)
    {
        return nodes[node].adjacents.Contains(adjacent);
    }

    /*-----------------------------------------------------*/
    public override string ToString()
    {
        string str = "Lista de adyacencia:\n";

        for (int i = 0; i < length; i++)
        {
            str += i.ToString() + "-> ";
            for (int j = 0; j < nodes[i].adjacents.Count; j++)
            {
                str += nodes[i].adjacents[j].ToString() + ", ";
            }
            str += "\n";
        }

        return str;
    }

    public void PrintUnityConsole()
    {
        //Debug.Log(ToString());
    }

    /*-----------------------------------------------------*/
    public class Node
    {
        public List<int> adjacents = new List<int>();
    }
}