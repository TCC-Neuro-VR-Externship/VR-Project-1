using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBounce : MonoBehaviour {
    public Rigidbody rb;
	private float forcePressure = 2000f;

    void Update() {
        rb.AddForce(0, forcePressure * Time.fixedDeltaTime, 0);
    }
}
