using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactive : MonoBehaviour
{
    int brightness;
    Renderer MyRenderer;

    void Start()
    {
        MyRenderer = gameObject.GetComponent<Renderer>();
        brightness = 1;
        MyRenderer.material.SetInt("_Brightness", 1);
    }

    private void OnMouseDown()
    {
        brightness *= -1;
        MyRenderer.material.SetInt("_Brightness", brightness);
    }
}
