using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePhysics : MonoBehaviour {
  void Start() {
        // Simple line of Code, just drag this script to add physics to an object
        gameObject.AddComponent<Rigidbody>();
    }
}
