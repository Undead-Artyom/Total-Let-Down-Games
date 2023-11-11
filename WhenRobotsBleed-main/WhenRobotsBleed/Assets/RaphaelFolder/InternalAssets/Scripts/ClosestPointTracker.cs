using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestPointTracker : MonoBehaviour
{
    [SerializeField]
    private float _circularLineOfSightRadius = 7f;
    [SerializeField]
    private string _objectTypeToTrack = "GrapplePoint";
    private CircleCollider2D _circleCollider2D;
    private Dictionary<string, GameObject> _dictionaryOfInRangePoints = new Dictionary<string, GameObject>();
    private Vector3 _defaultPointLocation = Vector3.zero;
    private Vector3 _closestPointLocation = new Vector3(0,0,0);
    private float _closestDistance = 0f;
    private string _closestPointName = "";
    private bool _closestPointInLineOfSight = false;
    private Color _closestPointInLineOfSightRay = new Color(0,1,0);
    private SpriteRenderer _closestPointSpriteRenderer;

    //Getters
    public bool closestPointInLineOfSight => _closestPointInLineOfSight;
    public float closestDistance => _closestDistance;
    public Vector3 closestPointLocation => _closestPointLocation;

    void Awake(){
        if(gameObject.GetComponent<CircleCollider2D>()==null){
            _circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
            _circleCollider2D.isTrigger = true;
            _circleCollider2D.radius = _circularLineOfSightRadius;
        }
    }
    void OnTriggerEnter2D(Collider2D currCollider){
        string currColliderGameObjectTag = currCollider.gameObject.tag;
        if(currColliderGameObjectTag != null){
            if(currCollider.CompareTag(_objectTypeToTrack))
            {
                AddGrapplePoint(
                    ref currCollider,
                    ref _closestPointName,
                    ref _closestDistance,
                    ref _closestPointLocation,
                    ref _closestPointSpriteRenderer,
                    ref _dictionaryOfInRangePoints
                );
            }
        }
    }
    void OnTriggerExit2D(Collider2D currCollider){
        string currColliderGameObjectTag = currCollider.gameObject.tag;
        if(currColliderGameObjectTag != null){
            if(currCollider.CompareTag(_objectTypeToTrack))
            {
                RemoveGrapplePoint(
                    ref currCollider,
                    ref _closestPointName,
                    ref _closestDistance,
                    ref _closestPointLocation,
                    ref _closestPointSpriteRenderer,
                    ref _dictionaryOfInRangePoints
                );
            }
        }
    }
    void Update()
    {
        UpdateClosestGrapplePoint(
            ref _closestPointName,
            ref _closestDistance,
            ref _closestPointLocation,
            ref _closestPointInLineOfSight,
            ref _closestPointSpriteRenderer,
            ref _dictionaryOfInRangePoints
        );
    }
    void OnDrawGizmos(){
        if(_closestPointLocation != Vector3.zero){
            if(_closestPointInLineOfSight == true){
                Debug.DrawRay(this.transform.position, _closestPointLocation-this.transform.position, _closestPointInLineOfSightRay, 0.01f, false);
            }
        }
    }
    private void AddGrapplePoint(
        ref Collider2D currCollider2D,
        ref string closestPointName,
        ref float closestDistance,
        ref Vector3 closestPointLocation,
        ref SpriteRenderer closestPointSpriteRenderer,
        ref Dictionary<string, GameObject> dictionaryOfPoints
    ) {
        SpriteRenderer spriteRenderer = currCollider2D.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        if(dictionaryOfPoints.Count == 0){
            closestPointName = currCollider2D.gameObject.name;
            closestPointLocation = currCollider2D.gameObject.transform.position;
            closestDistance = Vector3.Distance(this.gameObject.transform.position, closestPointLocation);
            closestPointSpriteRenderer = spriteRenderer;
        }
        dictionaryOfPoints.Add(currCollider2D.gameObject.name, currCollider2D.gameObject);
    }
    private void RemoveGrapplePoint(
        ref Collider2D currCollider2D,
        ref string closestPointName,
        ref float closestDistance,
        ref Vector3 closestPointLocation,
        ref SpriteRenderer closestPointSpriteRenderer,
        ref Dictionary<string, GameObject> dictionaryOfPoints
    ) {
        SpriteRenderer spriteRenderer = currCollider2D.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        if(dictionaryOfPoints.Count == 1){
            closestPointName = "";
            closestPointLocation = Vector3.zero;
            closestDistance = 0f;
            closestPointSpriteRenderer = null;
        }
        dictionaryOfPoints.Remove(currCollider2D.gameObject.name);
    }
    private void UpdateClosestGrapplePoint(
        ref string closestPointName,
        ref float closestDistance,
        ref Vector3 closestPointLocation,
        ref bool closestPointInLineOfSight,
        ref SpriteRenderer closestPointSpriteRenderer,
        ref Dictionary<string, GameObject> dictionaryOfPoints
    ) {
        if(dictionaryOfPoints.Count == 0){
        }
        else if(dictionaryOfPoints.Count == 1){
            foreach(KeyValuePair<string, GameObject> kV in dictionaryOfPoints){
                closestDistance = Vector3.Distance(this.gameObject.transform.position, kV.Value.gameObject.transform.position);
                RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestPointLocation-this.transform.position, closestDistance);
                if(hitArray[2].transform.gameObject.CompareTag(_objectTypeToTrack) || hitArray[1].transform.gameObject.CompareTag(_objectTypeToTrack)){
                    closestPointInLineOfSight = true;
                    closestPointSpriteRenderer.enabled = true;
                }
                else{
                    closestPointInLineOfSight = false;
                    closestPointSpriteRenderer.enabled = false;
                }
            }
        }
        else{
            foreach(KeyValuePair<string, GameObject> kV in dictionaryOfPoints){
                float currentDistance = Vector3.Distance(this.gameObject.transform.position, kV.Value.transform.position);
                if((currentDistance < closestDistance) && kV.Key != closestPointName)
                {
                    closestPointLocation = kV.Value.transform.position;
                    closestDistance = currentDistance;
                    closestPointName = kV.Key;
                    closestPointSpriteRenderer.enabled = false;
                    closestPointSpriteRenderer = kV.Value.gameObject.GetComponent<SpriteRenderer>();
                    RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestPointLocation-this.transform.position, closestDistance);
                    if(hitArray[2].transform.gameObject.CompareTag(_objectTypeToTrack)){
                        closestPointInLineOfSight = true;
                        closestPointSpriteRenderer.enabled = true;
                    }
                    else{
                        closestPointInLineOfSight = false;
                        closestPointSpriteRenderer.enabled = false;
                    }
                }
                else{
                    closestDistance = currentDistance;
                    RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestPointLocation-this.transform.position, closestDistance);
                    if(hitArray[2].transform.gameObject.CompareTag(_objectTypeToTrack)){
                        closestPointInLineOfSight = true;
                        closestPointSpriteRenderer.enabled = true;
                    }
                    else{
                        closestPointInLineOfSight = false;
                        closestPointSpriteRenderer.enabled = false;
                    }
                }
            }
        }
    }
}
