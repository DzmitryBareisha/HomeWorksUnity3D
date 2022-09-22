using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseMove : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public Camera player;
    //public float sensitivity = 5f;
    //public float smothTime = 0.1f;
    //float xRotationCurrent;
    //float yRotationCurrent;
    //float currentVelocityX;
    //float currentVelocityY;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseMover();
    }
    public void MouseMover()
    {
        xRotation += joystick.Horizontal;
        yRotation += joystick.Vertical;

        //xRotationCurrent = Mathf.SmoothDamp(xRotation, xRotationCurrent, ref currentVelocityX, smothTime);
        //yRotationCurrent = Mathf.SmoothDamp(yRotation, yRotationCurrent, ref currentVelocityY, smothTime);
        
        yRotation = Mathf.Clamp(yRotation,-30,30);
        player.transform.rotation = Quaternion.Euler(-yRotation, xRotation, 0f);
        this.gameObject.transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
    }
}
