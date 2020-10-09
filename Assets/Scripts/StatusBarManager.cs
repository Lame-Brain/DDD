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
        moneyTxt.text = GameManager.PARTY[0].gold.ToString() + " gp";
        for (int i = 0; i < 9; i++)
        {
            HPBar[i].SetActive(false);
            MPBar[i].SetActive(false);
        }

        for (int i = 0; i < GameManager.PARTY.Count; i++)
        {
            HPBar[i].SetActive(true);
            HPBar[i].name = GameManager.PARTY[i].pcName;
            if (GameManager.PARTY[i].HP - GameManager.PARTY[i].wounds <= 0) HPBar[i].GetComponent<Image>().sprite = barNull;
            if (GameManager.PARTY[i].HP - GameManager.PARTY[i].wounds > 0) HPBar[i].GetComponent<Image>().sprite = hpBarEmpty;
            if (GameManager.PARTY[i].HP - GameManager.PARTY[i].wounds > GameManager.PARTY[i].HP * .40) HPBar[i].GetComponent<Image>().sprite = hpBarHalf;
            if (GameManager.PARTY[i].HP - GameManager.PARTY[i].wounds > GameManager.PARTY[i].HP * .60) HPBar[i].GetComponent<Image>().sprite = hpBarDinged;
            if (GameManager.PARTY[i].HP - GameManager.PARTY[i].wounds > GameManager.PARTY[i].HP * .80) HPBar[i].GetComponent<Image>().sprite = hpBarFull;

            MPBar[i].SetActive(true);
            if (GameManager.PARTY[i].MP - GameManager.PARTY[i].burnOut <= 0) MPBar[i].GetComponent<Image>().sprite = barNull;
            if (GameManager.PARTY[i].MP - GameManager.PARTY[i].burnOut > 0) MPBar[i].GetComponent<Image>().sprite = mpBarEmpty;
            if (GameManager.PARTY[i].MP - GameManager.PARTY[i].burnOut > GameManager.PARTY[i].MP * .40) MPBar[i].GetComponent<Image>().sprite = mpBarHalf;
            if (GameManager.PARTY[i].MP - GameManager.PARTY[i].burnOut > GameManager.PARTY[i].MP * .60) MPBar[i].GetComponent<Image>().sprite = mpBarDinged;
            if (GameManager.PARTY[i].MP - GameManager.PARTY[i].burnOut > GameManager.PARTY[i].MP * .80) MPBar[i].GetComponent<Image>().sprite = mpBarFull;
        }
    }

}
