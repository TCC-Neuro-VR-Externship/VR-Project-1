using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRigidBody : MonoBehaviour {

    // This allows an object to shoot ammo (physics based) by pressing the space bar

    public GameObject PrefabShoot;

    private void FixedUpdate() {
        GameObject G = null;

        if (Input.GetKeyDown(KeyCode.Space)) G = Instantiate(PrefabShoot);
        if (G != null) {
            G.transform.position = transform.position;
            Rigidbody RB = G.GetComponent<Rigidbody>();
            RB.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
