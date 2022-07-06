using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class AnimationEvent : MonoBehaviour
{
    public GameObject loading;
    public GameObject titleCamera;
    public GameObject player;
    public GameObject gui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLoading()
    {
        Debug.Log("Loading...");
        loading.SetActive(true);
        StartCoroutine(close());

    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(Random.Range(0, 8));
        loading.SetActive(false);
        titleCamera.SetActive(false);
        player.SetActive(true);
        gui.SetActive(true);
    }
}
