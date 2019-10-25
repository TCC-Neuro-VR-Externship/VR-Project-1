using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;

    // static makes the instance accessible from anywhere
    public static T Instance {
        get {
            // Check if the instance is null
            if (_instance == null) {
                // First try to find the object already on the scene
                _instance = FindObjectOfType<T>();
                if (_instance == null) {
                    // Coudn't find the singleton in the game, so create it
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake () {
        if(_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
