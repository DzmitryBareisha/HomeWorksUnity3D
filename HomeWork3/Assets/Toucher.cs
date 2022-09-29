using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucher : MonoBehaviour
{
       
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        Touch screenTouch = Input.GetTouch(0);
        if (screenTouch.phase == TouchPhase.Moved)
        {
            transform.Rotate(0f, -screenTouch.deltaPosition.x / 8, 0F);
        }      
    }
}
