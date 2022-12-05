using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
    public Vector3[] newVertices; // 정점 4개 찍어줌
    public int[] newTriangles; // 버텍스 인덱스값이 필요해서 int로 선언

    /// <summary>
    ///  triangle은 반드시 시계방향으로 해야 보임
    /// </summary>

    void Start()
    {
        // 인스펙터에서도 컴포넌트 추가 가능
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
