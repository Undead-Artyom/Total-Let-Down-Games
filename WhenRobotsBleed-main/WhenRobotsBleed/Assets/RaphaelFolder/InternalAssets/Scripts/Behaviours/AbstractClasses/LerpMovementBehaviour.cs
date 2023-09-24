using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LerpMovementBehaviour : MovementBehaviour
{

    protected GameObject _pointInSpacePrefab;
    protected GameObject _manager_PointsInSpace;
    protected List<GameObject> _pointsInSpace = new List<GameObject>();

    public List<GameObject> getPointsInSpace(){
        return _pointsInSpace;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
