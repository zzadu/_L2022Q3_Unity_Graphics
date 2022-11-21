using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffect : MonoBehaviour
{

    Shader myShader;
    Material myMaterial; // 파일은 안 만들고 스크립트 내에서 생성, 머티리얼 없으면 안 됨, 여기에 셰이더 할당

    void Start()
    {
        myShader = Shader.Find("My/PostEffect");
        myMaterial = new Material(myShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 0); // 오브젝트의 픽셀 값들을 목적지(화면)에 복제, 0 생략 가능
        // 0: 몇번째 path를 선택하는지 지정하는 옵션
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
