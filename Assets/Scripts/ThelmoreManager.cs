using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThelmoreManager : MonoBehaviour
{
    public Text InfoText, TimeText;
    private int selectedBuilding, time = 0, day = 1, month = 0;
       

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Display Time, Day, and Month correctly.
        string timeOutput = "";
        if (time > 11) { time = 0; day++; }
        if (time == 0) timeOutput = "<color=blue>Early Morning</color> ";
        if (time > 0 && time < 3) TimeText.text = "<color=yellow>Morning</color> ";
        if (time == 3) timeOutput = "<color=blue>Noon</color> ";
        if (time > 4 && time < 6) timeOutput = "<color=cyan>Afternoon</color> ";
        if (time == 6) TimeText.text = "<color=magenta>Sunset</color> ";
        if (time > 6 && time < 9) timeOutput = "<color=teal>Early Night</color> ";
        if (time == 9) TimeText.text = "<color=black>Midnight</color> ";
        if (time > 9 && time < 12) timeOutput = "<color=darkblue>Late Night</color> ";

        string stringOutput = "";
        if (month == 0)
        {
            stringOutput += "";
            if (day > 1) AdvanceMonth();
        }
        if (month == 1)
        {
            stringOutput += "<color=magenta>Holy to GREAT MOTHER</color>";
            if (day > 4) AdvanceMonth();
        }
        if (month == 2)
        {
            stringOutput += "of the <color=white>Month of UL</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 3)
        {
            stringOutput += "of the <color=white>Month of NIOTL</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 4)
        {
            stringOutput += "of the <color=white>Month of OZTOZ</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 5)
        {
            stringOutput += "of <color=magenta>the Spring Equinox</color>";
            if (day > 7) AdvanceMonth();
        }
        if (month == 6)
        {
            stringOutput += "of the <color=lime>Month of FOTA</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 7)
        {
            stringOutput += "of the <color=lime>Month of ADAR</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 8)
        {
            stringOutput += "of the <color=lime>Month of VIUNA</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 9)
        {
            stringOutput += "of <color=magenta>the Summer Solstice</color>";
            if (day > 6) AdvanceMonth();
        }
        if (month == 10)
        {
            stringOutput += "of the <color=yellow>Month of IAMUS</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 11)
        {
            stringOutput += "of the <color=yellow>Month of SAMDIOME</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 12)
        {
            stringOutput += "of the <color=yellow>Month of ELIUS</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 13)
        {
            stringOutput += "of <color=magenta>the Autumn Equinox</color>";
            if (day > 7) AdvanceMonth();
        }
        if (month == 14)
        {
            stringOutput += "of the <color=brown>Month ZEDIA</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 15)
        {
            stringOutput += "of the <color=brown>Month of YNARUS</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 16)
        {
            stringOutput += "of the <color=brown>Month of RANERA</color>";
            if (day > 28) AdvanceMonth();
        }
        if (month == 17)
        {
            stringOutput += "<color=magenta>Holy to the WISE CRONE</color>";
            if (day > 4) AdvanceMonth();
        }
        string dayOutput = "the " + day + "th day ";
        if (day == 1) dayOutput = "the 1st day ";
        if (day == 2) dayOutput = "the 2nd day ";
        if (day == 3) dayOutput = "the 3rd day ";
        if (day == 21) dayOutput = "the 21st day ";
        if (day == 22) dayOutput = "the 22nd day ";
        if (day == 23) dayOutput = "the 23rd day ";
        if(month == 0) dayOutput = "of the <color=white>THE WINTER SOLSTICE</color> ";
        TimeText.text = timeOutput + dayOutput + stringOutput;

        InfoText.text = GameManager.PARTY[0].pcName + " has index " + GameManager.PARTY[0].index.ToString();
    }

    public void AdvanceMonth()
    {
        day = 1;
        month++;
        if (month > 17) month = 0;
    }

    public void NavigateBacktoMainScreen()
    {
        SceneManager.LoadScene("IntroMenuScene");
    }
}
