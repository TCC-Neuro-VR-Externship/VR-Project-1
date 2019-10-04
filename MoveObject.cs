using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    // This is the speed of the object
    private float speed = .5f;

    // This is an instance of the Vector3 class
    // This isn't given a value, this is set later
    Vector3 objectPosition;

    void Update() {

        // GetKey works while the key is HELD down
        // GetKeyDown will work also, but shouldn't be used for movement

        // "this" refers to the object the script is given to
        if (Input.GetKey(KeyCode.LeftArrow)) {

            // Vector called position set to object own position
            objectPosition = this.transform.position;

            // x value set to speed minus
            objectPosition.x -= speed;

            // This sets objects position to the vector called position
            this.transform.position = objectPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            // You can also call it within the method but doing this may
            // use more resources
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            objectPosition = this.transform.position;
            objectPosition.z += speed;
            this.transform.position = objectPosition;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            objectPosition = this.transform.position;
            objectPosition.z -= speed;
            this.transform.position = objectPosition;
        }
    }
}
