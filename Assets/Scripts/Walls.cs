using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    RectTransform rectTransform;
    public GameObject UIobject;
    public Vector2 startPosition;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = UIobject.GetComponent<RectTransform>();
        startPosition = rectTransform.position;
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (gameObject.name != "End"){
            Debug.Log(gameObject.name);
            rectTransform.position = startPosition;
        }
        else
        {
            Debug.Log("this is a pipe");
            playerRb.constraints = RigidbodyConstraints.None;
            UIobject.transform.parent.gameObject.SetActive(false);
        }
    }
}
