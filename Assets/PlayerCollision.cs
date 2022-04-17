using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    public PlayerMovement movement;
    
    private void OnCollisionEnter(Collision collisonInfo){
        

        if (collisonInfo.collider.CompareTag("Obstacle")){

            movement.enabled = false;

        }

    }
}
