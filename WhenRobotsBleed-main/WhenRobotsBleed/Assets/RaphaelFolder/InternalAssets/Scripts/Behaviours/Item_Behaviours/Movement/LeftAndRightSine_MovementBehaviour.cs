using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightSine_MovementBehaviour : LerpMovementBehaviour
{
    //private GameObject _pointInSpaceA;
    [SerializeField]
    private float _pointInSpaceA_Distance = 0.5f;

    //private GameObject _pointInSpaceB;
    [SerializeField]
    private float _pointInSpaceB_Distance = 0.5f;

    
    [Space(10)]
    [Header("Movement Control Values")]
    [SerializeField]
    private float _amplitudeOffset = 0.5f;
    [SerializeField]
    private float _amplitude = 0.5f;
    [SerializeField]
    private float _speed = 5f;

    void Awake()
    {
        _pointInSpacePrefab = Resources.Load("Prefabs/PointInSpace") as GameObject;
        _pointsInSpace.Insert(0, (GameObject)GameObject.Instantiate(_pointInSpacePrefab, new Vector3(transform.position.x+_pointInSpaceA_Distance, transform.position.y,transform.position.z), Quaternion.identity));
        _pointsInSpace.Insert(1, (GameObject)GameObject.Instantiate(_pointInSpacePrefab, new Vector3(transform.position.x-_pointInSpaceB_Distance, transform.position.y,transform.position.z), Quaternion.identity));
        //_pointInSpaceA = (GameObject)GameObject.Instantiate(_pointInSpacePrefab, new Vector3(transform.position.x, transform.position.y+_pointInSpaceA_Distance,transform.position.z), Quaternion.identity);
        //_pointInSpaceB = (GameObject)GameObject.Instantiate(_pointInSpacePrefab, new Vector3(transform.position.x, transform.position.y-_pointInSpaceB_Distance,transform.position.z), Quaternion.identity);
    }



    void OnEnable()
    {
        _manager_PointsInSpace = GameObject.Find("/Manager_PointsInSpace");
        _pointsInSpace[0].transform.parent = _manager_PointsInSpace.transform;
        _pointsInSpace[1].transform.parent = _manager_PointsInSpace.transform;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(_pointsInSpace[0].transform.position, _pointsInSpace[1].transform.position, Mathf.Sin(Time.time * _speed) * _amplitude + _amplitudeOffset);
    }
}
