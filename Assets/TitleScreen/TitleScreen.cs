using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public Animator cameraAnimation;
    public GameObject titleCanvas;
    public bool doesSpin = true;

    void Start(){}
    void Update(){}

    public void CameraAnim()
    {
        doesSpin = false;
        titleCanvas.SetActive(false);
        cameraAnimation.SetBool("IsPlayed", true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);

        cameraAnimation.SetBool("IsPlayed", false);
    }
}
