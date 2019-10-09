using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    private Transform RotationTransformation;
    public float rotSpeed = 45f;

    private void Awake() {
        RotationTransformation = GetComponent<Transform>();
    }

    private void Update() {
        RotationTransformation.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;

        GameObject[] Coins = GameObject.FindGameObjectsWithTag("Coin");
        
        Destroy(gameObject);
        if (Coins.Length -1 <= 0) {
            print("No more coins to pick up");
        }
    }
}