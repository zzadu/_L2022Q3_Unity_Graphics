using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Follow : MonoBehaviour
{
    public Transform PosReference;
    Camera TargetCamera;

    void Start()
    {
        TargetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        DisplayAtPoint();
    }

    void DisplayAtPoint()
    {
        Vector3 WorldPos = PosReference.position + Vector3.up;
        Vector2 ScreenPos = TargetCamera.WorldToScreenPoint(WorldPos);

        gameObject.transform.position = ScreenPos;
    }
}
