using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody bullet;
    [SerializeField] ParticleSystem particle;
    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
        var effect = Instantiate(particle, transform.position, transform.rotation);
        effect.Play();
        Destroy(effect.gameObject, 0.1f);
    }
   private void FixedUpdate()
   {
       bullet.AddForce(transform.forward * speed, ForceMode.VelocityChange);
   }
   void OnCollisionEnter(Collision collision)
   {
        Destroy(gameObject);        
    }
}
