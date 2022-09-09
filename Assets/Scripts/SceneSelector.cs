using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public Button getButton;
    public string buttonText;
 /*   public ArrayList buttonList;
    public Text buttonText;
    public Button scene1;
    [SerializeField]
    public int planet1 = 1;
    public string sceneName;
    public Text myText;
    public Button button1;
    public string myTextString;

    public void start()
    {
        SetText("Planet 1");
    }

    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }


   public void OnClick()
    {
        Debug.Log(myTextString);
        ChangeScene(stringToInt(myTextString));
    } 

    public void goToPlanet(int planet)
    {
        if(GetComponent<Button>.text)     
        SceneManager.LoadScene(sceneName);
    }
*/
    void onButtonClick()
    {
        buttonText = getButton.GetComponentInChildren<Text>().text;
        if (buttonText == "Earth")
        {
            SceneManager.LoadScene("Earth");
            Debug.Log("Earth");
        }
        else if (buttonText == "Moon")
        {
            SceneManager.LoadScene("Moon");
            Debug.Log("Moon");
        }
        
    }
}
