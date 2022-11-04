using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballVelocity = 20f;
    Rigidbody ball;
    [SerializeField] ParticleSystem particle;
    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.AddForce(transform.forward * ballVelocity, ForceMode.VelocityChange);        
    }
    void OnCollisionEnter(Collision collision)
    {
        var effect = Instantiate(particle, collision.contacts[0].point, Quaternion.Inverse(Quaternion.identity));
        effect.Play();
        Destroy(effect.gameObject, effect.main.duration);
    }
}
