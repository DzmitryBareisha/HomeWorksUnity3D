using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    float radius = 10;
    float force = 1000;
    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);        
    }
    public void OnCollisionEnter(Collision other)
    {
       if (other.transform.CompareTag("Stand2"))
       {
            Explode();
       }
        
    }
}
