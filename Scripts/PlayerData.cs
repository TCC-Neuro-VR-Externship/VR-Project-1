using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour {
    public byte level;
    public int experiencePoints;

    public PlayerData(GameManager gameBoss) {
        level = gameBoss.level;
        experiencePoints = gameBoss.experiencePoints;
    }
}