using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventorymenu;
    public bool open;
    public List<string> slots = new List<string>();
    public int PlankCount;
    public Text plankText;
    public bool advancement4;
    // Start is called before the first frame update
    void Start()
    {
        inventorymenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (open == true)
            {
                inventorymenu.SetActive(false);
                open = false;
            }
            else
            {
                inventorymenu.SetActive(true);
                open = true;
            }       
        }
        int scount = slots.Count();
        for (int i = 0; i < scount; i++) {
            Debug.Log(slots[i]);
        }
        plankText.text = PlankCount.ToString();
    }
}
