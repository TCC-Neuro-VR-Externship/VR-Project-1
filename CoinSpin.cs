using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour {
    void Update() {
        // Adds spin to the coin
        // Coins are made by cylinders flattened out
        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
    }
}
