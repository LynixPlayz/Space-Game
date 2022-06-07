using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMan : MonoBehaviour
{
    public GameObject emenu;
    public bool emenuactive;
    public GameObject Rocket;
    public GameObject script;
    // Start is called before the first frame update
    void Start()
    {
        emenuactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (emenuactive == true && Input.GetKeyDown(KeyCode.F) && script.GetComponent<Break>().goldCount >= 8){
            script.GetComponent<Break>().goldCount -= 8;
            Rocket.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col){
        emenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        emenuactive = true;

    }

    void OnTriggerExit(Collider col){
        emenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        emenuactive = false;
    }
}
