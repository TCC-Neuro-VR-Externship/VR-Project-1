using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mathf.Clamp example.
//
// Animate a cube along the x-axis using a sine wave.
// Let the minimum and maximum positions on the x-axis
// be changed.  The cube will be visible inside the
// minimum and maximum values.

public class SPHERESINWAVE : MonoBehaviour {

    private float xMin = -1.0f, xMax = 1.0f;
    private float timeValue = 0.0f;

    void Update() {
        // Compute the sin position.
        float xValue = Mathf.Sin(timeValue * 5.0f);

        // Now compute the Clamp value.
        float xPos = Mathf.Clamp(xValue, xMin, xMax);

        // Update the position of the cube.
        transform.position = new Vector3(xPos, 0.0f, 0.0f);

        // Increase animation time.
        timeValue += Time.deltaTime;

        // Reset the animation time if it is greater than the planned time.
        if (xValue > Mathf.PI * 2.0f) {
            timeValue = 0.0f;
        }
    }

    void OnGUI() {
        // Let the minimum and maximum values be changed
        xMin = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), xMin, -1.0f, +1.0f);
        xMax = GUI.HorizontalSlider(new Rect(25, 60, 100, 30), xMax, -1.0f, +1.0f);

        // xMin is kept less-than or equal to xMax.
        if (xMin > xMax) {
            xMin = xMax;
        }

        // Display the xMin and xMax value with better size labels.
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;

        GUI.Label(new Rect(135, 10, 150, 30), "xMin: " + xMin.ToString("f2"), fontSize);
        GUI.Label(new Rect(135, 45, 150, 30), "xMax: " + xMax.ToString("f2"), fontSize);
    }
}
