using UnityEngine;

public class ShooterRigidBody : MonoBehaviour {
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
