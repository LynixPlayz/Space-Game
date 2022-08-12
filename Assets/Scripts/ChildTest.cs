using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTest : MonoBehaviour
{
    public Transform bike = null;
    public bool controlType = true;

    void Start(){}


    void Update()
    {
        bike = gameObject.transform.Find("Bike");

        if (bike)
        {
            bool hasChild = bike.parent == gameObject.transform;
            print(hasChild);
            controlType = false;
            if(!bike.gameObject.activeSelf){
                controlType = true;
            }
        }
        else
        {
            print("noChild");
            controlType = true;
        }
    }
}
