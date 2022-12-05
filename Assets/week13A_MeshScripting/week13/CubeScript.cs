using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    /// <summary>
    /// ���ؽ��� ������ ����� ������ �� ���༭ �������� �� ����
    /// ���ؽ��� ��� ���� �ο��� �� �� ����
    /// ���ؽ� ó�� ��� ��������� ��
    /// </summary>
    Vector3 v0, v1, v2, v3, v4, v5, v6, v7;
    Vector3[] vertices;
    int[] triangles;
    Vector3[] normals;

    public float speed = 0.01f;

    void Start()
    {
        v0 = new Vector3(-0.5f, -0.5f, -0.5f);
        v1 = new Vector3(-0.5f, -0.5f, 0.5f);
        v2 = new Vector3(0.5f, -0.5f, 0.5f);
        v3 = new Vector3(0.5f, -0.5f, -0.5f);
        v4 = new Vector3(-0.5f, 0.5f, -0.5f);
        v5 = new Vector3(-0.5f, 0.5f, 0.5f);
        v6 = new Vector3(0.5f, 0.5f, 0.5f);
        v7 = new Vector3(0.5f, 0.5f, -0.5f);

        vertices = new Vector3[]
        {
            v0, v4, v7, v3, // 0, 1, 2, 3
            v3, v7, v6, v2, // 4, 5, 6, 7
            v2, v6, v5, v1, // 8, 9, 10, 11
            v1, v5, v4, v0, // 12. 13. 14. 15
            v4, v5, v6, v7, // 16, 17, 18, 19
            v0, v1, v2, v3 // 20, 21, 22, 23
        };

        

        triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3, 

            4, 5, 7,
            7, 5, 6, 

            8, 9, 11,
            11, 9, 10, 

            12, 13, 14,
            12, 14, 15, 

            16, 17, 18,
            16, 18, 19, 

            21, 20, 23,
            21, 23, 22
        };

        Vector3 Up = Vector3.up;
        Vector3 Down = Vector3.down;
        Vector3 Front = Vector3.forward;
        Vector3 Left = Vector3.left;
        Vector3 Right = Vector3.right;
        Vector3 Back = Vector3.back;

        normals = new Vector3[] // ���ؽ����� ���� �ο�
        {
            Back, Back, Back, Back,
            Right, Right, Right, Right,
            Front, Front, Front, Front,
            Left, Left, Left, Left,
            Up, Up, Up, Up,
            Down, Down, Down, Down
        };

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;

        Shader shader = Shader.Find("Standard");
        Material material = new Material(shader);
        GetComponent<MeshRenderer>().material = material;
    }

    void Update()
    {
        // ���ؽ��� ��ǥ���� ��� �������� �̵�
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vert = mesh.vertices;
        Vector3[] nor = mesh.normals;

        for (int i = 0; i < vert.Length; i++)
        {
            vert[i] += nor[i] * Mathf.Sin(Time.time) * speed; // �ð��� Sin ���� �ݿ� sin�� ����: -1~1
        }

        mesh.vertices = vert;
    }
}
