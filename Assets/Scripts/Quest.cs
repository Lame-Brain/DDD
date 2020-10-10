using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string Name;
    public int objective, currentObjective;
    public string[] objectiveDescription;
    public bool[] completedObjective;
}
