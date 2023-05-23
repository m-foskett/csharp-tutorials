using System;

public class Node
{
    public int Value { get; set; }

    public Node Left { get; set; }

    public Node Right { get; set; }

    public Node(int _value, Node _left, Node _right)
    {
        Value = _value;
        Left = _left;
        Right = _right;
    }
}

public class BinarySearchTree
{
    public static bool Contains(Node root, int searchValue)
    {
        Node current = root;
        // Check if the searchValue is equal to searchValue
        if (current.Value == searchValue)
        {
            // Found the searchValue in tree
            return true;
        }
        if (current.Value > searchValue)
        {
            // Check if the left node exists
            if (current.Left != null)
            {
                // Traverse down the left branch
                return Contains(current.Left, searchValue);
            }
            else
            {
                // Found end of tree
                return false;
            }
        }
        if (current.Value < searchValue)
        {
            // Check if the left node exists
            if (current.Right != null)
            {
                // Traverse down the right branch
                return Contains(current.Right, searchValue);
            }
            else
            {
                // Found end of tree
                return false;
            }
        }
        // Reached the bottom of tree
        return false;
    }

    public static void Main(string[] args)
    {
        Node n1 = new Node(1, null, null);
        Node n3 = new Node(3, null, null);
        Node n2 = new Node(2, n1, n3);

        Console.WriteLine(Contains(n2, 3));
    }
}