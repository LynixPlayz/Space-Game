using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField]public Transform planet;
    [SerializeField]public bool alignToPlanet = true;
    [SerializeField] float gravityConstant = 9.8f;
    [SerializeField] Rigidbody r;


    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();

        r.AddForce(toCenter * gravityConstant, ForceMode.Acceleration);

        if(alignToPlanet)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
            q *= transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
    }
}
