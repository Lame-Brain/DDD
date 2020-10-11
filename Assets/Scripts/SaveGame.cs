using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    public static SaveGame current;
    public static List<PCharacter> GROUP;
    public static List<Quest> QUEST;
    public static bool thelmoreBank, thelmoreBarracks, thelmoreInn, thelmoreRoad, thelmoreSmith, thelmoreTavern, thelmoreTemple, thelmoreToolShop, thelmoreTownHall, thelmoreVoncar, thelmoreWell;
    public int index;

    public void StartSaveGame()
    {
        
    }
}
