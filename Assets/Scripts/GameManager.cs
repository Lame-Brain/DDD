using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public Sprite[] pcFace, npcWarriorFace, npcMageFace, npcRogueFace, namedNPCFace;
    public List<string> randomName = new List<string>();

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
                SaveGame.current = SaveAndLoad.savedGames[0];
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
        //load up random name lists
        if (File.Exists(Application.persistentDataPath + "/Names.txt"))
        {
            StreamReader file = new StreamReader(Application.persistentDataPath + "/Names.txt");
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                randomName.Add(line);
            }
            file.Close();
        }
        else { Debug.Log("WARNING! THERE ARE NO RUMORS IN THE PERSISTENT DATA PATH!"); }
    }
}
