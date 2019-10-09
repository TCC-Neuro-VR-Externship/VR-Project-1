using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    private Color k_oldColor = Color.yellow;
    private Color k_newColor = Color.blue;
    public GameObject launchPad;
    public GameObject trigger;

    private void Start() {
        Renderer render = GetComponent<Renderer>();
        render.material.color = k_oldColor;
        launchPad.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        Renderer render = GetComponent<Renderer>();
        k_oldColor = render.material.color;
        render.material.color = k_newColor;
        launchPad.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        Renderer render = GetComponent<Renderer>();
        render.material.color = k_oldColor;
        trigger.SetActive(false);
    }
}
