using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public static List<PCharacter> PARTY;

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
                SaveLoad.Load();
                PARTY.Add(SaveLoad.savedPCs[0]);
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
        PARTY = new List<PCharacter>();
    }
}
