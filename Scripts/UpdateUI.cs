using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {
    [SerializeField] private Text timerLabel;
    private string timeFormatter(float timeInSeconds) {
        // Convert the time into Minutes and Seconds
        return string.Format("{0}:{1.00}",
            Mathf.FloorToInt(timeInSeconds / 60),
            Mathf.FloorToInt(timeInSeconds % 60));
    }

    private void Update() {
        timerLabel.text = timeFormatter(GameManager.instance.TimeRemaining);
    }
}
