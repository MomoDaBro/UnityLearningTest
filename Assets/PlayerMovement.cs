using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody rb;
    public BoxCollider bc;


    public float forwardForce = 2000;
    public float sidewaysForce = 500;
    public float jumpVelocity = 20f;

    private bool canJump = false;
    private bool shouldJump = false;

    // onCollisionStay is functioning as it should - proved by debug log
    private void OnCollisionStay(Collision collisionInfo){
        if (collisionInfo.gameObject.name == "ground"){
            canJump = true;
        }
    }

    // something with update isn't functioning correctly
    // canJump works fine, the error is with this statement
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("you have pressed space");
            shouldJump = true;
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


        if (shouldJump && canJump){
            rb.velocity = Vector3.up * jumpVelocity;
            Debug.Log("you jumped");
        }

        shouldJump = false;
        canJump = false;
    }
}