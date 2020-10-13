using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernCharacterButtonController : MonoBehaviour
{
    public int index;
    public Text text1, text2;
    public Image face;

    public void SendClick()
    {
        ThelmoreManager.TOWN.MeetCharacterDialogueStart(index);
    }
}
