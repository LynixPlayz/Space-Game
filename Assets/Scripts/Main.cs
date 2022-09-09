using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Color planetColor;
    public Material planetMaterial;
    public Texture2D texture; // load your texture here
    public Color colortrigger; // color triggers to change
    public Color oldcolor;
    Renderer rend;


    void Update() {
        planetMaterial.color = planetColor;
    }
    
    //Run when switching to moon planet
    public void MoonFunction() {
        return;
    }

    //Run when switching to earth planet
    public void EarthFunction() {
        return;
    }
}
