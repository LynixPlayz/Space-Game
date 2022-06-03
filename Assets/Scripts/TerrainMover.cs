using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    void Start(){}
    void Update(){}
    
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name != "Planet")
        {
            Debug.Log("epic");
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            Destroy(col.gameObject);
        }
    }
}
