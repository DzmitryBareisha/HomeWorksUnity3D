using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 0.2f;
    public float rotation;
    public float angle;

    CharacterController controller;
    public Camera camera;
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
        
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
                       
        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);                        
        Controller.Move(transform.TransformDirection(movement));

        rotation += Input.GetAxis("Mouse X");
        angle += Input.GetAxis("Mouse Y");

        angle = Mathf.Clamp(angle, -30, 30);
        camera.transform.rotation = Quaternion.Euler(-angle,rotation, 0f);
        this.gameObject.transform.rotation = Quaternion.Euler(0f, rotation, 0f);

    }
}
