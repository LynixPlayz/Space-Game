using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeManager : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject getOnMenu;
    public GameObject getOffMenu;
    public GameObject bike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (getOnMenu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerObject.transform.position = bike.transform.position + new Vector3(0f, 3f, 0f);
                bike.transform.rotation = Quaternion.Euler(playerObject.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f));
                bike.transform.parent = playerObject.transform;
                getOnMenu.SetActive(false);
                getOffMenu.SetActive(true);
            }
        }
        else
        {
           if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                bike.transform.parent = null;
                getOnMenu.SetActive(true);
                getOffMenu.SetActive(false);
            } 
        }
    }

    void OnTriggerEnter()
    {
        if (playerObject.GetComponent<ChildTest>().controlType == true)
        {
            getOnMenu.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        getOnMenu.SetActive(false);
        getOffMenu.SetActive(false);
    }
}
