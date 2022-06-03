using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private string[] planetArray;

    private List<GameObject> buttons;

    public bool advancement2;

    void Start()
    {
        
        buttons = new List<GameObject>();
        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        foreach (string planet in planetArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText(planet);
           
           
           /* if(i == 1)
            {
                button.GetComponent<ButtonListButton>().SetText("Earth");
            } else {
                button.GetComponent<ButtonListButton>().SetText("Planet " + i);
            }*/
            
            
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log("Button clicked: " + myTextString);
        //SceneManager.LoadScene(myTextString);
        if(myTextString == "Moon"){
            advancement2 = true;
        }
    }
}

