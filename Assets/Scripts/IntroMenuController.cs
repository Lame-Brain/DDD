using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroMenuController : MonoBehaviour
{
    public static IntroMenuController MAINMENU;

    public Light fireLight;
    public GameObject BGThing, charLoadPanel,charLoadContent, deleteCharacterConfirmPanel, characterPanelPF;
    public float FlickerSpeed;
    public AudioSource ClickSFX;
    private float flPosX, flPosY, flIntensity, counter = 0;
    private int CharacterToDelete = -1;

    private GameObject[] loadCharList;
    
    void Awake()
    {
        if(MAINMENU == null)
        {
            MAINMENU = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > FlickerSpeed)
        {
            counter = 0;
            flPosX = Random.Range(-1f, 1f); flPosY = Random.Range(0f, 10f); flIntensity = Random.Range(1f, 3f);
            fireLight.intensity = flIntensity;
        }

        float y = BGThing.GetComponent<Renderer>().material.mainTextureOffset.y;
        BGThing.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, y - 0.0001f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NavigateToCreateCharacter()
    {
        SceneManager.LoadScene("CharacterCreationScene");
    }

    public void LoadCharacter()
    {
        SaveAndLoad.Load();
        if (SaveAndLoad.savedGames.Count > 0) 
        {
            charLoadPanel.SetActive(true);
            loadCharList = new GameObject[SaveAndLoad.savedGames.Count];            
            for (int i = 0; i < SaveAndLoad.savedGames.Count; i++)
            {
                loadCharList[i] = Instantiate(characterPanelPF, charLoadContent.transform);
                loadCharList[i].GetComponentInChildren<Text>().text = SaveGame.current.GROUP[0].pcName + " the " + SaveGame.current.GROUP[0].pcType;
                int x = i; // This fixes the Closure problem.
                loadCharList[i].GetComponent<Button>().onClick.AddListener(() => ClickOnLoadCharacterPanel(x));
                loadCharList[i].GetComponent<DeleteCharacterButton>().ButtonIndex = i;
                if (SaveAndLoad.savedGames[i].GROUP[0].pcStatus != "Ready") loadCharList[i].SetActive(false);
            } 
        }
    }
    public void LoadCharacterPanelClosed()
    {
        GameObject[] killThemWithFire = GameObject.FindGameObjectsWithTag("LoadCharacterEntryPanel");
        foreach(GameObject them in killThemWithFire) Destroy(them);
        charLoadPanel.SetActive(false);
    }

    public void ClickOnLoadCharacterPanel(int num)
    {
        ClickSFX.GetComponent<AudioSource>().Play();
        SaveGame.current = SaveAndLoad.savedGames[num];
        SceneManager.LoadScene("ThelmoreTown");
    }

    public void DeleteCharacterConfirmPanel(int n)
    {
        CharacterToDelete = n;
        deleteCharacterConfirmPanel.SetActive(true);
    }
    public void DeleteCharacter()
    {
        if (CharacterToDelete > -1)
        {
            SaveAndLoad.savedGames.RemoveAt(CharacterToDelete);
            SaveAndLoad.UpdateSave();
            deleteCharacterConfirmPanel.SetActive(false);
            LoadCharacterPanelClosed();
        }
        else Debug.Log("ERROR! INVALID CHARACTER REFERENCE WHEN DELETING");
    }
}
