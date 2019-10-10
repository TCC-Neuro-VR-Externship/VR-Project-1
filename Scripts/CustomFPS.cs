using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFPS : MonoBehaviour {
    private Transform ThisTransform;
    public float moveSpeed = 100f;
    public float rotationSpeed = 90f;

    private void Awake() {
        ThisTransform = GetComponent<Transform>();
    }

    private void Update() {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        ThisTransform.Rotate(0f, rotationSpeed * Time.deltaTime * Horz, 0f);
        ThisTransform.position += ThisTransform.forward * moveSpeed * Time.deltaTime * Vert;
    }
}
