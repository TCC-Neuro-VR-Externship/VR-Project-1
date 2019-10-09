using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float ballRotateSpeed = 75000f;
    
    private void FixedUpdate() {
        float ySpeed = Input.GetAxis("Horizontal");
        float xSpeed = Input.GetAxis("Vertical");

        Rigidbody body = GetComponent<Rigidbody>();
        body.AddTorque(new Vector3(xSpeed, 0, ySpeed) * ballRotateSpeed * Time.fixedDeltaTime);
    }
}
