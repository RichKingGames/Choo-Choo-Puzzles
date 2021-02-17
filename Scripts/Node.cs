using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    NorthEast = 0,
    East = 1,
    SouthEast = 2,
    SouthWest = 3,
    West = 4,
    NorthWest = 5
}

public class Node
{
        public static readonly Direction[] directions = new Direction[] {
            Direction.NorthEast,
            Direction.East,
            Direction.SouthEast,
            Direction.SouthWest,
            Direction.West,
            Direction.NorthWest
        };
        public int[] Next { get; }
        public bool Final { get; }

        public Node(int[] next, bool final = false)
        {
            Next = next;
            Final = final;
        }

        public int GetNext(Direction direction)
        {
            return Next[(int)direction];
        }
        

        public static Node Factory(Dictionary<Direction, int> neighbors, bool final = false)
        {
            int[] next = new int[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                if (neighbors.ContainsKey(directions[i]))
                {
                    next[i] = neighbors[directions[i]];
                }
                else
                {
                    next[i] = -1;
                }
            }
            return new Node(next, final);
        }
    

}
