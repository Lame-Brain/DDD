using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;

    //First thing called
    void Awake()
    {
        if(GAME == null)
        {
            GAME = this;
            DontDestroyOnLoad(GAME);
            Initilize();
            if (SceneManager.GetActiveScene().name == "ThelmoreTown")
            {
                SaveAndLoad.Load();
                //SaveGame.GROUP.Add(SaveAndLoad.savedPCs[0]);
            }
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initilize()
    {
        SaveGame.GROUP = new List<PCharacter>();
    }
}
