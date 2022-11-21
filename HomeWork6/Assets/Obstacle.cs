using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public CharacterController ellenCollider;

    private void Start()
    {
        ellenCollider = GetComponent<CharacterController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (ellenCollider != null)
        { 
        Debug.Log(ellenCollider);
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*20, ForceMode.Acceleration);
        Debug.Log(collision.gameObject.name);
        //Debug.Log(collision.contacts[0].point.normalized);
        //contact = collision.GetContact(0);
        //Debug.Log(contact);
        //Vector3 vector = collision.GetContact(0).otherCollider.GetComponent<Vector3>();
        }
    }
}
