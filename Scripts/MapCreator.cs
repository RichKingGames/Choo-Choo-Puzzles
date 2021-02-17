using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MapCreator : MonoBehaviour
{
    public Game Game;
    public GameObject Sphere;
    public Vector3[] nodePositions;
    private HashSet<Tuple<int, int>> _edges = new HashSet<Tuple<int, int>>();
    public static PositionByDirection PosistionByDirection = new PositionByDirection();
    public Worm MainWorm;
    void Start()
    {
        //Utils.MakeLevel(2, Path.Combine(Application.persistentDataPath, "level2.json"));
        Game = Game.Read(Path.Combine(Application.persistentDataPath, "level2.json"));
        nodePositions = new Vector3[Game.Map.Nodes.Length];
        MapVisualize();
        SpawnWorms();
        
    }

    // Game g = Game.Read(Path.Combine("Levels", "level2.json"));
    public Worm FindMainWorm()
    {
        for (int i = 0; i < Game.Worms.Length; i++)
        {
            if (Game.Worms[i].Main == true)
            {
                return Game.Worms[i];
            }
        }
        return null;

    }
    public List<Vector3> GetWormBodyPositions(int[] nodes)
    { 
        List<int> bodyNodes = new List<int>();
        for (int i = 0; i < nodes.Length; i++)
        {
            bodyNodes.Add(nodes[i]);
        }
        List<Vector3> bodyPositions = new List<Vector3>();
        for(int i=0; i<bodyNodes.Count-1;i++)
        {
            bodyPositions.Add(nodePositions[bodyNodes[i]]);
        }
        return bodyPositions;
    }
    public void SpawnWorms()
    {
        MainWorm = FindMainWorm();
        GameObject mainWorm;
        mainWorm = Instantiate(Resources.Load("Worm") as GameObject, nodePositions[MainWorm.HeadIndex], new Quaternion());
        mainWorm.GetComponent<WormController>()._mapCreator = this.gameObject.GetComponent<MapCreator>();

        mainWorm.GetComponent<WormController>().BodyInit(MainWorm.Nodes.Length-2,
            GetWormBodyPositions(MainWorm.Nodes));

        //GameObject wormBody = Instantiate(Resources.Load("WormBody") as GameObject,
        //    new Vector3(mainWorm.transform.position.x, mainWorm.transform.position.y,
        //    mainWorm.transform.position.z), new Quaternion());
        //wormBody.transform.parent = mainWorm.transform;
       

    }

    public void MapVisualize()
    {
        
        for (int i = 0; i < Game.Map.Nodes.Length; i++)
        {
            for (int j = 0; j < Game.Map.Nodes[i].Next.Length; j++)
            {
                if (Game.Map.Nodes[i].Next[j] != -1)
                {
                    _edges.Add(new Tuple<int, int>(Math.Min(Game.Map.Nodes[i].Next[j], i), Math.Max(Game.Map.Nodes[i].Next[j], i)));
                }
            }
        }


        
        for (int i = 0; i < nodePositions.Length; i++)
        {
            //nodePositions[i] = null;
        }
        Recursive(new Vector3(), Game.Map.Nodes, 0, nodePositions);

        for(int i = 0; i<nodePositions.Length;i++)
        {
            Instantiate(Sphere, nodePositions[i], new Quaternion());
        }
    }

    
public static void Recursive(Vector3 position, Node[] nodes, int ind, Vector3[] nodePositions)
{
    nodePositions[ind] = position;
    for (int i = 0; i < nodes[ind].Next.Length; i++)
    {
        if (nodes[ind].Next[i] != -1 && nodePositions[nodes[ind].Next[i]] == new Vector3())
        {
            Recursive(new Vector3(position.x + PosistionByDirection.Positions[i].x,
                position.y + PosistionByDirection.Positions[i].y, 0.0f ), 
                nodes, nodes[ind].Next[i], nodePositions);
        }
    }
}

    //public void MapVisualize()
    //{
    //    Vector3 position = new Vector3();
    //    _occupiedPos.Add(new Vector3());
    //    Instantiate(Sphere, position, new Quaternion());

    //    PositionByDirection pos = new PositionByDirection();


    //    for (int i = 0; i < _game.Map.Nodes.Length - 1; i++)
    //    {
    //        position = GetNodePosition(pos, position, i);
    //        Instantiate(Sphere, position, new Quaternion());
    //    }
    //}
    public Vector3 GetNodePosition(PositionByDirection posByDir, Vector3 pos, int index)
    {
        for (int i = 0; i < Game.Map.Nodes[index].Next.Length; i++)
        {
            if (Game.Map.Nodes[index].Next[i] >= 0)
            {

                pos = pos + posByDir.Positions[i];

            }
        }
        return new Vector3();
    }
    //public bool IsOccupiedPosition(Vector3 position)
    //{

    //}
}


//    public GraphTest Map;

