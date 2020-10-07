using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCharacterButton : MonoBehaviour
{
    public int ButtonIndex;

    public void ClickCharacterPanelSubButton()
    {
        IntroMenuController.MAINMENU.DeleteCharacterConfirmPanel(ButtonIndex);
    }
}
