using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    Material myMaterial;
    public GameObject myGameObject;
    bool isOn;

    Color c1;
    Color c2;
    
    void Start()
    {
        myMaterial = myGameObject.GetComponent<Renderer>().material;
        c1 = new Color(1, 1, 1, 1);
        c2 = new Color(1, 0, 0, 1);
    }

    public void OnValueChanged()
    {
        isOn = GetComponent<Toggle>().isOn;
        if (isOn)
            myMaterial.color = c1;
        else
            myMaterial.color = c2;
    }
}
