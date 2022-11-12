using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollScript : MonoBehaviour
{
    public List<Rigidbody> elements;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent <Animator>().enabled = false;
            GetComponent<Character>().enabled = false;
            foreach (var element in elements)
            {
                element.isKinematic = false;
            }            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Character>().enabled = false;
        foreach (var element in elements)
        {
            element.isKinematic = false;              
            //element.AddForce(other.transform.position, ForceMode.Force);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    collision.rigidbody.AddForce(transform.position, ForceMode.Force);
    //}
}
