using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CircularRadiusV4 : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;
    private Dictionary<string, GameObject> _dictionaryOfInRangeGrapplePoints = new Dictionary<string, GameObject>();
    private Vector3 _defaultGrapplePointLocation = Vector3.zero;
    private Vector3 _closestGrapplePointLocation = new Vector3(0,0,0);
    private float _closestGrappleDistance = 0f;
    private string _closestGrapplePointName = "";
    private bool _closestGrapplePointInLineOfSight = false;
    private SpriteRenderer _closestGrapplePointSpriteRenderer;
    private Animator _closestGrapplePointAnimator;
    private Color _nonClosestGrapplePointColor = new Color(1,0,0);
    private Color _closestGrapplePointColor = new Color(0,0,1);
    private Color _closestGrapplePointInLineOfSightRay = new Color(0,1,0);
    private Color _closestGrapplePointNotInLineOfSightColor = new Color(1,0,1,0.5f);
    void Awake(){
        if(gameObject.GetComponent<CircleCollider2D>()==null){
            _circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
            _circleCollider2D.isTrigger = true;
            _circleCollider2D.radius = 7f;
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "GrapplePoint")
        {
            AddGrapplePoint(
                ref collider,
                ref _closestGrapplePointName,
                ref _closestGrappleDistance,
                ref _closestGrapplePointLocation,
                ref _closestGrapplePointSpriteRenderer,
                ref _closestGrapplePointAnimator,
                ref _dictionaryOfInRangeGrapplePoints
            );
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "GrapplePoint")
        {
            RemoveGrapplePoint(
                ref collider,
                ref _closestGrapplePointName,
                ref _closestGrappleDistance,
                ref _closestGrapplePointLocation,
                ref _closestGrapplePointSpriteRenderer,
                ref _closestGrapplePointAnimator,
                ref _dictionaryOfInRangeGrapplePoints
            );
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClosestGrapplePoint(
            ref _closestGrapplePointName,
            ref _closestGrappleDistance,
            ref _closestGrapplePointLocation,
            ref _closestGrapplePointInLineOfSight,
            ref _closestGrapplePointSpriteRenderer,
            ref _closestGrapplePointAnimator,
            ref _nonClosestGrapplePointColor,
            ref _closestGrapplePointColor,
            ref _closestGrapplePointNotInLineOfSightColor,
            ref _dictionaryOfInRangeGrapplePoints
        );
    }
    void OnDrawGizmos(){
        if(_closestGrapplePointLocation != Vector3.zero){
            if(_closestGrapplePointInLineOfSight == true){
                Debug.DrawRay(this.transform.position, _closestGrapplePointLocation-this.transform.position, _closestGrapplePointInLineOfSightRay, 0.01f, false);
            }
            /*
            RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, _closestGrapplePointLocation-this.transform.position, float.PositiveInfinity);
            for(int i = 0; i < hitArray.Length; i++){
                Debug.Log(hitArray[i].transform.gameObject.name);
            }
            */
            
        }
    }
    private void AddGrapplePoint(
        ref Collider2D currCollider2D,
        ref string closestGrapplePointName,
        ref float closestGrappleDistance,
        ref Vector3 closestGrapplePointLocation,
        ref SpriteRenderer closestGrapplePointSpriteRenderer,
        ref Animator closestGrapplePointAnimator,
        ref Dictionary<string, GameObject> dictionaryOfGrapplePoints
    ) {
        Animator animator = currCollider2D.gameObject.GetComponent<Animator>();
        animator.enabled = false;
        SpriteRenderer spriteRenderer = currCollider2D.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        if(dictionaryOfGrapplePoints.Count == 0){
            closestGrapplePointName = currCollider2D.gameObject.name;
            closestGrapplePointLocation = currCollider2D.gameObject.transform.position;
            closestGrappleDistance = Vector3.Distance(this.gameObject.transform.position, closestGrapplePointLocation);
            closestGrapplePointSpriteRenderer = null;
            closestGrapplePointAnimator = animator;
        }
        dictionaryOfGrapplePoints.Add(currCollider2D.gameObject.name, currCollider2D.gameObject);
    }
    private void RemoveGrapplePoint(
        ref Collider2D currCollider2D,
        ref string closestGrapplePointName,
        ref float closestGrappleDistance,
        ref Vector3 closestGrapplePointLocation,
        ref SpriteRenderer closestGrapplePointSpriteRenderer,
        ref Animator closestGrapplePointAnimator,
        ref Dictionary<string, GameObject> dictionaryOfGrapplePoints
    ) {
        Animator animator = currCollider2D.gameObject.GetComponent<Animator>();
        animator.enabled = false;
        SpriteRenderer spriteRenderer = currCollider2D.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        if(dictionaryOfGrapplePoints.Count == 1){
            closestGrapplePointName = "";
            closestGrapplePointLocation = Vector3.zero;
            closestGrappleDistance = 0f;
            closestGrapplePointSpriteRenderer = null;
            closestGrapplePointAnimator = null;
        }
        dictionaryOfGrapplePoints.Remove(currCollider2D.gameObject.name);
    }
    private void UpdateClosestGrapplePoint(
        ref string closestGrapplePointName,
        ref float closestGrappleDistance,
        ref Vector3 closestGrapplePointLocation,
        ref bool closestGrapplePointInLineOfSight,
        ref SpriteRenderer closestGrapplePointSpriteRenderer,
        ref Animator closestGrapplePointAnimator,
        ref Color nonClosestGrapplePointColor,
        ref Color closestGrapplePointColor,
        ref Color closestGrapplePointNotInLineOfSightColor,
        ref Dictionary<string, GameObject> dictionaryOfGrapplePoints
    ) {
        if(dictionaryOfGrapplePoints.Count == 0){
        }
        else if(dictionaryOfGrapplePoints.Count == 1){
            foreach(KeyValuePair<string, GameObject> kV in dictionaryOfGrapplePoints){
                closestGrappleDistance = Vector3.Distance(this.gameObject.transform.position, kV.Value.gameObject.transform.position);
                RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestGrapplePointLocation-this.transform.position, closestGrappleDistance);
                if(hitArray[2].transform.gameObject.tag == "GrapplePoint" || hitArray[1].transform.gameObject.tag == "GrapplePoint"){
                    closestGrapplePointInLineOfSight = true;
                    closestGrapplePointSpriteRenderer.color = closestGrapplePointColor;
                }
                else{
                    closestGrapplePointInLineOfSight = false;
                    //closestGrapplePointSpriteRenderer.color = nonClosestGrapplePointColor;
                    closestGrapplePointSpriteRenderer.color = closestGrapplePointNotInLineOfSightColor;
                }
            }
        }
        else{
            foreach(KeyValuePair<string, GameObject> kV in dictionaryOfGrapplePoints){
                float currentGrappleDistance = Vector3.Distance(this.gameObject.transform.position, kV.Value.transform.position);
                if((currentGrappleDistance < closestGrappleDistance) && kV.Key != closestGrapplePointName)
                {
                    closestGrapplePointLocation = kV.Value.transform.position;
                    closestGrappleDistance = currentGrappleDistance;
                    closestGrapplePointName = kV.Key;
                    closestGrapplePointSpriteRenderer.color = nonClosestGrapplePointColor;
                    closestGrapplePointSpriteRenderer = kV.Value.gameObject.GetComponent<SpriteRenderer>();
                    RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestGrapplePointLocation-this.transform.position, closestGrappleDistance);
                    if(hitArray[2].transform.gameObject.tag == "GrapplePoint"){
                        closestGrapplePointInLineOfSight = true;
                        closestGrapplePointSpriteRenderer.color = closestGrapplePointColor;
                    }
                    else{
                        closestGrapplePointInLineOfSight = false;
                        //closestGrapplePointSpriteRenderer.color = nonClosestGrapplePointColor;
                        closestGrapplePointSpriteRenderer.color = closestGrapplePointNotInLineOfSightColor;
                    }
                    //closestGrapplePointSpriteRenderer.color = closestGrapplePointColor;
                }
                else{
                    closestGrappleDistance = currentGrappleDistance;
                    RaycastHit2D[] hitArray = Physics2D.RaycastAll(this.transform.position, closestGrapplePointLocation-this.transform.position, closestGrappleDistance);
                    if(hitArray[2].transform.gameObject.tag == "GrapplePoint"){
                        closestGrapplePointInLineOfSight = true;
                        closestGrapplePointSpriteRenderer.color = closestGrapplePointColor;
                    }
                    else{
                        closestGrapplePointInLineOfSight = false;
                        //closestGrapplePointSpriteRenderer.color = nonClosestGrapplePointColor;
                        closestGrapplePointSpriteRenderer.color = closestGrapplePointNotInLineOfSightColor;
                    }
                }
            }
        }
    }
}
