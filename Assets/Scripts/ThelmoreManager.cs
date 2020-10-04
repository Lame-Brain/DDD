using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThelmoreManager : MonoBehaviour
{
    public Text InfoText, TimeText, DayText, MonthText;
    private int selectedBuilding, time = 0, day = 0, month = 0;
       

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Display Time, Day, and Month correctly.
        if (time == 0) TimeText.text = "<color=blue>Early Morning</color>";
        if (time > 0 && time < 3) TimeText.text = "<color=yellow>Morning</color>";
        if (time > 2 && time < 5) TimeText.text = "<color=blue>Noon</color>";
        if (time > 4 && time < 7) TimeText.text = "<color=cyan>Afternoon</color>";
        if (time == 7) TimeText.text = "<color=magenta>Sunset</color>";
        if (time > 7 && time < 10) TimeText.text = "<color=teal>Early Night</color>";
        if (time > 9 && time < 12) TimeText.text = "<color=black>Midnight</color>";
        if (time > 11 && time < 15) TimeText.text = "<color=darkblue>Late Night</color>";

        if()
    }
}
