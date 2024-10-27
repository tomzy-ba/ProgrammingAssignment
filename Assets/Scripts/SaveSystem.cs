using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (PlayerData playerData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.hello";
        if (File.Exists(path)) {
            File.Delete(path);
        }
        FileStream stream = new FileStream(path, FileMode.CreateNew);

        PlayerData data = playerData;

        bf.Serialize(stream, data);
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
}
