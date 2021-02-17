using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public MapCreator _mapCreator;
    private Worm _mainWorm;
    public List<GameObject> _wormBody;

    void Start()
    {

        _mainWorm = _mapCreator.MainWorm;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseInput();
        }

    }
    public void BodyInit(int bodyCount, List<Vector3> positions)
    {
        _wormBody = new List<GameObject>();
        for (int i=0; i<positions.Count;i++)
        {
            _wormBody.Add(Instantiate(Resources.Load<GameObject>("WormBody"),
                positions[i], new Quaternion())); 
        }
    }
    private void MouseInput()
    {
        Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8f);
        mouseInput = Camera.main.ScreenToWorldPoint(mouseInput);
        mouseInput -= transform.position;
        mouseInput.Normalize();
        FindClosestVector(mouseInput);
        //transform.position += FindClosestVector(mouseInput);
    }
    private void FindClosestVector(Vector3 mouseInput)
    {
        Vector3 closest = new Vector3();
        Vector3 diff = new Vector3();
        float distance = Mathf.Infinity;
        Direction dir = new Direction();

        for (int i = 0; i < MapCreator.PosistionByDirection.Positions.Count; i++)
        {
            diff = MapCreator.PosistionByDirection.Positions[i] - mouseInput;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                distance = curDistance;
                closest = MapCreator.PosistionByDirection.Positions[i];
                dir = Node.directions[i];
            }
        }
        if (_mainWorm.Move(_mapCreator.Game.Map, dir, _mainWorm.HeadIndex))
        {
            _mainWorm.Move(_mapCreator.Game.Map, dir, _mainWorm.HeadIndex, true);
            MoveAllBodies();
        }
        //return new Vector3();
    }
    private void MoveAllBodies()
    {
        transform.position = _mapCreator.nodePositions[_mainWorm.HeadIndex];//_mainWorm.HeadIndex
        for(int i = 0; i<_mainWorm.Nodes.Length-1;i++)
        {
            _wormBody[i].transform.position = _mapCreator.nodePositions[_mainWorm.Nodes[i]];
        }
       
    }
}
