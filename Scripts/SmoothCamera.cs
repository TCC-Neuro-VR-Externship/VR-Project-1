using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {
    public Transform target;
    //public float smoothSpeed = 100f;
    public Vector3 offset;

    /*
    private void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        //transform.LookAt(target);
    }
    */

    private void LateUpdate() {
        transform.position = target.position + offset;
    }
}
