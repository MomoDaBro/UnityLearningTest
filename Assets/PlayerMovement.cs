using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody rb;

    public float forwardForce = 2000;
    public float sidewaysForce = 500;

    private bool canJump = false;
    private bool shouldJump = false;

    private void OnCollisionStay(Collision collisionInfo){
        if (collisionInfo.gameObject.layer == 8){
            canJump = true;
            
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && canJump){
            shouldJump = true;
            canJump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d")){
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")){
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("s")){
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (shouldJump){
            rb.AddForce(0, 1000, 0);
            shouldJump = false;
            canJump = false;
        }

        
    }
}