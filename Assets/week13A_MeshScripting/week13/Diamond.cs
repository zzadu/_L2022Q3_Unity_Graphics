using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Vector3 v0, v1, v2, v3, v4, v5;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        v0 = new Vector3(0, 0, -1);
        v1 = new Vector3(0, 0, 0);
        v2 = new Vector3(1, 0, 0);
        v3 = new Vector3(1, 0, -1);
        v4 = new Vector3(0.5f, 1, -0.5f);
        v5 = new Vector3(0.5f, -1, -0.5f);

        vertices = new Vector3[]
        {
            v0, v1, v2, v3, v4, v5
        };

        triangles = new int[]
        {
            0, 4, 3,
            3, 4, 2,
            2, 4, 1,
            1, 4, 0,
            0, 3, 5,
            3, 2, 5,
            2, 1, 5,
            1, 0, 5
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
