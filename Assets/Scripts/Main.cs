using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Color planetColor;
    public Material planetMaterial;
    public Color MoonColor;
    public Color EarthColor;
    public Texture2D texture; // load your texture here
    public Color colortrigger; // color triggers to change
    public Color oldcolor;
    public RigidbodyWalker rigidbodyWalker;
    public Scene scene;
    Renderer rend;

    void Start() {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Earth") 
        {
            EarthFunction();
        }
        else if (scene.name == "Moon") {
            MoonFunction();
        }
    }

    void Update() {
        planetMaterial.color = planetColor;
    }
    
    //Run when switching to moon planet
    public void MoonFunction() {
        planetColor = MoonColor;
        rigidbodyWalker.jumpHeight = 6;
    }

    //Run when switching to earth planet
    public void EarthFunction() {
        planetColor = EarthColor;
        rigidbodyWalker.jumpHeight = 4;
    }
}
