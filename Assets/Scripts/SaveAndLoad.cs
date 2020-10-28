using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad
{
    public static List<SaveGame> savedGames = new List<SaveGame>();

    public static void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/saves.ddd"))
        {
            savedGames.Clear();
            Load();
        }
        if (SaveGame.current.index == -1) //if this is a brand new savegame, assign last index
        {
            if(savedGames.Count == 0) SaveGame.current.index = 0;
            if (savedGames.Count > 0) SaveGame.current.index = savedGames[savedGames.Count - 1].index + 1;
            Debug.Log("Assigning this game index: " + SaveGame.current.index);
            savedGames.Add(SaveGame.current);
        }
        else //... otherwise, save over previous slot
        {
            savedGames[SaveGame.current.index] = SaveGame.current;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.ddd");
        bf.Serialize(file, SaveAndLoad.savedGames);
        file.Close();
    }

    public static void UpdateSave()
    {
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

    public static void LoadDefaultRumorList()
    {
        if (File.Exists(Application.persistentDataPath + "/rumors.txt"))
        {
            StreamReader file = new StreamReader(Application.persistentDataPath + "/rumors.txt");
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                SaveGame.current.RUMORS.Add(line);
            }
            file.Close();
        }
        else { Debug.Log("WARNING! THERE ARE NO RUMORS IN THE PERSISTENT DATA PATH!"); }
    }
}
