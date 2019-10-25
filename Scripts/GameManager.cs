using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// GameManager will extend from Singleton class, replace T with GameManager
public class GameManager : Singleton<GameManager> {
    public Text TimerTextUI;
    public float TimeStamp;
    public bool usingTimer = false;
    public byte level;
    
    public int experiencePoints;
    private int _countDownStartValue = 5 * 60; // In seconds (this is 5 minutes)
    private int _countDownCurrentValue;
    private SceneChange sceneChange;

    public int SceneIndex { get { return SceneManager.GetActiveScene().buildIndex; } }

    private void Start() {
        usingTimer = SceneIndex == 3 || SceneIndex == 4 ? true : false;
        if (usingTimer) StartCoroutine(LevelTimer());
    }

    IEnumerator LevelTimer() {
        print(_countDownStartValue);
        if (_countDownStartValue > 0) {
            _countDownCurrentValue = CountDownTimer(_countDownStartValue);
            yield return new WaitForSeconds(1);
        } else {
            TimerTextUI.color = Color.red;
            TimerTextUI.text = "Game Over";
            yield return new WaitForSeconds(3);
            sceneChange.GameOverSceneChange();
        }
    }

    int CountDownTimer(int amountSeconds) {
        //print(amountSeconds + "HEY");
        TimeSpan spanTime = TimeSpan.FromSeconds(amountSeconds);
        TimerTextUI.text = "Time " + spanTime.Minutes + " : " + spanTime.Seconds;
        amountSeconds--;
        //print(amountSeconds);
        Invoke("CountDownTimer", 1.00f);
        _countDownStartValue = amountSeconds;
        //print(amountSeconds);
        return amountSeconds;
    }

    //void CountDownTimer() {
    //    if (_countDownStartValue > 0) {
    //        TimeSpan spanTime = TimeSpan.FromSeconds(_countDownStartValue);
    //        TimerTextUI.text = "Time " + spanTime.Minutes + " : " + spanTime.Seconds;
    //        _countDownStartValue--;
    //        Invoke("CountDownTimer", 1.00f);
    //    } else {
    //        TimerTextUI.color = Color.red;
    //        TimerTextUI.text = "Game Over";
    //    }
    //}

    public void SavePlayer() {
        SystemIO.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SystemIO.LoadPlayer();
        level = data.level;
        experiencePoints = data.experiencePoints;
    }
}
