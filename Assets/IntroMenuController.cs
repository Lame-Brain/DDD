using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenuController : MonoBehaviour
{
    public Light fireLight;
    public GameObject BGThing;
    public float FlickerSpeed;
    private float flPosX, flPosY, flIntensity, counter = 0;

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
}
