using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballVelocity = 20f;
    Rigidbody ball;
    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.AddForce(transform.forward * ballVelocity, ForceMode.VelocityChange);
    }    
}
