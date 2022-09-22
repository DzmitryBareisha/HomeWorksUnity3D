using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    //public float gravity = 9.8f;
    public float speed = 5.0f;
    private float jumpForce = 5f;
    private float verticalSpeed = -1f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public Joystick joystick;

    //public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3 (joystick.Horizontal, 0, joystick.Vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        verticalSpeed -= 9.81f * Time.deltaTime;
        moveDirection.y = verticalSpeed;
        controller.Move(moveDirection * Time.deltaTime);

    }
    public void PlayerJump()
    {
        if (controller.isGrounded)
        {
            verticalSpeed = jumpForce;
        }
    }
}
