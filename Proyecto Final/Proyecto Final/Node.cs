using System.Collections.Generic;

public class Node
{
    public string Value;
    public List<Node> Children;

    public Node(string value)
    {
        Value = value;
        Children = new List<Node>();
    }
}