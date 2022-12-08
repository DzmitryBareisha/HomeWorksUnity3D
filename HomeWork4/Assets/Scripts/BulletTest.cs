using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody bullet;
    [SerializeField] ParticleSystem particle;
    private void Start()
    {        
        bullet = GetComponent<Rigidbody>();        
    }
    private void FixedUpdate()
    {            
        bullet.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stand1")) 
        {
            SoundManager.Instance.PlaySFX("Hit");
        }        
        var trail = bullet.GetComponent<TrailRenderer>();
        trail.Clear();
        gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;      
    }
    public void ParticlePlay()
    {
        var effect = Instantiate(particle, transform.position, transform.rotation);
        effect.Play();
        Destroy(effect.gameObject, 0.1f);
    }
}
