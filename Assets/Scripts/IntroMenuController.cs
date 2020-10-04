using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroMenuController : MonoBehaviour
{
    public Light fireLight;
    public GameObject BGThing, charLoadPanel,charLoadContent, characterPanelPF;
    public float FlickerSpeed;
    public AudioSource ClickSFX;
    private float flPosX, flPosY, flIntensity, counter = 0;

    private GameObject[] loadCharList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > FlickerSpeed)
        {
            counter = 0;
            flPosX = Random.Range(-1f, 1f); flPosY = Random.Range(0f, 10f); flIntensity = Random.Range(1f, 3f);
            //fireLight.transform.position = new Vector3(flPosX, flPosY, 6.5f);
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
        SaveLoad.Load();
        if (SaveLoad.savedPCs.Count > 0) 
        {
            charLoadPanel.SetActive(true);
            loadCharList = new GameObject[SaveLoad.savedPCs.Count];
            for (int i = 0; i < SaveLoad.savedPCs.Count; i++)
            {
                Debug.Log(i + ". another one " + SaveLoad.savedPCs[i].pcName);
                loadCharList[i] = Instantiate(characterPanelPF, charLoadContent.transform);
                loadCharList[i].GetComponentInChildren<Text>().text = SaveLoad.savedPCs[i].pcName + " the " + SaveLoad.savedPCs[i].pcType;
                int x = i; // This fixes the Closure problem.
                loadCharList[i].GetComponent<Button>().onClick.AddListener(() => ClickOnLoadCharacterPanel(x));
            } 
        }
    }

    public void ClickOnLoadCharacterPanel(int num)
    {
        ClickSFX.GetComponent<AudioSource>().Play();
        Debug.Log("Load game for " + SaveLoad.savedPCs[num].pcName);
    }
}
