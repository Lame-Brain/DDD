using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThelmoreManager : MonoBehaviour
{
    public GameObject MenuPanel, StatusBar, EnterButton, TavernButton, InnButton, BankButton, TempleButton, SmithButton, VoncarButton, ItemShopButton, WellButton, RoadButton, BarracksButton, TownHallButton,
        TavernPanel;
    public Sprite Tavern_Dark, Inn_Dark, Bank_Dark, Temple_Dark, Smith_Dark, Voncar_Dark, ItemShop_Dark, Well_Dark, Road_Dark, Barracks_Dark, TownHall_Dark,
        Tavern_Bright, Inn_Bright, Bank_Bright, Temple_Bright, Smith_Bright, Voncar_Bright, ItemShop_Bright, Well_Bright, Road_Bright, Barracks_Bright, TownHall_Bright;
    public Text InfoText, TimeText;
    public AudioSource ThelmoreMusic, ThelmoreAmbience, TavernMusic, TavernAmbience;

    private bool showTavern, showInn, showBank, showTemple, showSmith, showVoncar, showItemShop, showWell, showRoad, showBarracks, showTownHall;
    private int storeSelected = 0;


    // Start is called before the first frame update
    void Start()
    {
        InitThelmore();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void InitThelmore()
    {
        TimeManager.AdvanceTime(0f);
        StatusBar.GetComponent<StatusBarManager>().UpdateStatusBar();

        showBank = SaveGame.current.thelmoreBank;
        showBarracks = SaveGame.current.thelmoreBarracks;
        showInn = SaveGame.current.thelmoreInn;
        showRoad = SaveGame.current.thelmoreRoad;
        showSmith = SaveGame.current.thelmoreSmith;
        showTavern = SaveGame.current.thelmoreTavern;
        showTemple = SaveGame.current.thelmoreTemple;
        showItemShop = SaveGame.current.thelmoreToolShop;
        showTownHall = SaveGame.current.thelmoreTownHall;
        showVoncar = SaveGame.current.thelmoreVoncar;
        showWell = SaveGame.current.thelmoreWell;        
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
    }
    public void ExitTavinsFlagon()
    {
        ThelmoreMusic.Play();
        ThelmoreAmbience.Play();
        TavernMusic.Stop();
        TavernAmbience.Stop();
        TavernPanel.SetActive(false);
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

    public void EnterButtonPushed()
    {
        if (storeSelected == 1) EnterTavinsFlagon();
    }
}
