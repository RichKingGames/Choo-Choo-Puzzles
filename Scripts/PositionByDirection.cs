using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class PositionByDirection
{
    
    public List<Vector3> Positions;


    public PositionByDirection()
    {
        Positions = new List<Vector3>()
        {
            new Vector3(0.5f,1.0f,0.0f),
            new Vector3(1.0f,0.0f,0.0f),
            new Vector3(0.5f,-1.0f,0.0f),
            new Vector3(-0.5f,-1.0f,0.0f),
            new Vector3(-1.0f,0.0f,0.0f),
            new Vector3(-0.5f,1.0f,0.0f)
            
        };
        //new Vector3(1.0f, 0.0f, -0.5f),
        //new Vector3(0.0f, 0.0f, -1.0f),
        //new Vector3(-1.0f, 0.0f, -0.5f),
        //new Vector3(-1.0f, 0.0f, 0.5f),
        //new Vector3(0.0f, 0.0f, 1.0f),
        //new Vector3(1.0f, 0.0f, 0.5f)
        //-0.5  1.0

        //Positions.Add(new Vector3(1.0f, 0.0f, 0.5f));
        //Positions.Add(new Vector3(0.0f, 0.0f, 1.0f));
        //Positions.Add(new Vector3(-1.0f, 0.0f, 0.5f));
        //Positions.Add(new Vector3(-1.0f, 0.0f, -0.5f));
        //Positions.Add(new Vector3(0.0f, 0.0f, -1.0f));
        //Positions.Add(new Vector3(1.0f, 0.0f, -0.5f));
    }

}