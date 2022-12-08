using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTest : MonoBehaviour
{
    //public Robot robot;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            var particle = FindObjectOfType<BulletTest>();
            if (particle != null)
            {
                particle.ParticlePlay();
            }            
        }
    }
    void Fire()
    {
        GameObject bullet = BulletManager.Instance.GetPooledObject();
        if (bullet != null)
        {            
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.GetComponent<Rigidbody>().isKinematic = false;            
            bullet.SetActive(true);
            SoundManager.Instance.PlaySFX("Shot");            
        }
    }
}
