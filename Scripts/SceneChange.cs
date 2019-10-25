using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    private int SceneNumber { get { return SceneManager.GetActiveScene().buildIndex; } }
    
    private void OnTriggerEnter(Collider other) {
        print("COLLISION");
        switch (SceneNumber) {
            case 0: // Title Screen
                if (CompareTag("PlayButton")) {
                    print("Going to Space Scene");
                    SceneManager.LoadScene(SceneNumber + 2);
                } else if (CompareTag("Tutorial")) {
                    print("Go to Tutorial Scene");
                    SceneManager.LoadScene(SceneNumber + 1);
                }
                break;
            case 1: // Tutorial or OpenForTakeOff
                SceneManager.LoadScene(SceneNumber + 1);
                print("Scene Number " + SceneNumber + "Going to Scene " + SceneNumber + 1);
                break;
            case 2: // Space
                if (CompareTag("Planet")) {
                    print("Blue Planet Trigger");
                    SceneManager.LoadScene(SceneNumber + 1);
                } else if (CompareTag("Star")) {
                    print("Star Trigger");
                    SceneManager.LoadScene(SceneNumber + 2);
                }
                break;
            case 3: // Blue Planet
                SceneManager.LoadScene(SceneNumber + 2); // Go to Game Over
                break;
            case 4: // Star Level
                SceneManager.LoadScene(SceneNumber + 1); // Go to Game Over
                break;
            case 5: // GameOver Scene
                //SceneManager.LoadScene(0);
                break;
        }
    }

    // Used by the Start Screen buttons
    public void ButtonsPressed(int buttonPress) {
        if (buttonPress == 0) {
            print("Go to Tutorial Scene");
            SceneManager.LoadScene(SceneNumber + 1);
        } else if (buttonPress == 1) {
            print("Going to Space Scene");
            SceneManager.LoadScene(SceneNumber + 2);
        }
    }

    public void GameOverSceneChange() {
        SceneManager.LoadScene(5);
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
