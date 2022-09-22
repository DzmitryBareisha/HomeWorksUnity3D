using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 0.2f;
    CharacterController controller;
    Camera characterCamera;
    float rotationAngle = 0.0f;

    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }
    public Camera CharacterrCamera
    {
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        Debug.Log(movement);
        Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterrCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
        Controller.Move(rotatedMovement * movementSpeed * Time.deltaTime);
        if (rotatedMovement.sqrMagnitude > 0.0f)
        {
            rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
        }
        Quaternion currentRotation = Controller.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
        Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);

    }
}
