using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float offset = 9.28f;
    private Vector2 startPosition;
    private float newXposition;
    private bool ninjaflipX = true;
    private void Start()
    {
        startPosition = transform.position;        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            ninjaflipX = !ninjaflipX;
            moveSpeed *= -1f;
        }
        Turn();        
    }
    private void Turn() 
    {
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPosition + Vector2.right * newXposition;
    }
}
