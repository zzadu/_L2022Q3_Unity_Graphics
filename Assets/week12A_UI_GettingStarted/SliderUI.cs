using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public GameObject cube;
    Material cubeMaterial;

    void Start()
    {
        cubeMaterial = cube.GetComponent<Renderer>().material;
    }

    public void ChangeColor()
    {
        float value = GetComponent<Slider>().value;
        Color c = new Color(value, value, value, 1);

        cubeMaterial.color = c;
    }
}
