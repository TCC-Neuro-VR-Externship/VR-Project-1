using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Transform ThisTransform;
    private CharacterController ThisController;
    private float moveSpeed = 100f;
    private float rotationSpeed = 100f;

    private void Awake() {
        ThisTransform = GetComponent<Transform>();
        ThisController = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        ThisTransform.Rotate(0f, rotationSpeed * Time.deltaTime * Horz, 0f);

        // Transform lets you reposition wherever you want
        // ThisTransform.position += ThisTransform.forward * moveSpeed * Time.deltaTime * Vert;

        // Simple Move already takes into account Time.delta and already uses a speed based system
        ThisController.SimpleMove(ThisTransform.forward * moveSpeed * Vert);
    }
}
