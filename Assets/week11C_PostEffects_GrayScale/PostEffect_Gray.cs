using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect_Gray : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;
    public float grayness;

    void Start()
    {
        myShader = Shader.Find("My/PostEffect/Gray");
        myMaterial = new Material(myShader);
    }

    private void Update()
    {
        grayness = Mathf.Clamp(grayness, 0.0f, 1.0f); // 최소, 최댓값 정해놓음
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Grayness", grayness);
        Graphics.Blit(source, destination, myMaterial, 0);
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
