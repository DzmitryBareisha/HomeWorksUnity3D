using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private bool isCollided;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(isCollided);
        if (!isCollided)
        {
            Destroy(gameObject, 1.0f);
        }
        //isCollided = true;
    }
}
