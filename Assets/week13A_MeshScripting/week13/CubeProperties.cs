using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProperties : MonoBehaviour
{
    /// <summary>
    /// ���� x, y, z ������ �߰��ϱ� ���� ������ ���ؽ����� 3���� ���ؽ� ����
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
