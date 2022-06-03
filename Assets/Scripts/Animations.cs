using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public bool advancement3;

    public GameObject script;
    public GameObject script2;
    public Animator achivements;
    public Animator achivements2;
    public Animator achivements3;
    public Animator achivements4;
    // Start is called before the first frame update
    void Awake()
    {
        achivements.SetBool("OnAdvancement", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (script.GetComponent<Break>().achivement1 == true){
            achivements.SetBool("OnAdvancement", true);
            script.GetComponent<Break>().achivement1 = false;
        }
        else {
            achivements.SetBool("OnAdvancement", false);
        }
        if (script2.GetComponent<ButtonListControl>().advancement2 == true){
            achivements2.SetBool("OnAdvancement", true);
            script2.GetComponent<ButtonListControl>().advancement2 = false;
        }
        else {
            achivements2.SetBool("OnAdvancement", false);
        }
        if (advancement3 == true){
            achivements3.SetBool("OnAdvancement", true);
            advancement3 = false;
        }
        else {
            achivements3.SetBool("OnAdvancement", false);
        }
        if (script.GetComponent<Break>().advancement4 == true){
            achivements4.SetBool("OnAdvancement", true);
            script.GetComponent<Break>().advancement4 = false;
        }
        else {
            achivements4.SetBool("OnAdvancement", false);
        }
    }
}