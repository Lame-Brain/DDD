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
        moneyTxt.text = SaveGame.current.GROUP[0].gold.ToString() + " gp";
        for (int i = 0; i < 9; i++)
        {
            HPBar[i].SetActive(false);
            MPBar[i].SetActive(false);
        }

        for (int i = 0; i < SaveGame.current.GROUP.Count; i++)
        {
            HPBar[i].SetActive(true);
            HPBar[i].name = SaveGame.current.GROUP[i].pcName;
            //if (SaveGame.current.GROUP[i].HP - SaveGame.current.GROUP[i].wounds <= 0) HPBar[i].GetComponent<Image>().sprite = barNull;
            if (SaveGame.current.GROUP[i].HP - SaveGame.current.GROUP[i].wounds > 0) HPBar[i].GetComponent<Image>().sprite = hpBarEmpty;
            if (SaveGame.current.GROUP[i].HP - SaveGame.current.GROUP[i].wounds > SaveGame.current.GROUP[i].HP * .40) HPBar[i].GetComponent<Image>().sprite = hpBarHalf;
            if (SaveGame.current.GROUP[i].HP - SaveGame.current.GROUP[i].wounds > SaveGame.current.GROUP[i].HP * .60) HPBar[i].GetComponent<Image>().sprite = hpBarDinged;
            if (SaveGame.current.GROUP[i].HP - SaveGame.current.GROUP[i].wounds > SaveGame.current.GROUP[i].HP * .80) HPBar[i].GetComponent<Image>().sprite = hpBarFull;

            MPBar[i].SetActive(true);
            //if (SaveGame.current.GROUP[i].MP - SaveGame.current.GROUP[i].burnOut <= 0) MPBar[i].GetComponent<Image>().sprite = barNull;
            if (SaveGame.current.GROUP[i].MP == 0) MPBar[i].SetActive(false);
            if (SaveGame.current.GROUP[i].MP - SaveGame.current.GROUP[i].burnOut > 0) MPBar[i].GetComponent<Image>().sprite = mpBarEmpty;
            if (SaveGame.current.GROUP[i].MP - SaveGame.current.GROUP[i].burnOut > SaveGame.current.GROUP[i].MP * .40) MPBar[i].GetComponent<Image>().sprite = mpBarHalf;
            if (SaveGame.current.GROUP[i].MP - SaveGame.current.GROUP[i].burnOut > SaveGame.current.GROUP[i].MP * .60) MPBar[i].GetComponent<Image>().sprite = mpBarDinged;
            if (SaveGame.current.GROUP[i].MP - SaveGame.current.GROUP[i].burnOut > SaveGame.current.GROUP[i].MP * .80) MPBar[i].GetComponent<Image>().sprite = mpBarFull;
        }
    }

}
