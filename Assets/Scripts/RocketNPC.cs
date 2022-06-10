using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNPC : MonoBehaviour
{
    public GameObject keyMenu;
    public GameObject talkMenu;
    public GameObject puzzleUI;
    public Rigidbody playerRb;

    void Start(){}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && keyMenu.activeSelf == true)
        {
            keyMenu.SetActive(false);
            talkMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter() 
    {
        keyMenu.SetActive(true);
    }
    void OnTriggerExit()
    {
        keyMenu.SetActive(false);
    }
    public void cancelButton()
    {
        talkMenu.SetActive(false);
    }
    public void nextButton()
    {
        talkMenu.SetActive(false);
        puzzleUI.SetActive(true);
        playerRb.constraints = RigidbodyConstraints.FreezePosition;
    }
}
