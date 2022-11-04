using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public GameObject fallingCube;
    [SerializeField] 
    private float moveSpeed = 1f;
    public bool isContact;    
    private void OnEnable()
    {
        if (LastCube == null)
        {
            LastCube = GameObject.Find("StartCube").GetComponent<MovingCube>();
        }
        CurrentCube = this;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
    }
    internal void Stop()
    {
        moveSpeed = 0f;
        float hangover = transform.position.z - LastCube.transform.position.z;       
        float direction = hangover > 0 ? 1f : -1f;
        SplitCubeOnZ(hangover, direction);
        LastCube = this;
    }
    private void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;
        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
        float cubeEdge = transform.position.z + (newZSize / 2 * direction);
        float fallingBlockZPosition = cubeEdge + (fallingBlockSize / 2 * direction);
        
        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }
    void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {        
        GameObject cube = Instantiate(fallingCube);
        cube.transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3 (transform.position.x, transform.position.y, fallingBlockZPosition);
        cube.AddComponent<Rigidbody>();
        Destroy (cube.gameObject, 1f);
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (transform.position.z > 2.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        }
        CheckDistance();        
    }
    public bool CheckDistance()
    {
        if (Mathf.Abs(transform.position.z - LastCube.transform.position.z) >= LastCube.transform.localScale.z)
        { 
            isContact = false; 
        }
        else
        {
            isContact = true;
        }        
        return isContact;
    }
}
