using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public CapsuleCollider mainCollider;
    public GameObject ThisGuysRig;
    public Animator ThisGuysAnimator;

    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            RagdollModeOn();
        }
    }
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits()
    {
        ragdollColliders = ThisGuysRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThisGuysRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    {
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        ThisGuysAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
