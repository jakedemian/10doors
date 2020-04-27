using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager {
    private static string savePath =  Application.persistentDataPath + "/dontplay.ree";
    
    public static void Save(bool gracefulExit) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(savePath, FileMode.Create);
        
        SaveData data = new SaveData(gracefulExit);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void PostLoadSetGracefulExitFalse() {
        Save(false);
    }

    public static SaveData Load() {
        if (File.Exists(savePath)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            SaveData data = (SaveData) formatter.Deserialize(stream);
            stream.Close();
            
            return data;
        }
        else {
            Debug.LogError("Save file not found in " + savePath);
            return null;
        }
    }
}