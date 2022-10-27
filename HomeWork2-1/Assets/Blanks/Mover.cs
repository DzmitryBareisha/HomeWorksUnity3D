using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 endPosition;
    
    public float speed = 0.1f;
    public float counter;    
    void Start()
    {        
        //direction = Vector3.right;        
        counter = 0;
        startPosition = new Vector2(-5, transform.position.y);
        endPosition = new Vector2(5, transform.position.y);        
    }

    void Update()
    {        
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            //startPosition = endPosition = transform.position;
            speed = 0;
        }
        counter += Time.deltaTime * speed;
        transform.position = Vector2.Lerp(startPosition, endPosition, Mathf.PingPong(counter, 1f));
    }
}
