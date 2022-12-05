using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProperties : MonoBehaviour
{
    /// <summary>
    /// 각각 x, y, z 방향을 추가하기 위해 각각의 버텍스마다 3개씩 버텍스 지정
    /// </summary>
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        print(mesh.name);
        print(mesh.vertices);
        int counter = 0;
        foreach (Vector3 vertex in mesh.vertices)
        {
            print(counter + ", " + vertex);
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
