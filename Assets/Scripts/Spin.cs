using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject scripts;
    public Transform Environment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scripts.GetComponent<TitleScreen>().doesSpin == true)
        {
            gameObject.transform.Rotate(0.0f, 0.1f, 0.0f, Space.World);
            Environment.Rotate(0.0f, 0.1f, 0.0f, Space.World);
        }
    }
}
