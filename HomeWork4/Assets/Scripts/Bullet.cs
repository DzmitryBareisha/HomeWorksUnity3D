using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   Rigidbody bullet;
   private void Start()
   {
       bullet = GetComponent<Rigidbody>(); 
   }
   private void FixedUpdate()
   {
       bullet.AddForce(transform.forward, ForceMode.Impulse);
   }
   void OnCollisionEnter(Collision collision)
   {
       Destroy(gameObject);
   }
}
