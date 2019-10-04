using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    /*  This is a color changer, however, you need to create a Materials folder
        Create in that folder a material, and add a color to that material.

        In Unity, when you click on the object you give the script to, there will
        be a place for you to input how many materials or colors you want to use.
        Drag materials in, and the "rend" will be the object that you also need to
        drag in. 
    */

    public Material[] materials;
    public Renderer rend;
    private int index = 1;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }


    // This allows you to click on the object given to the script to change colors
    private void OnMouseDown() {
        if (materials.Length == 0) return;
        if (Input.GetMouseButtonDown(0)) {
            index += 1;
            if (index == materials.Length + 1) index = 1;
        }
        rend.sharedMaterial = materials[index - 1];
    }

    // This will also change color based on collision
    public void OnCollisionEnter(Collision collision) {
        print("Index: " + index);
        if (materials.Length == 0) return;
        index += 1;
        if (index == materials.Length + 1) index = 1;
        rend.sharedMaterial = materials[index - 1];
    }
}
