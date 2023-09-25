using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BetweenPointsInSpace_MovementBehaviour : MovementBehaviour
{
    protected GameObject _pointInSpacePrefab;
    protected GameObject _manager_PointsInSpace;
    protected List<GameObject> _pointsInSpace = new List<GameObject>();

    public List<GameObject> getPointsInSpace(){
        return _pointsInSpace;
    }
}
