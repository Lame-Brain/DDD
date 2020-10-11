﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad
{
    public static List<SaveGame> savedGames = new List<SaveGame>();

    public static void Save()
    {
        savedGames.Add(SaveGame.current);
        foreach (SaveGame toon in savedGames) toon.index = savedGames.IndexOf(toon);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.ddd");
        bf.Serialize(file, SaveAndLoad.savedGames);
        file.Close();
    }

    public static void UpdateSave()
    {
        foreach (SaveGame toon in savedGames) toon.index = savedGames.IndexOf(toon);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.ddd");
        bf.Serialize(file, SaveAndLoad.savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saves.ddd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saves.ddd", FileMode.Open);
            SaveAndLoad.savedGames = (List<SaveGame>)bf.Deserialize(file);
            file.Close();
        }
    }
}