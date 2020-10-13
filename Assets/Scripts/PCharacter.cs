using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PCharacter
{
    public string pcName, pcType, pcMotivation, pcStatus;
    public int str, dex, iq, wis, per, hlth, aura, face;
    public int HP, wounds, firstAid, MP, burnOut, enervate;
    public int baseLevel;
    public int gold, head, body, legs, arms, hand1, hand2, finger1, finger2, belt, boots, spellbook;
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
        gold = Random.Range(-5, 15); if (gold < 2) gold = 2;
        head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; spellbook = 0; //Start with up to 15 gold, traveller's hood, traveller's robe, and traveller's staff.
        magicSevered = false;
        if(pcType == "Dwarf") { magicResist = 25.0f; }
        else { magicResist = 0f; }
        baseLevel = str + dex + iq + wis + per + hlth + aura + -1;
    }

    public PCharacter(string nam, string typ, string mot, int faceN)
    {
        pcName = nam; pcType = typ; pcMotivation = mot;
        pcStatus = "Ready";
        face = faceN;
        int maxHP = 5, maxMP = 5;
        if(pcType == "Warrior") { hlth = 5; aura = 3; maxHP = 10; maxMP = 0; }
        if(pcType == "Mage") { hlth = 3; aura = 5; maxHP = 3; maxMP = 10; }
        if(pcType == "Rogue") { hlth = 4; aura = 3; maxHP = 7; maxMP = 3; }
        if (pcType != "Warrior" && pcType != "Mage" && pcType != "Rogue") { pcType = "Wanderer"; hlth = 6; aura = 6; maxHP = 8; maxMP = 8; }
        for (int i = 0; i < hlth; i++) HP += Random.Range(1, maxHP);
        for (int i = 0; i < aura; i++) MP += Random.Range(0, maxMP);
        if (pcType == "Warrior") str = Random.Range(4, 6); if (pcType == "Mage") str = Random.Range(3, 4); if (pcType == "Rogue") str = Random.Range(3, 4); if (pcType == "Wanderer") str = Random.Range(5, 10);
        if (pcType == "Warrior") dex = Random.Range(3, 5); if (pcType == "Mage") dex = Random.Range(3, 4); if (pcType == "Rogue") dex = Random.Range(4, 6); if (pcType == "Wanderer") dex = Random.Range(5, 10);
        if (pcType == "Warrior") iq = Random.Range(3, 3); if (pcType == "Mage") iq = Random.Range(5, 7); if (pcType == "Rogue") iq = Random.Range(3, 5); if (pcType == "Wanderer") iq = Random.Range(5, 10);
        if (pcType == "Warrior") wis = Random.Range(3, 3); if (pcType == "Mage") wis = Random.Range(3, 5); if (pcType == "Rogue") wis = Random.Range(3, 5); if (pcType == "Wanderer") wis = Random.Range(5, 10);
        if (pcType == "Warrior") per = Random.Range(3, 5); if (pcType == "Mage") per = Random.Range(3, 3); if (pcType == "Rogue") per = Random.Range(3, 5); if (pcType == "Wanderer") per = Random.Range(5, 10);
        wounds = 0; firstAid = 0;
        burnOut = 0; enervate = 0;
        gold = 0;
        if (pcType == "Wanderer") { head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; spellbook = 0; }
        if (pcType == "Warrior") { head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; spellbook = 0; }
        if (pcType == "Mage") { head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; spellbook = 0; }
        if (pcType == "Rogue") { head = 1; body = 1; legs = 0; arms = 0; hand1 = 1; hand2 = 0; finger1 = 0; finger2 = 0; belt = 0; boots = 0; spellbook = 0; }
        magicSevered = false; magicResist = 0f;
        baseLevel = str + dex + iq + wis + per + hlth + aura + -1;
    }

    public int GetLevel()
    {
        int levels = str + dex + iq + wis + per + hlth + aura - baseLevel;
        return levels;
    }

    public string GetHighestSkills()
    {
        bool strHighest = false, dexHighest = false, iqHighest = false, wisHighest = false, perHighest = false, hlthHighest = false, auraHighest = false;
        int highestValue = 0;
        //First, find what the lowest stat value is.
        if (str > highestValue) highestValue = str;
        if (dex > highestValue) highestValue = dex;
        if (iq > highestValue) highestValue = iq;
        if (wis > highestValue) highestValue = wis;
        if (per > highestValue) highestValue = per;
        if (hlth > highestValue) highestValue = hlth;
        if (aura > highestValue) highestValue = aura;

        //Next, find out which stats are at the highest value
        if (str == highestValue) strHighest = true;
        if (dex == highestValue) dexHighest = true;
        if (iq == highestValue) iqHighest = true;
        if (wis == highestValue) wisHighest = true;
        if (per == highestValue) perHighest = true;
        if (hlth == highestValue) hlthHighest = true;
        if (aura == highestValue) auraHighest = true;

        //Next, how many are true? This will determine the terms of the return
        int howManyTrue = 0;
        if (strHighest) howManyTrue++;
        if (dexHighest) howManyTrue++;
        if (iqHighest) howManyTrue++;
        if (wisHighest) howManyTrue++;
        if (perHighest) howManyTrue++;
        if (hlthHighest) howManyTrue++;
        if (auraHighest) howManyTrue++;

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
            if (hlthHighest && !done) { output += "Health"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (auraHighest && !done) { output += "Aura"; if (howManyTrue > 2) output += ", "; i++; if (i == max) done = true; }
            if (howManyTrue == 2) output += " and ";
            if (howManyTrue > 2) output += "and ";
        }
        done = false;
        if (auraHighest && !done) { output += "Aura"; done = true; }
        if (hlthHighest && !done) { output += "Health"; done = true; }
        if (perHighest && !done) { output += "Perception"; done = true; }
        if (wisHighest && !done) { output += "Wisdom"; done = true; }
        if (iqHighest && !done) { output += "Intelligence"; done = true; }
        if (dexHighest && !done) { output += "Dexterity"; done = true; }
        if (strHighest && !done) { output += "Strength"; done = true; }

        Debug.Log(output);
        return output;
    }
}
