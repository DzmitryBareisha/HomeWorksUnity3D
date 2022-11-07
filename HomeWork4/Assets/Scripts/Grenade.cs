using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float radius = 10;
    float force = 1000;
    [SerializeField] private float throwForce = 15f;
    Rigidbody grenade;
    [SerializeField] ParticleSystem particle;
    private void Start()
    {
        grenade = GetComponent<Rigidbody>();       
        grenade.AddForce((transform.forward + transform.up) * throwForce, ForceMode.VelocityChange);
    }
        
    public void OnCollisionEnter(Collision collision)
    {        
        Explode();
        var effect = Instantiate(particle, collision.contacts[0].point, Quaternion.Inverse(Quaternion.identity));
        effect.Play();
        Destroy(effect.gameObject, effect.main.duration);
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider overlappedColliders in colliders)
        {
            Rigidbody rigidbody = overlappedColliders.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
