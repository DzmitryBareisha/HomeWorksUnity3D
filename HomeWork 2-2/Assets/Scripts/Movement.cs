using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    float defaultSpeed = 1.0f;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();  
        defaultSpeed = agent.speed;
    }
    void Update()
    {
        Move();
        NavMeshHit navhit;
        float speedCoeff = 1.0f;
        if (!agent.SamplePathPosition(NavMesh.AllAreas, 1.0f, out navhit))
        {
            var swampArea = NavMesh.GetAreaFromName("Swamp");
            if ((navhit.mask & (1 << swampArea)) != 0)
            {
                speedCoeff = 0.3f;
            }
            Debug.Log(swampArea);
        }    
        agent.speed = speedCoeff * defaultSpeed;
    }  
    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }            
        }
    }
}
