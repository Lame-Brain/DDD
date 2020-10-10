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
        moneyTxt.text = Party.GROUP[0].gold.ToString() + " gp";
        for (int i = 0; i < 9; i++)
        {
            HPBar[i].SetActive(false);
            MPBar[i].SetActive(false);
        }

        for (int i = 0; i < Party.GROUP.Count; i++)
        {
            HPBar[i].SetActive(true);
            HPBar[i].name = Party.GROUP[i].pcName;
            if (Party.GROUP[i].HP - Party.GROUP[i].wounds <= 0) HPBar[i].GetComponent<Image>().sprite = barNull;
            if (Party.GROUP[i].HP - Party.GROUP[i].wounds > 0) HPBar[i].GetComponent<Image>().sprite = hpBarEmpty;
            if (Party.GROUP[i].HP - Party.GROUP[i].wounds > Party.GROUP[i].HP * .40) HPBar[i].GetComponent<Image>().sprite = hpBarHalf;
            if (Party.GROUP[i].HP - Party.GROUP[i].wounds > Party.GROUP[i].HP * .60) HPBar[i].GetComponent<Image>().sprite = hpBarDinged;
            if (Party.GROUP[i].HP - Party.GROUP[i].wounds > Party.GROUP[i].HP * .80) HPBar[i].GetComponent<Image>().sprite = hpBarFull;

            MPBar[i].SetActive(true);
            if (Party.GROUP[i].MP - Party.GROUP[i].burnOut <= 0) MPBar[i].GetComponent<Image>().sprite = barNull;
            if (Party.GROUP[i].MP - Party.GROUP[i].burnOut > 0) MPBar[i].GetComponent<Image>().sprite = mpBarEmpty;
            if (Party.GROUP[i].MP - Party.GROUP[i].burnOut > Party.GROUP[i].MP * .40) MPBar[i].GetComponent<Image>().sprite = mpBarHalf;
            if (Party.GROUP[i].MP - Party.GROUP[i].burnOut > Party.GROUP[i].MP * .60) MPBar[i].GetComponent<Image>().sprite = mpBarDinged;
            if (Party.GROUP[i].MP - Party.GROUP[i].burnOut > Party.GROUP[i].MP * .80) MPBar[i].GetComponent<Image>().sprite = mpBarFull;
        }
    }

}
