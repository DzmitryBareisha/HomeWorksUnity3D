using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
    }

    Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {            
            new Vector3(-0.5f, -0.5f, 0.5f),//0
            new Vector3( 0.5f, -0.5f,  0.5f),//1
            new Vector3(-0.5f, -0.5f, -0.5f),//2
            new Vector3( 0.5f, -0.5f, -0.5f),//3
            new Vector3(-0.5f,  0.5f, -0.5f),//4
            new Vector3(-0.5f,  0.5f,  0.5f),//5
            new Vector3( 0.5f,  0.5f,  0.5f),//6
            new Vector3( 0.5f,  0.5f, -0.5f),//7
        };
    }
    int[] GenerateTriangles()
    {
        return new int[] 
        {
            0, 2, 1,
            1, 2, 3,
            2, 4, 3,
            4, 7, 3,
            4, 5, 6,
            4, 6, 7,
            3, 7, 1,
            1, 7, 6,
            2, 0, 5,
            5, 4, 2,
            1, 6, 0,
            0, 6, 5,
        };
    }
}
