using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFlip : MonoBehaviour
{
    private SpriteRenderer ninja;
    // Start is called before the first frame update
    void Start()
    {
        ninja = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            ninja.flipX = !ninja.flipX; 
        }        
    }
}
