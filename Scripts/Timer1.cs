using UnityEngine;
using UnityEngine.UI;

public class Timer1 : MonoBehaviour {
    public Text TimeText;
    public float TimeStamp;
    public bool usingTimer;

    void Start() {
        usingTimer = true;
        SetTimer(25);
    }

    public void SetTimer(float time) {
        if (usingTimer) return;
        TimeStamp = Time.time + time;
    }

    public void SetUIText() {
        float timeLeft = TimeStamp - Time.time;
        if (timeLeft <= 0) {
            TimerFinished();
            return;
        }
        float hours;
        float minutes;
        float seconds;
        float millaseconds;
        GetTimeVariables(timeLeft, out hours, out minutes, out seconds, out millaseconds);
        if (hours > 0) {
            TimeText.text = string.Format("{0}:{1}", hours, minutes);
        } else if (minutes > 0) {
            TimeText.text = string.Format("{0}:{1}", minutes, seconds);
        } else {
            TimeText.text = string.Format("{0}:{1}", seconds, millaseconds);
        }
    }

    public void GetTimeVariables(float time, out float hours, out float minutes, out float seconds, out float millaseconds) {
        hours = (int)(time / 3600f);
        minutes = (int)((time - hours * 3600) / 60f);
        seconds = (int)(time - hours * 3600 - minutes * 60);
        millaseconds = (int)((time - hours * 3600 - minutes * 60 - seconds) * 100);
    }

    public void TimerFinished() {
        TimeText.text = "Game Over";
        TimeText.color = Color.red;
        usingTimer = false;
    }
}
