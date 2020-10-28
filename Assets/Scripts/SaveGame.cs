using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    public static SaveGame current;
    public  List<PCharacter> GROUP = new List<PCharacter>();
    public  List<Quest> QUEST = new List<Quest>();
    public List<string> TAGS = new List<string>();
    public List<string> RUMORS = new List<string>();
    public List<PCharacter> NPCS = new List<PCharacter>();
    public int index;
}
