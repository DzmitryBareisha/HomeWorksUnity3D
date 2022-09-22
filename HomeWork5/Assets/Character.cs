using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float gravity = -9.8f;
    public float speed = 3.0f;
    private float jumpForce = 5f;
        
    private CharacterController controller;
    public Joystick joystick;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    void Update()
    {
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;


        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);            
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);              
               
    }    
}
   
