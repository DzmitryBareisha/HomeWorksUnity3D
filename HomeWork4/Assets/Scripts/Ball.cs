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
        if (collision.gameObject.CompareTag("Stand3"))
        {
            SoundManager.Instance.PlaySFX("Rebound");
            var effect = Instantiate(particle, collision.contacts[0].point, Quaternion.Inverse(Quaternion.identity));
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }            
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
