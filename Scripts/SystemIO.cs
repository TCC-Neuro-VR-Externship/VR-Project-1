using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SystemIO {
    public static void SavePlayer (GameManager gameBoss) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.eloc";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(gameBoss);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.eloc";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}