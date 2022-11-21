using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollScript : MonoBehaviour
{
    [SerializeField] GameObject EllenRig;
    [SerializeField] Collider[] ragdollColliders;
    
    [SerializeField] List<Rigidbody> elements;
    private void Start()
    {
        ragdollColliders = EllenRig.GetComponentsInChildren<Collider>();
    }
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
            foreach (Collider col in ragdollColliders)
            {
                col.enabled = true;
            }
        }        
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    GetComponent<Animator>().enabled = false;
    //    GetComponent<Character>().enabled = false;
    //    foreach (var element in elements)
    //    {
    //        element.isKinematic = false; 
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {        
        GetComponent<CapsuleCollider>().enabled = false; 
        GetComponent<Animator>().enabled = false;
        GetComponent<Character>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;            
        }
        foreach (Rigidbody rigid in elements)
        {
            rigid.isKinematic = false;
        }           
    }    
}
