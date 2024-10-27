using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (PlayerData playerData)
    {
        bool error = InputValidator(playerData);
        if (error) return;

        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.hello";
        if (File.Exists(path)) {
            File.Delete(path);
        }
        FileStream stream = new FileStream(path, FileMode.CreateNew);

        Debug.Log("Created player: \nPlayer name: " + playerData.playerName + "\nPlayer max hp: " + playerData.maxHp + "\nPlayer hp: " + playerData.hp + "\nPlayer movespeed" + playerData.moveSpeed);

        bf.Serialize(stream, playerData);
        stream.Close();
        Debug.Log("PLAYER SAVED");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.hello";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    static bool InputValidator(PlayerData playerData) {

        if (playerData.maxHp <= 0 || playerData.hp <= 0 || playerData.moveSpeed <= 0) {
            Debug.LogError("invalid values");
            return true;
        } else if (playerData.playerName.Length < 4) {
            Debug.LogError("name not long enough");
        }
        return false;
    }
}
