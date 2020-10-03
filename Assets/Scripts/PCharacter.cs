using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PCharacter
{
    public static PCharacter current;
    public string pcName, pcType, pcMotivation;
    public int str, dex, iq, wis, per, hlth, aura;
    public int HP, wounds, firstAid, MP, burnOut, enervate;
    public int gold, head, body, legs, arms, hand1, hand2, finger1, finger2, belt, boots;
    public bool magicSevered;
    public float magicResist;

    public PCharacter(string nam, string typ, string mot, int in1, int in2, int in3, int in4, int in5, int in6, int in7)
    {
        pcName = nam; pcType = typ; pcMotivation = mot;
        str = in1;
        dex = in2;
        iq = in3;
        wis = in4;
        per = in5;
        hlth = in6;
        aura = in7;
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
}
