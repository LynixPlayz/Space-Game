using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target;
    public bool doRotate;

    void Start()
    {
        
    }

    void Update()
    {
        if (doRotate == true){
            transform.LookAt(target);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
