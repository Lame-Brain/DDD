using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static List<PCharacter> savedPCs = new List<PCharacter>();

    public static void Save()
    {
        savedPCs.Add(PCharacter.current);
        foreach (PCharacter toon in savedPCs) toon.index = savedPCs.IndexOf(toon);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.ddd");
        bf.Serialize(file, SaveLoad.savedPCs);
        file.Close();
    }

    public static void UpdateSave()
    {
        foreach (PCharacter toon in savedPCs) toon.index = savedPCs.IndexOf(toon);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.ddd");
        bf.Serialize(file, SaveLoad.savedPCs);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saves.ddd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saves.ddd", FileMode.Open);
            SaveLoad.savedPCs = (List<PCharacter>)bf.Deserialize(file);
            file.Close();
        }
    }
}
