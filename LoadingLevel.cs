using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour {
    private int index = 1;

    public void OnCollisionEnter(Collision collision) {
        print("Index: " + index);
        index += 1;

        /* If object is touched or collided with 4 times, the scene will change to another
        scene. Your scene(s) needs to be added to the build settings dialog box
        and you must type it in or put in the number of the scene given to you
        in the build settings dialog box.
        */
        if (index == 5) {
            //                                    This can be a number like (1) or a string ("")
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
        }
    }
}
