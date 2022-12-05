using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Vector3[] newVertices;
    public int[] newTriangles;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;

        Shader defaultShader = Shader.Find("Standard");
        Material defaultMaterial = new Material(defaultShader);
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
