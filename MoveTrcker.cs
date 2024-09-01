using System.Collections.Generic;
using System;

public class MoveTracker
{
    public Stack<Tuple<int, List<int>>> history { get; private set; }
    public Stack<Tuple<int, List<int>>> redoHistory { get; private set; }

    public MoveTracker()
    {
        history = new Stack<Tuple<int, List<int>>>();
        redoHistory = new Stack<Tuple<int, List<int>>>();
    }

    public void PushMove(int boardNum, List<int> move)
    {
        history.Push(new Tuple<int, List<int>>(boardNum, move));
        redoHistory.Clear(); // Clear redo history after a new move
    }

    public Tuple<int, List<int>> PopMove()
    {
        return history.Count > 0 ? history.Pop() : null;
    }

    public void PushRedo(int boardNum, List<int> move)
    {
        redoHistory.Push(new Tuple<int, List<int>>(boardNum, move));
    }

    public Tuple<int, List<int>> PopRedo()
    {
        return redoHistory.Count > 0 ? redoHistory.Pop() : null;
    }

    public bool HasHistory()
    {
        return history.Count > 0;
    }

    public bool HasRedoHistory()
    {
        return redoHistory.Count > 0;
    }
}
