using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
        }
    }
}
