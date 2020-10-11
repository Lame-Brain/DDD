using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarManager : MonoBehaviour
{
    public GameObject[] HPBar, MPBar;
    public Sprite hpBarFull, hpBarDinged, hpBarHalf, hpBarEmpty, mpBarFull, mpBarDinged, mpBarHalf, mpBarEmpty, barNull;
    public Text moneyTxt;

    public void UpdateStatusBar()
    {
        moneyTxt.text = SaveGame.GROUP[0].gold.ToString() + " gp";
        for (int i = 0; i < 9; i++)
        {
            HPBar[i].SetActive(false);
            MPBar[i].SetActive(false);
        }

        for (int i = 0; i < SaveGame.GROUP.Count; i++)
        {
            HPBar[i].SetActive(true);
            HPBar[i].name = SaveGame.GROUP[i].pcName;
            if (SaveGame.GROUP[i].HP - SaveGame.GROUP[i].wounds <= 0) HPBar[i].GetComponent<Image>().sprite = barNull;
            if (SaveGame.GROUP[i].HP - SaveGame.GROUP[i].wounds > 0) HPBar[i].GetComponent<Image>().sprite = hpBarEmpty;
            if (SaveGame.GROUP[i].HP - SaveGame.GROUP[i].wounds > SaveGame.GROUP[i].HP * .40) HPBar[i].GetComponent<Image>().sprite = hpBarHalf;
            if (SaveGame.GROUP[i].HP - SaveGame.GROUP[i].wounds > SaveGame.GROUP[i].HP * .60) HPBar[i].GetComponent<Image>().sprite = hpBarDinged;
            if (SaveGame.GROUP[i].HP - SaveGame.GROUP[i].wounds > SaveGame.GROUP[i].HP * .80) HPBar[i].GetComponent<Image>().sprite = hpBarFull;

            MPBar[i].SetActive(true);
            if (SaveGame.GROUP[i].MP - SaveGame.GROUP[i].burnOut <= 0) MPBar[i].GetComponent<Image>().sprite = barNull;
            if (SaveGame.GROUP[i].MP - SaveGame.GROUP[i].burnOut > 0) MPBar[i].GetComponent<Image>().sprite = mpBarEmpty;
            if (SaveGame.GROUP[i].MP - SaveGame.GROUP[i].burnOut > SaveGame.GROUP[i].MP * .40) MPBar[i].GetComponent<Image>().sprite = mpBarHalf;
            if (SaveGame.GROUP[i].MP - SaveGame.GROUP[i].burnOut > SaveGame.GROUP[i].MP * .60) MPBar[i].GetComponent<Image>().sprite = mpBarDinged;
            if (SaveGame.GROUP[i].MP - SaveGame.GROUP[i].burnOut > SaveGame.GROUP[i].MP * .80) MPBar[i].GetComponent<Image>().sprite = mpBarFull;
        }
    }

}
