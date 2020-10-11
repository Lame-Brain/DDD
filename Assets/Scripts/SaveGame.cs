using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    public static SaveGame current;
    public  List<PCharacter> GROUP = new List<PCharacter>();
    public  List<Quest> QUEST = new List<Quest>();
    public  bool thelmoreBank, thelmoreBarracks, thelmoreInn, thelmoreRoad, thelmoreSmith, thelmoreTavern, thelmoreTemple, thelmoreToolShop, thelmoreTownHall, thelmoreVoncar, thelmoreWell;
    public int index;

    public void StartSaveGame()
    {
        
    }
}
