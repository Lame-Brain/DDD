using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThelmoreManager : MonoBehaviour
{
    public static ThelmoreManager TOWN;
    public GameObject MenuPanel, StatusBar, EnterButton, TavernButton, InnButton, BankButton, TempleButton, SmithButton, VoncarButton, ItemShopButton, WellButton, RoadButton, BarracksButton, TownHallButton,
        TavernPanel, TavernYouArePoorPanel, TavernViewCharacterPanel, TavernVCPrefab, TavernCharacterPanelContent, TavernAdventureConversationPanel;
    public Sprite Tavern_Dark, Inn_Dark, Bank_Dark, Temple_Dark, Smith_Dark, Voncar_Dark, ItemShop_Dark, Well_Dark, Road_Dark, Barracks_Dark, TownHall_Dark,
        Tavern_Bright, Inn_Bright, Bank_Bright, Temple_Bright, Smith_Bright, Voncar_Bright, ItemShop_Bright, Well_Bright, Road_Bright, Barracks_Bright, TownHall_Bright;
    public Text InfoText, TimeText;
    public AudioSource ThelmoreMusic, ThelmoreAmbience, TavernMusic, TavernAmbience;

    private bool showTavern, showInn, showBank, showTemple, showSmith, showVoncar, showItemShop, showWell, showRoad, showBarracks, showTownHall;
    private int storeSelected = 0;

    //TavinsFlagon Interface variables    
    public int priceOfAle;
    public Text TavinsgreetingText, rumorText;
    public GameObject drinkPanel, drinkButton;
    private bool drinkbuttonClicked = false;

    private int dayLastAdventurerCheck, monthLastAdventurerCheck, yearLastAdventurerCheck, adventurerIndexSelected;

    // Start is called before the first frame update
    void Start()
    {
        InitThelmore();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("This Game's Index is " + SaveGame.current.index);

        //TimeManager.AdvanceTime(0.25f);
        TimeText.text = TimeManager.HOUR + TimeManager.DAY + TimeManager.MONTH;

        if (storeSelected == 0 && EnterButton.activeSelf) EnterButton.SetActive(false);
        if (storeSelected > 0 && !EnterButton.activeSelf) EnterButton.SetActive(true);

        if (!showTavern && TavernButton.activeSelf) TavernButton.SetActive(false);
        if (showTavern && !TavernButton.activeSelf) TavernButton.SetActive(true);

        if (!showInn && InnButton.activeSelf) InnButton.SetActive(false);
        if (showInn && !InnButton.activeSelf) InnButton.SetActive(true);

        if (!showBank && BankButton.activeSelf) BankButton.SetActive(false);
        if (showBank && !BankButton.activeSelf) BankButton.SetActive(true);

        if (!showTemple && TempleButton.activeSelf) TempleButton.SetActive(false);
        if (showTemple && !TempleButton.activeSelf) TempleButton.SetActive(true);

        if (!showSmith && SmithButton.activeSelf) SmithButton.SetActive(false);
        if (showSmith && !SmithButton.activeSelf) SmithButton.SetActive(true);

        if (!showVoncar && VoncarButton.activeSelf) VoncarButton.SetActive(false);
        if (showVoncar && !VoncarButton.activeSelf) VoncarButton.SetActive(true);

        if (!showItemShop && ItemShopButton.activeSelf) ItemShopButton.SetActive(false);
        if (showItemShop && !ItemShopButton.activeSelf) ItemShopButton.SetActive(true);

        if (!showWell && WellButton.activeSelf) WellButton.SetActive(false);
        if (showWell && !WellButton.activeSelf) WellButton.SetActive(true);

        if (!showRoad && RoadButton.activeSelf) RoadButton.SetActive(false);
        if (showRoad && !RoadButton.activeSelf) RoadButton.SetActive(true);

        if (!showBarracks && BarracksButton.activeSelf) BarracksButton.SetActive(false);
        if (showBarracks && !BarracksButton.activeSelf) BarracksButton.SetActive(true);

        if (!showTownHall && TownHallButton.activeSelf) TownHallButton.SetActive(false);
        if (showTownHall && !TownHallButton.activeSelf) TownHallButton.SetActive(true);

        /*        if (Input.GetKeyUp(KeyCode.Space))
                {
                    Debug.Log("TIME!");
                    TimeManager.AdvanceTime(15f);
                } */

        //NPC Adventurers Check
        if(TimeManager.DAY_INT > dayLastAdventurerCheck || TimeManager.MONTH_INT > monthLastAdventurerCheck || TimeManager.YEAR_INT > yearLastAdventurerCheck)
        {
            dayLastAdventurerCheck = TimeManager.DAY_INT; monthLastAdventurerCheck = TimeManager.MONTH_INT; yearLastAdventurerCheck = TimeManager.YEAR_INT;
            int rand = Random.Range(0, 100);
            foreach(PCharacter toon in SaveGame.current.NPCS)
            {
                rand = Random.Range(0, 100);
                if(rand < 34)
                {
                    if(toon.pcStatus == "Ready")
                    {
                        toon.pcStatus = "In Dungeon";
                    }
                    else
                    {                        
                        //Character returns
                        //Character dies
                        //Character is mage-severed and returns
                    }
                }
            }
        }

        //TavinsFlagon
        if (TavernPanel.activeSelf)
        {
            if (drinkButton.activeSelf && drinkbuttonClicked) drinkButton.SetActive(false); 
            if (!drinkButton.activeSelf && !drinkbuttonClicked) drinkButton.SetActive(true);
        }
    }

    public void InitThelmore()
    {
        if(TOWN == null)
        {
            TOWN = this;
        }
        else
        {
            Destroy(this);
        }
        //Initialize time system
        TimeManager.AdvanceTime(0f);
        //Initialize status bar
        StatusBar.GetComponent<StatusBarManager>().UpdateStatusBar();
        //Set Store Button bools based on loaded SaveGame
        showBank = false;  if (SaveGame.current.TAGS.Contains("Thelmore_Bank_Open")) showBank = true;
        showBarracks = false;  if (SaveGame.current.TAGS.Contains("Thelmore_Barracks_Open")) showBarracks = true;
        showInn = false;  if (SaveGame.current.TAGS.Contains("Thelmore_Inn_Open")) showInn = true;
        showRoad = false;  if (SaveGame.current.TAGS.Contains("Thelmore_Road_Open")) showRoad = true;
        showSmith = false; if (SaveGame.current.TAGS.Contains("Thelmore_Smith_Open")) showSmith = true;
        showTavern = false; if (SaveGame.current.TAGS.Contains("Thelmore_Tavern_Open")) showTavern = true;
        showTemple = false;  if (SaveGame.current.TAGS.Contains("Thelmore_Temple_Open")) showTemple = true;
        showItemShop = false; if (SaveGame.current.TAGS.Contains("Thelmore_Tools_Open")) showItemShop = true;
        showTownHall = false; if (SaveGame.current.TAGS.Contains("Thelmore_TownHall_Open")) showTownHall = true;
        showVoncar = false; if (SaveGame.current.TAGS.Contains("Thelmore_Magic_Open")) showVoncar = true;
        showWell = false; if (SaveGame.current.TAGS.Contains("Thelmore_Well_Open")) showWell = true;
    }

    public void NavigateBacktoMainScreen()
    {
        SceneManager.LoadScene("IntroMenuScene");
    }

    public void ToggleMenuPanel()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;
        InfoText.text = "";
        storeSelected = 0;
    }

    public void TavinsFlagonSelected()
    {
        //Set all other buttons back to Non-Selected status
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        //Set Tavin's Flagon Button to selected status
        TavernButton.GetComponent<Image>().sprite = Tavern_Bright;

        //Update Info text with information about Tavin's Flagon
        InfoText.text = "Tavin's Flagon is a friendly tavern where you can get a drink, relax and listen to rumors, collect information, and meet fellow adventurers.";

        //Set Store_Selected variable to Tavin's Flagon
        storeSelected = 1;        
    }

    public void EnterTavinsFlagon()
    {
        ThelmoreMusic.Stop();
        ThelmoreAmbience.Stop();
        TavernMusic.Play();
        TavernAmbience.Play();
        TavernPanel.SetActive(true);
        drinkbuttonClicked = false;
        TavinsgreetingText.text = "Tavin offers you a drink, it costs " + priceOfAle + " gp. You currently have " + SaveGame.current.GROUP[0].gold + " gp.";
    }
    public void ExitTavinsFlagon()
    {
        ThelmoreMusic.Play();
        ThelmoreAmbience.Play();
        TavernMusic.Stop();
        TavernAmbience.Stop();
        TavernPanel.SetActive(false);
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InfoText.text = "";
        storeSelected = 0;
    }
    public void TavinsFlagonDrinkButtonReset() {drinkbuttonClicked = false; rumorText.text = ""; }
    public void TavisFlagonDrink()
    {
        if (SaveGame.current.GROUP[0].gold > priceOfAle)
        {
            SaveGame.current.GROUP[0].gold -= priceOfAle;
            drinkbuttonClicked = true;
            rumorText.text = SaveGame.current.RUMORS[Random.Range(0, (SaveGame.current.RUMORS.Count-1))];
            foreach(PCharacter hero in SaveGame.current.GROUP)
            {
                if (hero.burnOut < 10) hero.burnOut = 0;
                if (hero.burnOut >= 10) hero.burnOut -= 10;
                if (hero.wounds < 2) hero.wounds = 0;
                if (hero.wounds >= 2 && hero.wounds < (hero.HP / 2)) hero.wounds -= 2;
            }
        }
        else
        {
            TavernYouArePoorPanel.SetActive(true);
        }
    }
    public void MeetCharacters()
    {
        TavernViewCharacterPanel.SetActive(true);
        //Clear previous panels that hold adventurers
        GameObject[] killThemWithFire = GameObject.FindGameObjectsWithTag("LoadCharacterEntryPanel");
        foreach (GameObject them in killThemWithFire) Destroy(them);

        //Add any new savegames to list of NPCs
        for (int i = 0; i < SaveAndLoad.savedGames.Count; i++)
        {
            if (SaveAndLoad.savedGames[i] != SaveGame.current) //exludes current game
            {
                if (!SaveGame.current.NPCS.Contains(SaveAndLoad.savedGames[i].GROUP[0])) SaveGame.current.NPCS.Add(SaveAndLoad.savedGames[i].GROUP[0]); //If other savegame main characters are not on the NPC list, add them
            }
        }
        GameObject go;
        for (int i = 0; i < SaveGame.current.NPCS.Count; i++)
        {
            if(SaveGame.current.NPCS[i].pcStatus == "Ready")
            {
                go = Instantiate(TavernVCPrefab, TavernCharacterPanelContent.transform);
                go.GetComponent<TavernCharacterButtonController>().index = i;
                go.GetComponent<TavernCharacterButtonController>().text1.text = SaveGame.current.NPCS[i].pcName + " the " + SaveGame.current.NPCS[i].pcType + ", Level " + SaveGame.current.NPCS[i].GetLevel();
                go.GetComponent<TavernCharacterButtonController>().text2.text = "Best Trait(s): " + SaveGame.current.NPCS[i].GetHighestSkills();
                if (SaveGame.current.NPCS[i].pcType == "Warrior") go.GetComponent<TavernCharacterButtonController>().face.sprite = GameManager.GAME.npcWarriorFace[SaveGame.current.NPCS[i].face];
                if (SaveGame.current.NPCS[i].pcType == "Mage") go.GetComponent<TavernCharacterButtonController>().face.sprite = GameManager.GAME.npcMageFace[SaveGame.current.NPCS[i].face];
                if (SaveGame.current.NPCS[i].pcType == "Rogue") go.GetComponent<TavernCharacterButtonController>().face.sprite = GameManager.GAME.npcRogueFace[SaveGame.current.NPCS[i].face];
                if (SaveGame.current.NPCS[i].pcType == "Wanderer") go.GetComponent<TavernCharacterButtonController>().face.sprite = GameManager.GAME.pcFace[SaveGame.current.NPCS[i].face];
            }
        }
    }
    public void MeetCharacterDialogueStart(int index)
    {        
        TavernAdventureConversationPanel.SetActive(true);
        adventurerIndexSelected = index;
        int str = SaveGame.current.NPCS[index].str;
        int dex = SaveGame.current.NPCS[index].dex;
        int iq = SaveGame.current.NPCS[index].iq;
        int wis = SaveGame.current.NPCS[index].wis;
        int per = SaveGame.current.NPCS[index].per;
        int hlth = SaveGame.current.NPCS[index].hlth;
        int aura = SaveGame.current.NPCS[index].aura;
        TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().NameText.text = SaveGame.current.NPCS[index].pcName + " the " + SaveGame.current.NPCS[index].pcType;
        TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().StatText.text = "<color=darkblue>STR " + str + ", </color><color=magenta>DEX " + dex + ", </color><color=silver>IQ " + iq + ", </color><color=yellow>WIS " + wis + "</color> \n <color=green>PER " + per + ", </color><color=red>HLTH " + hlth + ", </color><color=teal>AURA " + aura + " </color> ";
        TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().faceImage.sprite = GameManager.GAME.pcFace[SaveGame.current.NPCS[index].face];
        if (SaveGame.current.NPCS[index].pcType == "Warrior") TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().faceImage.sprite = GameManager.GAME.npcWarriorFace[SaveGame.current.NPCS[index].face];
        if (SaveGame.current.NPCS[index].pcType == "Mage") TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().faceImage.sprite = GameManager.GAME.npcMageFace[SaveGame.current.NPCS[index].face];
        if (SaveGame.current.NPCS[index].pcType == "Rogue") TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().faceImage.sprite = GameManager.GAME.npcRogueFace[SaveGame.current.NPCS[index].face];
        TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().DialogueText.text = TavernAdventureConversationPanel.GetComponent<MeetThePeeps>().TalktoAdventurers(SaveGame.current.NPCS[index]);        
    }
    public void AddAdventurerToParty()
    {
        Debug.Log("Added " + SaveGame.current.NPCS[adventurerIndexSelected].pcName + " to party");
        if (SaveGame.current.GROUP.Count < 9)
        {
            SaveGame.current.NPCS[adventurerIndexSelected].pcStatus = "In Party";
            SaveGame.current.GROUP.Add(SaveGame.current.NPCS[adventurerIndexSelected]);
            StatusBar.GetComponent<StatusBarManager>().UpdateStatusBar();
            SaveAndLoad.Save(); Debug.Log("Saving savegame");
        }
    }

    public void StagNBoarSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        InnButton.GetComponent<Image>().sprite = Inn_Bright;

        InfoText.text = "The Stag & Boar Inn is Thelmore's oldest and only Inn. Come here to stay relax in the common room or stay the night in a clean bed. The Stag & Boar also has a full kitchen, and is an excellent place for meals that are higher quality than trail rations.";

        storeSelected = 2;
    }
    public void EnterStagNBoar()
    {

    }
    public void ExitStagNBoar()
    {

    }

    public void BankSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        BankButton.GetComponent<Image>().sprite = Bank_Bright;

        InfoText.text = "The First Bank of Eragor is the realm's bank. As Thelmore is a crossroads town, this branch boasts a full vault with the best protections King Eragor's Wizards could conjure. A perfect place to store any wealth that you would rather not risk carrying on your person.";

        storeSelected = 3;
    }
    public void EnterBank()
    {

    }
    public void ExitBank()
    {

    }

    public void ADARTempleSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        TempleButton.GetComponent<Image>().sprite = Temple_Bright;

        InfoText.text = "The humans of Atania worship many gods, but in Thelmore, ADAR is the primary deity. Still, shrines to the other gods are housed in ADAR's temple, and no worshipers are turned away by the clerics that serve in the Temple.";

        storeSelected = 4;
    }
    public void EnterADARTemple()
    {

    }
    public void ExitADARTemple()
    {

    }

    public void BlackSmithSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        SmithButton.GetComponent<Image>().sprite = Smith_Bright;

        InfoText.text = "Not every blacksmith can work with weapons and armor, but Thelmore's blacksmith has risen to the challenge of Adventurers flooding the town, and is proud to turn out arms and armor that rival the expensive armorsmiths of larger cities.";

        storeSelected = 5;
    }
    public void EnterBlackSmith()
    {

    }
    public void ExitBlackSmith()
    {

    }

    public void VoncarSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        VoncarButton.GetComponent<Image>().sprite = Voncar_Bright;

        InfoText.text = "Voncar's Mysterium is an odd place, but it is the only place in Thelmore to find magical supplies and advice.";

        storeSelected = 6;
    }
    public void EnterVoncarShop()
    {

    }
    public void ExitVoncarShop()
    {

    }

    public void ToolShopSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Bright;

        InfoText.text = "Adventurers wielding steel and magic can nevertheless be defeated a simple lack of rope. This toolshop should have whatever miscellanous supplies and tools that you need.";

        storeSelected = 7;
    }
    public void EnterToolShop()
    {

    }
    public void ExitToolShop()
    {

    }

    public void WellSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        WellButton.GetComponent<Image>().sprite = Well_Bright;

        InfoText.text = "This is where the fateful well that breached the <color=red>DEADLY DARK DEEPS</color> was being dug. It is now enclosed in a wall and guarded, night and day. Officially, no one is allowed through. Unofficially, you can buy passage for a small fee to the guard on duty.";

        storeSelected = 8;
    }
    public void EnterWell()
    {

    }
    public void ExitWell()
    {

    }

    public void RoadSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        RoadButton.GetComponent<Image>().sprite = Road_Bright;

        InfoText.text = "One of the Three main roads leaving Thelmore.";

        storeSelected = 8;
    }
    public void EnterRoad()
    {

    }
    public void ExitRoad()
    {

    }

    public void BarracksSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;
        TownHallButton.GetComponent<Image>().sprite = TownHall_Dark;

        BarracksButton.GetComponent<Image>().sprite = Barracks_Bright;

        InfoText.text = "Thelmore has a town guard, although it is stretched quite thin with recent events and the influx of Adventurers that has caused. Still, here is where the best fighters in town can be found, training themselves for action.";

        storeSelected = 8;
    }
    public void EnterBarracks()
    {

    }
    public void ExitBarracks()
    {

    }

    public void TownHallSelected()
    {
        TavernButton.GetComponent<Image>().sprite = Tavern_Dark;
        InnButton.GetComponent<Image>().sprite = Inn_Dark;
        BankButton.GetComponent<Image>().sprite = Bank_Dark;
        TempleButton.GetComponent<Image>().sprite = Temple_Dark;
        SmithButton.GetComponent<Image>().sprite = Smith_Dark;
        VoncarButton.GetComponent<Image>().sprite = Voncar_Dark;
        ItemShopButton.GetComponent<Image>().sprite = ItemShop_Dark;
        RoadButton.GetComponent<Image>().sprite = Road_Dark;
        BarracksButton.GetComponent<Image>().sprite = Barracks_Dark;
        WellButton.GetComponent<Image>().sprite = Well_Dark;

        TownHallButton.GetComponent<Image>().sprite = TownHall_Bright;

        InfoText.text = "This is Thelmore's seat of political power. The Govenor whose office is housed in this building is a representative of King Eragor himself, and member of the Kingdom's nobility.";

        storeSelected = 8;
    }
    public void EnterTownHall()
    {

    }
    public void ExitTownHall()
    {

    }

    public void EnterButtonPushed()
    {
        if (storeSelected == 1) EnterTavinsFlagon();
    }
}
