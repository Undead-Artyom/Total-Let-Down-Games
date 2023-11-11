using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Test_CircularRadiusV7))]
public class Test_DashTowardsGrapplePoint : MonoBehaviour
{
    private Test_CircularRadiusV7 grappleTracker;
    private PlayerController playerController;
    void Awake(){

    }
    void Start()
    {
        grappleTracker = GetComponent<Test_CircularRadiusV7>();
    }
    void Update()
    {
        
    }
    /*
    private IEnumerator Grapple()
    {
        private bool hasGrapple = true;
        private bool canGrapple = false;
        private bool isGrappling;
        [SerializeField]
        private float grapplePower = 5f;
        [SerializeField]
        private float grappleTime = 0.5f;
        [SerializeField]
        private float grappleCD = 1f;

        grappleTime is determine by the distance between the player and the grapple point, right?

        rb.velocity = new Vector2(-speed + -dashingPower, 0f);
        rb.velocity = _closestGrapplePointLocation-this.transform.position;

        -------------------------------------------------

        canGrapple = false;
        isGrappling = true;

        //probably need to handle turning off dashing here too.
        canDash = false;
        isDashing = false;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.velocity = _closestGrapplePointLocation-this.transform.position;

        //need to change the velocity thing probably. not set in stone

        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isGrappling = false;
        canGrapple = true;

        //maybe something related to the cooldown here?


        if(isFacingRight == true){
            rb.velocity = _closestGrapplePointLocation-this.transform.position;

            //need to change the velocity thing probably. not set in stone

            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = originalGravity;
            isGrappling = false;
            canGrapple = true;

            //maybe something related to the cooldown here?
        }
        else{
            rb.velocity = _closestGrapplePointLocation-this.transform.position;

            //need to change the velocity thing probably. not set in stone

            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = originalGravity;
            isGrappling = false;
            canGrapple = true;

            //maybe something related to the cooldown here?
        }
    }
    */
    
}
