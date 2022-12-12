using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad3 : MonoBehaviour
{
    Vector3 v0, v1, v2, v3;
    Vector3[] newVertices; // 정점 4개 찍어줌
    int[] newTriangles; // 버텍스 인덱스값이 필요해서 int로 선언

    public Vector2 uv0, uv1, uv2, uv3;
    Vector2[] newUVs;

    public Texture Dice;

    /// <summary>
    ///  triangle은 반드시 시계방향으로 해야 보임
    /// </summary>

    void Start()
    {
        v0 = new Vector3(0, 0, 0);
        v1 = new Vector3(0, 1, 0);
        v2 = new Vector3(1, 1, 0);
        v3 = new Vector3(1, 0, 0);

        //uv0 = new Vector2(0, 0);
        //uv1 = new Vector2(0, 1);
        //uv2 = new Vector2(1, 1);
        //uv3 = new Vector2(1, 0);

        newVertices = new Vector3[]
        {
            v0, v1, v2, v3
        };

        newUVs = new Vector2[]
        {
            uv0, uv1, uv2, uv3
        };

        newTriangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
         };

        // 인스펙터에서도 컴포넌트 추가 가능
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.uv = newUVs;

        Shader DefaultShader = Shader.Find("Standard");
        Material DefaultMaterial = new Material(DefaultShader);
        DefaultMaterial.mainTexture = Dice;
        GetComponent<MeshRenderer>().material = DefaultMaterial;
    }
}
