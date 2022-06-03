using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;
    // Start is called before the first frame update
    public void SetText(string textString)
    {
        myText.text = textString;
        myTextString = textString;
    }

    // Update is called once per frame
    public void OnClick()
    {
        buttonControl.ButtonClicked(myTextString);
    }
}
