using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Rigidbody body;
    public float movementSpeed = 5f;
    public float rotateSpeed = 3f;
    
    public GameObject shell;
    [SerializeField] private GameObject bullet, grenade, ball;
    [SerializeField] private Collider stand1, stand2,stand3;
    
    void Start()
    {
       body = GetComponent<Rigidbody>();
       shell = grenade;
    }

    // Update is called once per frame
    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotateSpeed;
        if (sideForce != 0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }
        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == stand1)
        {
            shell = bullet;
        }
        if (other == stand2)
        {
            shell = grenade;
        }
        if (other == stand3)
        {
            shell = ball;
        }
    }    
}
