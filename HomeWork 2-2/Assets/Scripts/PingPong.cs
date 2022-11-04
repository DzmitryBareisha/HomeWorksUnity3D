using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;    
    private Vector3 fromPoint;
    private Vector3 toPoint;    
    private void Start()
    {
        fromPoint = transform.position;
        toPoint = new Vector3(transform.position.x, transform.position.y, 10);        
    }
    void Update()
    {        
        transform.position = Vector3.Lerp(fromPoint, toPoint, Mathf.PingPong(Time.time * speed, 1f));
    }
}
