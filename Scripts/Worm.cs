using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm
{
    public int[] Nodes { get; }
    public int HeadIndex { get; private set; }
    public int TailIndex => (HeadIndex - 1 + Nodes.Length) % Nodes.Length;
    public bool Main { get; }
    public Worm(int[] nodes, int headIndex, bool main = false)
    {
        Nodes = nodes;
        HeadIndex = headIndex;
        Main = main;
    }
        public bool Move(Graph g, Direction direction, int nodeIndex,bool canMove = false)
    {
        if (nodeIndex == HeadIndex)
        {
            int nextNodeIndex = g.Nodes[nodeIndex].GetNext(direction);
            if (nextNodeIndex == -1)
            {
                return false;
            }
            if(canMove)
            {
                for(int i = 0; i<Nodes.Length-1;i++)
                {
                    Nodes[i] = Nodes[i + 1];
                }
                HeadIndex = nextNodeIndex;
                Nodes[Nodes.Length-1] = HeadIndex;
            }
            
            //Nodes[TailIndex] = nextNodeIndex;
            //HeadIndex = TailIndex;
            return true;
        }
        else if (nodeIndex == Nodes[TailIndex])
        {
            int nextNodeIndex = g.Nodes[nodeIndex].GetNext(direction);
            if (nextNodeIndex == -1)
            {
                return false;
            }
            Nodes[HeadIndex] = nextNodeIndex;
            HeadIndex = (HeadIndex + 1) % Nodes.Length;
            return true;
        }
        else
        {
            return false;
        }
    }

}
