using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreateManager : MonoBehaviour
{
    public GameObject FacePanel, buttonPF, FacePickerPanel, ErrorPanel;
    public GameObject[] FaceButton;
    public AudioSource ClickSFX;

    public Image DisplayFace;
    public Dropdown TypePicker, MotivationPicker;
    public Text InfoTextOutput, strTextOutput, dexTextOutput, iqTextOutput, wisTextOutput, perTextOutput, hlthTextOutput, auraTextOutput, extraTextOutput;

    public int face;

    private string pcName, pcType, pcMotivation;
    private int str, dex, iq, wis, per, hlth, aura, xtra;

    // Start is called before the first frame update
    void Start()
    {
        InitCharacterGen();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayFace.sprite = GameManager.GAME.pcFace[face];
        extraTextOutput.text = "Free Points: " + xtra.ToString();
        strTextOutput.text = "Strength Level " + str.ToString();
        dexTextOutput.text = "Dexterity Level " + dex.ToString();
        iqTextOutput.text = "Intelligence Level " + iq.ToString();
        wisTextOutput.text = "Wisdom Level " + wis.ToString();
        perTextOutput.text = "Perception Level " + per.ToString();
        hlthTextOutput.text = "Health Level " + hlth.ToString();
        auraTextOutput.text = "Aura Level " + aura.ToString();
    }

    public void InitCharacterGen()
    {
        pcName = "";
        pcType = "";
        pcMotivation = "";
        face = 0;
        str = 3;
        dex = 3;
        iq = 3;
        wis = 3;
        per = 3;
        hlth = 3;
        aura = 3;
        xtra = 0;

        FaceButton = new GameObject[GameManager.GAME.pcFace.Length];

        for (int i = 0; i < GameManager.GAME.pcFace.Length - 1; i++)
        {
            FaceButton[i] = Instantiate(buttonPF, FacePanel.transform);
            FaceButton[i].GetComponent<Image>().sprite = GameManager.GAME.pcFace[i];
            int x = i; // This fixes the Closure problem.
            FaceButton[i].GetComponent<Button>().onClick.AddListener(() => FacePickerFaceButtonCicked(x));
        }
    }
    public void FacePickerFaceButtonCicked(int num)
    {
        face = num;
        ClickSFX.GetComponent<AudioSource>().Play();
        FacePickerPanel.SetActive(false);
    }

    public void NameChanged(Text name)
    {
        pcName = name.text;
        
    }
    public void TypeChanged()
    {
        int value = TypePicker.value;
        Debug.Log("TYPE = " + value);
        if (value == 0)
        {
            TypePicker.value = 1;
            value = 1;
        }
        if (value == 1)
        {
            pcType = "Human";
            InfoTextOutput.text = "Humans are the most populous race on Atania. They start with a 3 in every stat level, but they can spend an additional 3 points that can be spent in any stat to represent their adaptability.";
            str = 3; dex = 3; iq = 3; wis = 3; per = 3; hlth = 3; aura = 3; xtra = 3;
        }
        if (value == 2)
        {
            pcType = "Elf";
            InfoTextOutput.text = "Elves are shorter than humans, but tend to be smarter and more flexible than the average human. They start with an additional 2 points in Dexterity and Intelligence to represent this. Elves are famously fastidious, and so will be required to spend more for Food, Rations, and Training.";
            str = 3; dex = 5; iq = 5; wis = 3; per = 3; hlth = 3; aura = 3; xtra = 1;
        }
        if (value == 3)
        {
            pcType = "Dwarf";
            InfoTextOutput.text = "Dwarves are hardy and strong. They start with an additional level in strength and perception. Dwarves have a natural immunity to magic, and may resist any magical effect applied to them, friendly or hostile.";
            str = 4; dex = 3; iq = 3; wis = 3; per = 4; hlth = 3; aura = 3; xtra = 2;
        }
    }
    public void MotivationChanged()
    {
        int value = MotivationPicker.value;
        Debug.Log("Motivation = " + value);
        if (value == 0)
        {
            MotivationPicker.value = 1;
            value = 1;
        }
        if (value == 1)
        {
            pcMotivation = "Money";
            InfoTextOutput.text = "Adventuring is a good way to amass fabulous amounts of treasure, unless you die.";
        }
        if (value == 2)
        {
            pcMotivation = "Power";
            InfoTextOutput.text = "Whether an adventurer seeks to empower themselves by overcoming challenges, or to find something that will lend them power, they may find it in the Deep.";
        }
        if (value == 3)
        {
            pcMotivation = "Honor";
            InfoTextOutput.text = "Many would rather not face the challenges that await. Some will do it anyway, because Honor compels them to act.";
        }
        if (value == 4)
        {
            pcMotivation = "Glory";
            InfoTextOutput.text = "Adventures can amass wealth and power, sure, but even better is the tales that men will tell of their deeds and the Glory heaped upon their names!";
        }
        if (value == 5)
        {
            pcMotivation = "Fate";
            InfoTextOutput.text = "Some Adventurers have no choice. No matter what they choose, their Fate awaits them.";
        }
        if (value == 6)
        {
            pcMotivation = "Duty";
            InfoTextOutput.text = "For some Adventurers, adventure is a calling. For others, however, it is their Duty.";
        }
        if (value == 7)
        {
            pcMotivation = "Curiosity";
            InfoTextOutput.text = "What is behind this door? What is down the next staircase? What happens when I pull this lever? Some just have to know.";
        }
        if (value == 8)
        {
            pcMotivation = "Bloodlust";
            InfoTextOutput.text = "One truth that every Adventurer should know is that they will have to kill things. Probably lots of things. Probably messily. This appeals to some more than others.";
        }
    }

    public void StrengthAdd()
    {
        if (xtra > 0) { str++; xtra--; }
        StrengthClickedOn();
    }
    public void StrengthMinus()
    {
        if(str > 3) { str--; xtra++; }
        StrengthClickedOn();
    }
    public void DexterityAdd()
    {
        if (xtra > 0) { dex++; xtra--; }
        DexterityClickedOn();
    }
    public void DexterityMinus()
    {
        if (dex > 3) { dex--; xtra++; }
        DexterityClickedOn();
    }
    public void IntelligenceAdd()
    {
        if (xtra > 0) { iq++; xtra--; }
        IntelligenceClickedOn();
    }
    public void IntelligenceMinus()
    {
        if (iq > 3) { iq--; xtra++; }
        IntelligenceClickedOn();
    }
    public void WisdomAdd()
    {
        if (xtra > 0) { wis++; xtra--; }
        WisdomClickedOn();
    }
    public void WisdomMinus()
    {
        if (wis > 3) { wis--; xtra++; }
        WisdomClickedOn();
    }
    public void PerceptionAdd()
    {
        if (xtra > 0) { per++; xtra--; }
        PerceptionClickedOn();
    }
    public void PerceptionMinus()
    {
        if (per > 3) { per--; xtra++; }
        PerceptionClickedOn();
    }
    public void HealthAdd()
    {
        if (xtra > 0) { hlth++; xtra--; }
        HealthClickedOn();
    }
    public void HealthMinus()
    {
        if (hlth > 3) { hlth--; xtra++; }
        HealthClickedOn();
    }
    public void AuraAdd()
    {
        if (xtra > 0) { aura++; xtra--; }
        AuraClickedOn();
    }
    public void AuraMinus()
    {
        if (aura > 3) { aura--; xtra++; }
        AuraClickedOn();
    }

    public void StrengthClickedOn()
    {
        InfoTextOutput.text = "Strength is used when calculating damage in Melee combat, and is also used for things like Climbing, Forcing Open Doors, Lifting Portcullises to open them. It is also the stat used to save against damage when brute strength is required.";
    }
    public void DexterityClickedOn()
    {
        InfoTextOutput.text = "Dexterity is used when calculating chance to hit in all combat, and it is checked when a character needs to perform a feat of manual dexterity, such as disabling a mechanical trap, or bypassing a mechanical lock. It is the stat used to save against damage when quick reflexes are required.";
    }
    public void IntelligenceClickedOn()
    {
        InfoTextOutput.text = "Intelligence is used to calculate some effects of spells in combat, and it is used to perform certain feats like deciphering a language, remebering a bit of relevant lore, or figuring out how to pick a lock or disarm a trap.";
    }
    public void WisdomClickedOn()
    {
        InfoTextOutput.text = "Wisdom is used to calculate some effects of spells in combat, and it is used when using healing skills, potion making, etc.. It is also used to determine if a character is able to spot magical traps and is needed to bypass magical locks. Finally, it is the stat used to resist hostile magical effects.";
    }
    public void PerceptionClickedOn()
    {
        InfoTextOutput.text = "Perception is used when calculating damage in Ranged combat. It is also used to determine whether a character is able to spot things like mechanical traps, hidden doors, and just generally glean more knowledge from their surroundings.";
    }
    public void HealthClickedOn()
    {
        InfoTextOutput.text = "Health directly translates into more Health Points. The actual value of your hitpoints is determiend by your character type and luck, but a higher Health stat gives you more chances to get more Health Points.";
    }
    public void AuraClickedOn()
    {
        InfoTextOutput.text = "Aura directly translates into more Magic Points in the same way that Health gives more Health Points. The actual value is dependent on other factors, but a high Aura stat will give you more Magic Points.";
    }

    public void NavigateBacktoMainScreen()
    {
        SceneManager.LoadScene("IntroMenuScene");
    }
    public void SaveCharacter()
    {
        if(pcName != "" && pcType != "" && pcMotivation != "" && xtra == 0)
        {
            Debug.Log("save the Game for the First time");
            PCharacter pc = new PCharacter(pcName, pcType, pcMotivation, str, dex, iq, wis, per, hlth, aura, face);
            SaveGame.current = new SaveGame(); Debug.Log("Setting up new save game slot");
            SaveGame.current.GROUP.Add(pc); Debug.Log("adding PC to group");
            SaveGame.current.index = -1;
            //Initial Tags
            SaveGame.current.TAGS.Add("Thelmore_Tavern_Open");
            /*            SaveGame.current.thelmoreBank = true; SaveGame.current.thelmoreBarracks = false; SaveGame.current.thelmoreInn = true; 
                            SaveGame.current.thelmoreRoad = false; SaveGame.current.thelmoreSmith = true; SaveGame.current.thelmoreTavern = true; 
                                SaveGame.current.thelmoreTemple = true; SaveGame.current.thelmoreToolShop = true; SaveGame.current.thelmoreTownHall = false; 
                                    SaveGame.current.thelmoreVoncar = true; SaveGame.current.thelmoreWell = true; Debug.Log("Started bools"); */

            //load rumors
            SaveAndLoad.LoadDefaultRumorList();
            //Create NPCList
            int randMot, randTyp, randFac;
            string tempMot = "", tempTyp = "", tempNam ="";
            PCharacter[] NPC = new PCharacter[25];
            for(int i = 0; i < 25; i++)
            {
                //Name
                tempNam = GameManager.GAME.randomName[Random.Range(0, GameManager.GAME.randomName.Count)];
                //Type
                randTyp = Random.Range(1, 4);
                if (randTyp == 1) tempTyp = "Warrior"; if (randTyp == 2) tempTyp = "Mage"; if (randTyp == 3) tempTyp = "Rogue";
                //Motivation
                randMot = Random.Range(1, 8);
                if (randMot == 1) tempMot = "Money"; if (randMot == 2) tempMot = "Power"; if (randMot == 3) tempMot = "Honor"; if (randMot == 4) tempMot = "Glory";
                if (randMot == 5) tempMot = "Fate"; if (randMot == 6) tempMot = "Duty"; if (randMot == 7) tempMot = "Curiosity"; if (randMot == 4) tempMot = "Bloodlust";
                randMot = Random.Range(1, 7);
                //Face
                randFac = Random.Range(0, 10);
                //Make NPC
                NPC[i] = new PCharacter(tempNam, tempTyp, tempMot, randFac);
                NPC[i].motIndex = randMot;
                //Add to SaveGame list
                SaveGame.current.NPCS.Add(NPC[i]);
            }

            SaveAndLoad.Save(); Debug.Log("Saving savegame");
            SceneManager.LoadScene("ThelmoreTown");
        }
        else { ErrorPanel.SetActive(true); }
    }
}