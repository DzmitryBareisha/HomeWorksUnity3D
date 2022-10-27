using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<CubeSpawner>().SpawnCube();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MovingCube.CurrentCube != null && MovingCube.CurrentCube.isContact)
            {
                MovingCube.CurrentCube.Stop();                
                FindObjectOfType<CubeSpawner>().SpawnCube();
            }            
        }
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (MovingCube.CurrentCube != null && MovingCube.CurrentCube.isContact)
                {
                    MovingCube.CurrentCube.Stop();
                    FindObjectOfType<CubeSpawner>().SpawnCube();
                }
            }
        }
    }
}
