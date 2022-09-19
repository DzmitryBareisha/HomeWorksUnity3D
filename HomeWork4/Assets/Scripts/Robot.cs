using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Rigidbody body;
    public float movementSpeed = 5f;
    public float rotateSpeed = 3f;
    public Transform bullet1Pool;
    public Transform bullet2Pool;
    public Transform bullet3Pool;
    int currentBulletIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void FixedUpdate()
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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (body.position.x <= -7 && body.position.z > -20)
            {
                Rigidbody bullet = bullet1Pool.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                bullet.gameObject.SetActive(true);
                bullet.position = transform.position + transform.TransformDirection(Vector3.forward);
                bullet.velocity = Vector3.zero;
                bullet.AddForce(transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                currentBulletIndex++;
                if (currentBulletIndex >= bullet1Pool.childCount)
                {
                    currentBulletIndex = 0;
                }
            }
            if (body.position.x > -7 && body.position.x < 9 && body.position.z > -20)
            {
                Rigidbody bullet = bullet2Pool.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                bullet.gameObject.SetActive(true);
                bullet.position = transform.position + transform.TransformDirection(Vector3.forward);
                bullet.velocity = Vector3.zero;
                bullet.AddForce(transform.TransformDirection(Vector3.forward) * 10f, ForceMode.VelocityChange);
                                
                currentBulletIndex++;
                if (currentBulletIndex >= bullet2Pool.childCount)
                {
                    currentBulletIndex = 0;
                }               
            }
            if (body.position.x >= 9 && body.position.z > -20)
            {
                Rigidbody bullet = bullet3Pool.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                bullet.gameObject.SetActive(true);
                bullet.position = transform.position + transform.TransformDirection(Vector3.forward);
                bullet.velocity = Vector3.zero;
                bullet.AddForce(transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
                currentBulletIndex++;
                if (currentBulletIndex >= bullet3Pool.childCount)
                {
                    currentBulletIndex = 0;
                }
            }   
        }
    }
}
