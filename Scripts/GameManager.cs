using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager will extend from Singleton class, replace T with GameManager
public class GameManager : Singleton<GameManager> {
    private float _timeRemaining;
    public float TimeRemaining {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }
    }
    private float _maxTime = 5 * 60; // In seconds (this is 5 minutes)

    private void Start() {
        TimeRemaining = _maxTime;
    }
    private void Update() {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining <= 0) {
            // This will restart the game
            SceneManager.LoadScene("GameOver");
            TimeRemaining = _maxTime;
        }
    }
}
