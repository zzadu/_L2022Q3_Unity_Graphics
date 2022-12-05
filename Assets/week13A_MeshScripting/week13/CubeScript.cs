using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    /// <summary>
    /// 버텍스의 정면이 어딘지 지정을 안 해줘서 라이팅이 안 먹힘
    /// 버텍스의 노멀 값이 부여가 안 된 상태
    /// 버텍스 처리 방법 지정해줘야 함
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

        normals = new Vector3[] // 버텍스별로 방향 부여
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
        // 버텍스의 좌표값을 노멀 방향으로 이동
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vert = mesh.vertices;
        Vector3[] nor = mesh.normals;

        for (int i = 0; i < vert.Length; i++)
        {
            vert[i] += nor[i] * Mathf.Sin(Time.time) * speed; // 시간의 Sin 값을 반영 sin의 범위: -1~1
        }

        mesh.vertices = vert;
    }
}
