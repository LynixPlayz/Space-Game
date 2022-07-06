using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public GameObject script;
    public GameObject escMenu;
    public GameObject settingsMenu;
    public Slider mainSlider;
    public bool open;
    public GameObject camera;


    void Start() {
        escMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainSlider.wholeNumbers = true;
        mainSlider.minValue = 1;
        mainSlider.maxValue = 10;
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeSlider(); });
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (open == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                escMenu.SetActive(false);
                settingsMenu.SetActive(false);
                open = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                escMenu.SetActive(true);
                open = true;
            }  
        }
    }

    public void ValueChangeSlider()
    {
        script.GetComponent<RigidbodyWalker>().lookSpeed = mainSlider.value;
    }

    public void Settings() {
        escMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void xButton() {
        settingsMenu.SetActive(false);
        escMenu.SetActive(true);
    }

    public void Quit() {
        camera.GetComponent<Break>().Save();
        Application.Quit();
    }

}
