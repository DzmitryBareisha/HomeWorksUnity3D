using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GamePlate : MonoBehaviour
{
    [SerializeField] private int xSize, ySize, zSize;
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
        SetVertices();        
    }
    private void SetVertices()
    {
        var cornerCount = 8;
        var edgeCount = (xSize + ySize + zSize - 3) * 4;
        var faceCount = (xSize - 1) * (ySize - 1) + (xSize - 1) * (zSize - 1) + (ySize - 1) * (zSize - 1);
        faceCount *= 2;
        vertices = new Vector3[cornerCount + edgeCount + faceCount];
        var v = 0;
        for (int y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[v++] = new Vector3(x, y, 0); 
            }
            for (int z = 1; z <= zSize; z++)
            {
                vertices[v++] = new Vector3(xSize, y, z); 
            }
            for (int x = xSize - 1; x >= 0; x--) 
            {
                vertices[v++] = new Vector3(x, y, zSize);
            }
            for (int z = zSize - 1; z < 0; z--) 
            {
                vertices[v++] = new Vector3(0, y, z);
            }
        }
        for (int x = 1; x< xSize; x++) 
        {
            for (int z = 1; z < zSize; z++)
            {
                vertices[v++] = new Vector3(x, ySize, z);
                vertices[v++] = new Vector3(x, 0, z);
            }
        }
        mesh.vertices = vertices; 
        
    }
    private void SetTriangles()
    {
        var cellCount = xSize*ySize + xSize*zSize + ySize*zSize;
        cellCount *= 2;
        var triangles = new int[cellCount * 6];
        var loop = (xSize + ySize) * 2;
        //int ti = 0, vi = 0;
    }
}
