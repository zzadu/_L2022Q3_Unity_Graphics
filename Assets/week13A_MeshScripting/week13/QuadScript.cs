using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
    public Vector3[] newVertices; // ���� 4�� �����
    public int[] newTriangles; // ���ؽ� �ε������� �ʿ��ؼ� int�� ����

    /// <summary>
    ///  triangle�� �ݵ�� �ð�������� �ؾ� ����
    /// </summary>

    void Start()
    {
        // �ν����Ϳ����� ������Ʈ �߰� ����
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;

        Shader DefaultShader = Shader.Find("Standard");
        Material DefaultMaterial = new Material(DefaultShader);
        GetComponent<MeshRenderer>().material = DefaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
