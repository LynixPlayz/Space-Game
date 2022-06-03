using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystrokeHandler : MonoBehaviour
{
    public bool CursorLocked;
    void Start(){}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            if (CursorLocked == false){
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CursorLocked = true;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                CursorLocked = false;
            }
        }

    }
}
