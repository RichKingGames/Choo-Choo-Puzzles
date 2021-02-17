using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool MakeLevel(int level, string fileName)
    {
        Game g = null;
        if (level == 2)
        {
            g = MakeLevel2();
        }
        if (g == null)
        {
            return false;
        }
        g.Write(fileName);
        return true;
    }
    private static Game MakeLevel2()
    {
        Node[] nodes = new Node[] {
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthEast, 1 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthWest, 0 }, { Direction.East, 2 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 1 }, { Direction.East, 3 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 2 }, { Direction.East, 4 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 3 }, { Direction.East, 5 }, { Direction.SouthWest, 28 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 4 }, { Direction.NorthEast, 6 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthWest, 5 }, { Direction.East, 7 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 6 }, { Direction.SouthEast, 8 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthWest, 7 }, { Direction.East, 9 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 8 }, { Direction.East, 10 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 9 }, { Direction.SouthEast, 11 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthWest, 10 }, { Direction.SouthWest, 12 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 11 }, { Direction.SouthWest, 13 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 12 }, { Direction.SouthWest, 14 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 13 }, { Direction.West, 15 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.East, 14 }, { Direction.SouthWest, 16 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 15 }, { Direction.SouthWest, 17 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 16 }, { Direction.West, 18 }, { Direction.East, 29 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.East, 17 }, { Direction.NorthWest, 19 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthEast, 18 }, { Direction.West, 20 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.East, 19 }, { Direction.SouthWest, 21 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 20 }, { Direction.West, 22 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.East, 21 }, { Direction.NorthWest, 23 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthEast, 22 }, { Direction.NorthWest, 24 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthEast, 23 }, { Direction.NorthEast, 25 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthWest, 24 }, { Direction.NorthEast, 26 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.SouthWest, 25 }, { Direction.East, 27 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 26 }, { Direction.NorthEast, 28 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.NorthEast, 4 }, { Direction.SouthWest, 27 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 17 }, { Direction.East, 30 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 29 }, { Direction.East, 31 } }),
                Node.Factory(new Dictionary<Direction, int>{ { Direction.West, 30 } })
            };
        Graph map = new Graph(nodes);
        Worm[] worms = new Worm[] {
                new Worm(new int[]{ 0, 1, 2, 3 },3, main: true),
                new Worm(new int[]{ 8, 9, 10 },10),
                new Worm(new int[]{ 11, 12, 13, 14 },14),
                new Worm(new int[]{ 15, 16, 17 },17),
                new Worm(new int[]{ 18, 19, 20, 21 },21),
                new Worm(new int[]{ 22, 23, 24 },24),
                new Worm(new int[]{ 25, 26, 27, 28 },28),
            };
        return new Game(map, worms);
    }

}
