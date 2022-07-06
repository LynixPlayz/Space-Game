using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnim : MonoBehaviour
{
    public GameObject dot1;
    public GameObject dot2;
    public GameObject dot3;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(Loading());
    }

    // Update is called once per frame
    void Update(){}

    void NoDot()
    {
        dot1.SetActive(false);
        dot2.SetActive(false);
        dot3.SetActive(false);
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        NoDot();
        yield return new WaitForSeconds(1);
        dot1.SetActive(true);
        yield return new WaitForSeconds(1);
        dot2.SetActive(true);
        yield return new WaitForSeconds(1);
        dot3.SetActive(true);
        StartCoroutine(Loading());
    }
}
