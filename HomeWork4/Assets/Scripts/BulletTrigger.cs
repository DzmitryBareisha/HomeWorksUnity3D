using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    void OnTriggerExit (Collider other)
    {        
        Destroy(other.gameObject);               
    }
}
