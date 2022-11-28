using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Text nameTxt;
    public InputField input;

    public void OnClick()
    {
        string n = input.text;
        nameTxt.text = n;
    }
}
