using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MovingCube cubePrefab;
    private void Start()
    {
        SpawnCube();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MovingCube.CurrentCube != null && MovingCube.CurrentCube.isContact)
            {
                MovingCube.CurrentCube.Stop();
                SpawnCube();
            }            
        }
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (MovingCube.CurrentCube != null && MovingCube.CurrentCube.isContact)
                {
                    MovingCube.CurrentCube.Stop();
                    SpawnCube();
                }
            }
        }
    }
    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        if (MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("StartCube"))
        {
            cube.transform.position = new Vector3(transform.position.x,
                MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y,
                transform.position.z);
        }
    }
}
