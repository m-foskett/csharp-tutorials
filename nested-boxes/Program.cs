using System;

public class NestedBox
{
    private readonly int _numberOfBoxes = 0;
    public int NumberOfBoxes
    {
        get
        {
            return _numberOfBoxes;
        }
    }
    public NestedBox(NestedBox _nestedBox)
    {
        _numberOfBoxes = _nestedBox._numberOfBoxes + 1;
    }
    public NestedBox()
    {

    }
    public static void Main(string[] args)
    {
        Console.WriteLine(new NestedBox(new NestedBox(new NestedBox(new NestedBox(new NestedBox())))).NumberOfBoxes);
    }
}
