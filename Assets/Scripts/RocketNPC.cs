using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNPC : MonoBehaviour
{
    public GameObject keyMenu;
    public GameObject talkMenu;
    public GameObject puzzleUI;
    public Rigidbody playerRb;
    public GameObject talkMenu2;
    public GameObject camera;
    public GameObject rotateCamera;
    public GameObject player;
    public GameObject Rotater;


    void Start(){}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && keyMenu.activeSelf == true)
        {
            keyMenu.SetActive(false);
            talkMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            player.GetComponent<RigidbodyWalker>().lookSpeed = 0;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerRb.constraints = RigidbodyConstraints.None;
    }
    public void nextButton()
    {
        talkMenu.SetActive(false);
        puzzleUI.SetActive(true);
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void nextButton2()
    {
        camera.SetActive(true);
		rotateCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.freezeRotation = true;
        GameObject.Find("Player").GetComponent<RigidbodyWalker>().lookSpeed = 2;
        talkMenu2.SetActive(false);
        Rotater.GetComponent<CameraRotate>().doRotate = false;
    }
}
