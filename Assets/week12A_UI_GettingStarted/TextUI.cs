using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public GameObject cube;

    void Start()
    {
        GetComponent<Text>().text = cube.name + " Áö¿¬";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
