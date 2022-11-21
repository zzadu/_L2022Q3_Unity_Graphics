using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffect : MonoBehaviour
{

    Shader myShader;
    Material myMaterial; // ������ �� ����� ��ũ��Ʈ ������ ����, ��Ƽ���� ������ �� ��, ���⿡ ���̴� �Ҵ�

    void Start()
    {
        myShader = Shader.Find("My/PostEffect");
        myMaterial = new Material(myShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 0); // ������Ʈ�� �ȼ� ������ ������(ȭ��)�� ����, 0 ���� ����
        // 0: ���° path�� �����ϴ��� �����ϴ� �ɼ�
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
