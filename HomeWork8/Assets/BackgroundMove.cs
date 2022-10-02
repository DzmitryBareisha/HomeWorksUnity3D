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
        //ninja = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ninjaflipX = !ninjaflipX;            
        }
        if (ninjaflipX == true)
        {
            newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);
            transform.position = startPosition + Vector2.right * newXposition;
        }
        if (!ninjaflipX)
        {
            newXposition = Mathf.Repeat(Time.time * moveSpeed, offset);
            transform.position = startPosition + Vector2.right * newXposition;
        }
    }
}
