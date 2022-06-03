/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    public Transform planet;
    public bool alignToPlanet = true;

    public GameObject tree;
    float gravityConstant = 9.8f;
    
    Rigidbody r;

    //public Transform groundCheck;
    //public float groundDistance;
    public float planetRadius;

    public int  n = 5;
    async void Awake()
    {
        r = GetComponent<Rigidbody>(); 
        for (int i = 0; i < n; i++)
        {
            Vector3 spawnPosition = Random.onUnitSphere * (planetRadius) + planet.position;
            Instantiate(tree,spawnPosition, );
        }
        
        r.position = spawnPosition;
    }

    void FixedUpdate()
    {   
        FindRotation();
    }

    void FindRotation()
    {   
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();
        
        //r.AddForce(toCenter * gravityConstant, ForceMode.Acceleration);

        if(alignToPlanet)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
            q *= transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
    }
}*/
