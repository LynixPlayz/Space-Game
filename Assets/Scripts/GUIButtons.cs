using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButtons : MonoBehaviour
{   
    public RigidbodyWalker RigidbodyWalker;
    // Start is called before the first frame update
    void Start(){}
    void Update(){}
    public void Plus()
    {
        RigidbodyWalker.speed += 5;
    }
    public void Minus()
    {
        RigidbodyWalker.speed -= 5;
    }
}
