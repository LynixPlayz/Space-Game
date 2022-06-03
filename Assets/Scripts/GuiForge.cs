using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiForge : MonoBehaviour
{
    public GameObject script;
    public GameObject script2;
    public GameObject ForgeMenu;
    public GameObject xtext;
    public GameObject sword;
    public GameObject pick;

    void Start(){
        ForgeMenu.SetActive(false);
        Debug.Log(script.GetComponent<Break>().treeCount);
    }

    void Update(){}

    void OnTriggerEnter(){
        ForgeMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnTriggerExit(){
        ForgeMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    public void ForgeOne(){
        if (script.GetComponent<Break>().treeCount >= 1){
            script.GetComponent<Break>().treeCount -= 1;
            script2.GetComponent<Inventory>().PlankCount += 4;
        }
        else
        {
            StartCoroutine(NotEnough());
        }
    }
    public void ForgeTwo(){
        if (script.GetComponent<Break>().goldCount >= 4 && script.GetComponent<Break>().treeCount >= 2){
            script.GetComponent<Break>().treeCount -= 2;
            script.GetComponent<Break>().goldCount -= 4;
            script2.GetComponent<UsableItem>().IsEquipped = true;
            script2.GetComponent<UsableItem>().EquippedItem = sword;
        }
        else
        {
            StartCoroutine(NotEnough());
        }
    }
    public void ForgeThree(){
        if (script.GetComponent<Break>().rockCount >= 4 && script.GetComponent<Break>().treeCount >= 2){
            script.GetComponent<Break>().treeCount -= 2;
            script.GetComponent<Break>().rockCount -= 4;
            script2.GetComponent<UsableItem>().IsEquipped = true;
            script2.GetComponent<UsableItem>().EquippedItem = pick;
        }
        else
        {
            StartCoroutine(NotEnough());
        }
    }
    IEnumerator NotEnough()
    {
        xtext.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        xtext.SetActive(false);
    }
    
}
