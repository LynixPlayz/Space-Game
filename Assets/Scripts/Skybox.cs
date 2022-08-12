using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public bool isNight = true;
    public Material Day;
    public Material Night;
    void Awake()
    {
        isNight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 1){
            isNight = true;
        }
        if (transform.position.y >= 1)
        {
            isNight = false;
        }
    }
    
    void FixedUpdate()
    {
        if(isNight == true)
        {
            RenderSettings.skybox = Night;
        }
        else if (isNight == false)
        {
            RenderSettings.skybox = Day;
        }
    }
}
