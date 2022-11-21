using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class depth : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;

    public float Depth = 1f;

    void Start()
    {
        myShader = Shader.Find("My/PostEffect/Depth");
        myMaterial = new Material(myShader);
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Depth", Depth);
        Graphics.Blit(source, destination, myMaterial);
    }
}