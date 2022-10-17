using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject pointLight;
    bool isOn;

    private void Start()
    {
        isOn = false;
        pointLight.SetActive(isOn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isOn = !isOn;
            pointLight.SetActive(isOn);
        }

    }

    private void OnMouseDown()
    {
        isOn = !isOn;
        pointLight.SetActive(isOn);
    }
}
