using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateUI : MonoBehaviour {
    private int countDownStartValue = 60;
    public Text timerUI;

    private void Start() {
        CountDownTimer();
    }

    void CountDownTimer() {
        if(countDownStartValue > 0) {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer: " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownStartValue--;
            Invoke("CountDownTimer", 1.0f);
        } else {
            timerUI.text = "Game Over";
            SceneManager.LoadScene(5);
        }
    }
}
