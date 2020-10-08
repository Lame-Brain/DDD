using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PCharacter
{
    public static PCharacter current;
    public string pcName, pcType, pcMotivation, pcStatus;
    public int index, str, dex, iq, wis, per, hlth, aura, face;
    public int HP, wounds, firstAid, MP, burnOut, enervate;
    public int gold, head, body, legs, arms, hand1, hand2, finger1, finger2, belt, boots;
    public bool magicSevered;
    public float magicResist;

    public PCharacter(string nam, string typ, string mot, int in1, int in2, int in3, int in4, int in5, int in6, int in7, int in8)
    {
        pcName = nam; pcType = typ; pcMotivation = mot;
        pcStatus = "Ready";
        str = in1;
        dex = in2;
        iq = in3;
        wis = in4;
        per = in5;
        hlth = in6;
        aura = in7;
        face = in8;
        int maxHP = 2, maxMP = 2;
        if (pcType == "Human") { maxHP = 8; maxMP = 8; }
        if (pcType == "Elf") { maxHP = 6; maxMP = 10; }
        if (pcType == "Dwarf") { maxHP = 10; maxMP = 4; }
        for (int i = 0; i < hlth; i++) HP += Random.Range(1, maxHP);
        for (int i = 0; i < aura; i++) MP += Random.Range(1, maxMP);
        wounds = 0; firstAid = 0;
        burnOut = 0; enervate = 0;
        gold = Random.Range(-5, 15); if (gold < 0) gold = 0;
        head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; //Start with up to 15 gold, traveller's hood, traveller's robe, and traveller's staff.
        magicSevered = false;
        if(pcType == "Dwarf") { magicResist = 25.0f; }
        else { magicResist = 0f; }
    }

    public int GetLevel()
    {
        int baseLevel = 0;
        if (pcType == "Human") baseLevel = 24;
        if (pcType == "Elf") baseLevel = 26;
        if (pcType == "Elf") baseLevel = 25;
        int levels = str + dex + iq + wis + per + hlth + aura - baseLevel;
        return levels;
    }

    public string GetHighestSkills()
    {
        bool strHighest = false, dexHighest = false, iqHighest = false, wisHighest = false, perHighest = false;
        int highestValue = 0;
        //First, find what the lowest stat value is.
        if (str > highestValue) highestValue = str;
        if (dex > highestValue) highestValue = dex;
        if (iq > highestValue) highestValue = iq;
        if (wis > highestValue) highestValue = wis;
        if (per > highestValue) highestValue = per;

        //Next, find out which stats are at the highest value
        if (str == highestValue) strHighest = true;
        if (dex == highestValue) dexHighest = true;
        if (iq == highestValue) iqHighest = true;
        if (wis == highestValue) wisHighest = true;
        if (per == highestValue) perHighest = true;

        //Next, how many are true? This will determine the terms of the return
        int howManyTrue = 0;
        if (strHighest) howManyTrue++;
        if (dexHighest) howManyTrue++;
        if (iqHighest) howManyTrue++;
        if (wisHighest) howManyTrue++;
        if (perHighest) howManyTrue++;

        //Finally, build the output string
        string output = "";
        bool done = false; int i = 0, max = howManyTrue - 1;
        if(howManyTrue > 1)
        {
            if (strHighest && !done) { output += "Strength"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (dexHighest && !done) { output += "Dexterity"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (iqHighest && !done) { output += "Intelligence"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (wisHighest && !done) { output += "Wisdom"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (perHighest && !done) { output += "Perception"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (howManyTrue == 2) output += " and ";
            if (howManyTrue > 2) output += "and ";
        }
        done = false;
        if (perHighest && !done) { output += "Perception"; done = true; }
        if (wisHighest && !done) { output += "Wisdom"; done = true; }
        if (iqHighest && !done) { output += "Intelligence"; done = true; }
        if (dexHighest && !done) { output += "Dexterity"; done = true; }
        if (strHighest && !done) { output += "Strength"; done = true; }

        Debug.Log(output);
        return output;
    }
}
