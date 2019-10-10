using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    void Start() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
