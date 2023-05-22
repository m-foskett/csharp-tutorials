using System;
using System.Collections.Generic;

public class TrainNode
{
    public TrainNode prev { get; set; }
    public TrainNode next { get; set; }
    public int value { get; set; }

    public TrainNode(int _value)
    {
        value = _value;
        prev = null;
        next = null;
    }
}

public class TrainComposition
{
    TrainNode leftHead { get; set; }
    TrainNode rightHead { get; set; }

    public void AttachWagonFromLeft(int wagonId)
    {
        TrainNode newLeftHead = new TrainNode(wagonId);
        // If not in the initial case where there are no train nodes yet
        if (leftHead != null)
        {
            leftHead.prev = newLeftHead;
            newLeftHead.next = leftHead;
            leftHead = newLeftHead;
        }
        else
        {
            // There are no train nodes yet
            leftHead = newLeftHead;
            rightHead = newLeftHead;
        }
    }

    public void AttachWagonFromRight(int wagonId)
    {
        TrainNode newRightHead = new TrainNode(wagonId);
        // If not in the initial case where there are no train nodes yet
        if (rightHead != null)
        {
            rightHead.next = newRightHead;
            newRightHead.prev = rightHead;
            rightHead = newRightHead;
        }
        else
        {
            // There are no train nodes yet
            leftHead = newRightHead;
            rightHead = newRightHead;
        }
    }

    public int DetachWagonFromLeft()
    {
        // If not in the initial case where there are no train nodes yet
        if (leftHead != null)
        {
            int val = leftHead.value;
            leftHead = leftHead.next;
            return val;
        }
        else
        {
            // No wagon to detach
            return 0;
        }
    }

    public int DetachWagonFromRight()
    {
        // If not in the initial case where there are no train nodes yet
        if (rightHead != null)
        {
            int val = rightHead.value;
            rightHead = rightHead.prev;
            return val;
        }
        else
        {
            // No wagon to detach
            return 0;
        }
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}