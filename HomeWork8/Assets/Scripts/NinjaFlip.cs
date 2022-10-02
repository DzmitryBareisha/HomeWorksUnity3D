using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFlip : MonoBehaviour
{
    //public float speed = 0.1f;
    private SpriteRenderer ninja;
    //private Vector2 direction = new Vector2 (1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        ninja = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Translate (direction * speed * Time.deltaTime); 
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            ninja.flipX = !ninja.flipX;
            //direction = -direction;            
        }        
        if (Input.touchCount > 0)
        {
            ninja.flipX = !ninja.flipX;
        }
    }
}
