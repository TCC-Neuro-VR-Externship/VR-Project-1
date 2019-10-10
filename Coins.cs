using System.Collections;
using UnityEngine;

public class Coins : MonoBehaviour {
    // How fast the coins float up and down
    // In cycles (up and down) per second
    private float floatSpeed = 0.5f;
    private float movementDistance = 15f;
    private float rotSpeed = .25f;
    private float startingY;
    private bool isMovingUp = true;

    private void Start() {
        startingY = transform.position.y;

        // Gives each instance a different time to rotate
        transform.Rotate(transform.up, Random.Range(0f, 360f));
        StartCoroutine(Spin());
        StartCoroutine(Float());
    }

    public IEnumerator Spin() {
        while (true) {
            transform.Rotate(0f, 0f, 360 * rotSpeed * Time.deltaTime);
            yield return 0;
        }
    }

    public IEnumerator Float () {
        while(true) {
            float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;
            if (newY > startingY + movementDistance) {
                newY = startingY + movementDistance;
                isMovingUp = false;
            } else if (newY < startingY) {
                newY = startingY;
                isMovingUp = true;
            }
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return 0;
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        // If collider is not player, do nothing and return
        if (!other.CompareTag("Player")) return;

        // Array that will hold total number of coins in the level
        GameObject[] Coins = GameObject.FindGameObjectsWithTag("Coin");
        
        Destroy(gameObject);
        if (Coins.Length -1 <= 0) {
            print("No more coins to pick up");
            print("Or END OF GAME");
        }
    }
}
