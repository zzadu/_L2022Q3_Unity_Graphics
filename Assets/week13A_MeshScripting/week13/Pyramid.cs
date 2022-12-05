using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    Vector3 v0, v1, v2, v3, v4;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        v0 = new Vector3(-0.5f, 0, -0.5f);
        v1 = new Vector3(-0.5f, 0, 0.5f);
        v2 = new Vector3(0.5f, 0, 0.5f);
        v3 = new Vector3(0.5f, 0, -0.5f);
        v4 = new Vector3(0, 1f, 0);

        vertices = new Vector3[]
        {
            v0, v1, v2, v3, v4
        };

        triangles = new int[]
        {
            0, 2, 1, // 아래쪽에서 바라봤을 때 시계방향
            0, 3, 2,
            0, 4, 3,
            3, 4, 2,
            2, 4, 1,
            1, 4, 0
        };

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Shader shader = Shader.Find("Standard");
        Material material = new Material(shader);
        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