//    public GameObject Sphere;
//    void Start()
//    {
//        Map = new GraphTest();
//        Map.AddVertex(new Vector3(0.0f, 0.0f, 0.0f), 0);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -0.5f), 1);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -1.5f), 2);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -2.5f), 3);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -3.5f), 4);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -4.5f), 5);
//        Map.AddVertex(new Vector3(0.0f, 0.0f, -5.0f), 6);
//        Map.AddVertex(new Vector3(0.0f, 0.0f, -6.0f), 7);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -6.5f), 8);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -7.5f), 9);
//        Map.AddVertex(new Vector3(-1.0f, 0.0f, -8.5f), 10);
//        Map.AddVertex(new Vector3(-2.0f, 0.0f, -9.0f), 11);
//        Map.AddVertex(new Vector3(-3.0f, 0.0f, -8.5f), 12);
//        Map.AddVertex(new Vector3(-4.0f, 0.0f, -8.0f), 13);
//        Map.AddVertex(new Vector3(-5.0f, 0.0f, -7.5f), 14);
//        Map.AddVertex(new Vector3(-5.0f, 0.0f, -6.5f), 15);
//        Map.AddVertex(new Vector3(-6.0f, 0.0f, -6.0f), 16);
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -5.5f), 17);//near end point
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -4.5f), 18);
//        Map.AddVertex(new Vector3(-6.0f, 0.0f, -4.0f), 19);
//        Map.AddVertex(new Vector3(-6.0f, 0.0f, -3.0f), 20);
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -2.5f), 21);
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -1.5f), 22);
//        Map.AddVertex(new Vector3(-6.0f, 0.0f, -1.0f), 23);
//        Map.AddVertex(new Vector3(-5.0f, 0.0f, -0.5f), 24);
//        Map.AddVertex(new Vector3(-4.0f, 0.0f, -1.0f), 25);
//        Map.AddVertex(new Vector3(-3.0f, 0.0f, -1.5f), 26);
//        Map.AddVertex(new Vector3(-3.0f, 0.0f, -2.5f), 27);
//        Map.AddVertex(new Vector3(-2.0f, 0.0f, -3.0f), 28);// near 4 point
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -6.5f), 29);
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -7.5f), 30);
//        Map.AddVertex(new Vector3(-7.0f, 0.0f, -8.5f), 31);// Finish point

//        for (int i = 0; i < Map.Vertices.Count; i++)
//        {
//            Instantiate(Sphere, Map.Vertices[i].Position, new Quaternion());
//        }
//        Map.AddNearVertex(0, new List<int>() { 1 });
//        for (int i = 1; i < 17; i++)
//        {
//            Map.AddNearVertex(i, new List<int>() { i - 1, i + 1 });
//        }

//        Map.AddNearVertex(17, new List<int>() { 16, 18, 29 });

//        for (int i = 18; i < 28; i++)
//        {
//            Map.AddNearVertex(i, new List<int>() { i - 1, i + 1 });
//        }

//        Map.AddNearVertex(28, new List<int>() { 4, 27 });
//        Map.AddNearVertex(4, new List<int>() { 28 });
//        Map.AddNearVertex(29, new List<int>() { 30, 17 });
//        Map.AddNearVertex(30, new List<int>() { 29, 31 });


//        //Map.AddNearVertex(0, new List<int>() { 1 });
//        //Map.AddNearVertex(1, new List<int>() { 0, 2 });
//        //Map.AddNearVertex(2, new List<int>() { 1, 3 });
//        //Map.AddNearVertex(3, new List<int>() { 2, 4 });
//        //Map.AddNearVertex(4, new List<int>() { 3, 5, 28 });
//        //Map.AddNearVertex(5, new List<int>() { 4, 6 });

//    }
//}



//public class GraphVertex // вершины графа
//{
//    public int VertId;
//    public Vector3 Position;
//    public List<GraphVertex> NearVertex { get; }
//    public GraphVertex(Vector3 pos, int id)
//    {
//        VertId = id;
//        Position = pos;
//        NearVertex = new List<GraphVertex>();
//    }

//}
//public class GraphTest
//{
//    public List<GraphVertex> Vertices { get; }
//    public GraphTest()
//    {
//        Vertices = new List<GraphVertex>();
//    }
//    public void AddVertex(Vector3 pos, int id)
//    {
//        Vertices.Add(new GraphVertex(pos, id));
//    }
//    public void AddNearVertex(int id, List<int> nearId)
//    {
//        GraphVertex vert = FindVertex(id);
//        for (int i = 0; i < nearId.Count; i++)
//        {
//            GraphVertex nearVert = FindVertex(nearId[i]);
//            vert.NearVertex.Add(nearVert);
//        }
//    }
//    public void AddMainVertex(Vector3 pos, int id, List<int> nearId)
//    {
//        Vertices.Add(new GraphVertex(pos, id));
//        GraphVertex vert = FindVertex(id);
//        for (int i = 0; i < nearId.Count; i++)
//        {
//            GraphVertex nearVert = FindVertex(nearId[i]);
//            vert.NearVertex.Add(nearVert);
//        }

//    }
//    public List<GraphVertex> NearVertex(GraphVertex currentVert)
//    {
//        return currentVert.NearVertex;
//        //for(int i = 0; i<Vertices.Count; i++)
//        //{
//        //    if(Vertices[i] == currentVert)
//        //    {
//        //        return new List<GraphVertex>() {Ve }
//        //    }
//        //}
//        //return List<GraphVertex>;
//    }
//    public GraphVertex FindVertex(int id)
//    {
//        foreach (var v in Vertices)
//        {
//            if (v.VertId == id)
//            {
//                return v;
//            }
//        }

//        return null;
//    }
//}
