using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class AutoGenerate : MonoBehaviour
{
    [SerializeField] private int xSize, ySize;
    private Vector3[] vertices;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }
    void Generate()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //mesh.RecalculateNormals();

        vertices = new Vector3[(xSize+1) * (ySize+1)];
        for (int i = 0, y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                Debug.Log(x + "x");                
            }
            Debug.Log(y + "y");
        }

        mesh.vertices = vertices;

        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = xSize;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = xSize;
        triangles[5] = xSize + 1;

        mesh.triangles = triangles;
    }
}
