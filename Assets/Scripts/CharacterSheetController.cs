using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSheetController : MonoBehaviour
{
    public Text name_typeText, strText, dexText, iqText, wisText, perText, hlthText, auraText, levelText, hpText, woundsText, firstAidText, mpText, burnoutText, ennervateText;
    public GameObject dropCharacterButton, statusButton, statusPanel;
    public Image characterPortrait;
    private int index;

    // Update is called once per frame
    void Update()
    {        
        characterPortrait.sprite = GameManager.GAME.pcFace[SaveGame.current.GROUP[index].face];
        if (SaveGame.current.GROUP[index].pcType == "Warrior") characterPortrait.sprite = GameManager.GAME.npcWarriorFace[SaveGame.current.GROUP[index].face];
        if (SaveGame.current.GROUP[index].pcType == "Mage") characterPortrait.sprite = GameManager.GAME.npcMageFace[SaveGame.current.GROUP[index].face];
        if (SaveGame.current.GROUP[index].pcType == "Rogue") characterPortrait.sprite = GameManager.GAME.npcRogueFace[SaveGame.current.GROUP[index].face];
        name_typeText.text = SaveGame.current.GROUP[index].pcName + " the " + SaveGame.current.GROUP[index].pcType;
        strText.text = "Strength is <color=black>" + SaveGame.current.GROUP[index].str + "</color>";
        dexText.text = "Dexterity is <color=black>" + SaveGame.current.GROUP[index].dex + "</color>";
        iqText.text = "Intelligence is <color=black>" + SaveGame.current.GROUP[index].iq + "</color>";
        wisText.text = "Wisdom is <color=black>" + SaveGame.current.GROUP[index].wis + "</color>";
        perText.text = "Perception is <color=black>" + SaveGame.current.GROUP[index].per + "</color>";
        hlthText.text = "Health is <color=black>" + SaveGame.current.GROUP[index].hlth + "</color>";
        auraText.text = "Aura is <color=black>" + SaveGame.current.GROUP[index].aura + "</color>";
        levelText.text = "Level <color=black>" + SaveGame.current.GROUP[index].GetLevel() + "</color>";
        hpText.text = "HitPnts = " + SaveGame.current.GROUP[index].HP;
        woundsText.text = "";
        firstAidText.text = "";
        mpText.text = "";
        burnoutText.text = "";
        ennervateText.text = "";
        if (SaveGame.current.GROUP[index].wounds > 0) woundsText.text = "wounds = " + SaveGame.current.GROUP[index].wounds;
        if (SaveGame.current.GROUP[index].firstAid > 0) firstAidText.text = "1st Aid = " + SaveGame.current.GROUP[index].firstAid;
        if (SaveGame.current.GROUP[index].MP > 0) mpText.text = "MgcPnts = " + SaveGame.current.GROUP[index].MP;
        if (SaveGame.current.GROUP[index].burnOut > 0) burnoutText.text = "Burn = " + SaveGame.current.GROUP[index].burnOut;
        if (SaveGame.current.GROUP[index].enervate > 0) ennervateText.text = "Enervate = " + SaveGame.current.GROUP[index].enervate;

        if (index == 0 && dropCharacterButton.activeSelf) dropCharacterButton.SetActive(false);
        if (index > 0 && !dropCharacterButton.activeSelf) dropCharacterButton.SetActive(true);

        if (statusPanel.activeSelf) //Status panel is open, update.
        {

        }
    }

    public void OpenCharacterSheet()
    {
        statusPanel.SetActive(false);
        index = 0;
    }
    public void PreviousButtonPushed()
    {
        index--;
        if (index < 0) index = SaveGame.current.GROUP.Count-1;
    }
    public void NextButtonPushed()
    {
        index++;
        if (index > SaveGame.current.GROUP.Count-1) index = 0;
    }
    public void DropCharacter()
    {

    }
}
