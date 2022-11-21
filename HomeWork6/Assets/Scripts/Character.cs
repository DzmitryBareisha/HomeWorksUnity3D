using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float sprintSpeed = 5.0f;
    public float rotationSpeed = 0.2f;
    public float animationBlendSpeed = 0.2f;
    public float jumpSpeed = 7.0f;

    CharacterController controller;
    Animator animator;
    Camera characterCamera;
    [SerializeField] GameObject TimelineDeath;
    [SerializeField] Transform transf;
    [SerializeField] Camera thirdCam;
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0.0f;
    bool isSprint = false;

    float speedY = 0.0f;
    float gravity = -9.81f;
    bool isJumping = false;
    bool isAttacking = false;    
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }
        
    private void Start()
    {       
        CharacterAnimator.SetTrigger("Spawn");       
    }
    
    void Update()
    {
        if (!CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") && !CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                Death();                
            }
            if (Input.GetMouseButtonDown(0) && !isJumping && !isAttacking)            
            {
                Fight();
            }
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                Jump();
            }
            IsGrounded();
            
            CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
            if (isJumping && speedY < 0.0f)
            {
                Landing();
            }

            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;

            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;

            Controller.Move((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);
            if (rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0.0f;
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
        }
    }  
    void Death()
    {
        CharacterAnimator.SetTrigger("Death");
        thirdCam.transform.position = transf.transform.position;
        thirdCam.transform.rotation = transf.rotation;
        TimelineDeath.SetActive(true);
    }
    void Fight()
    {
        isAttacking = true;
        CharacterAnimator.SetInteger("KickIndex", Random.Range(0, 6));
        CharacterAnimator.SetTrigger("Kicks");
        isAttacking = false;
    }
    void Jump()
    {
        isJumping = true;
        CharacterAnimator.SetTrigger("Jump");
        speedY += jumpSpeed;
    }
    void IsGrounded()
    {
        if (!Controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0.0f)
        {
            speedY = 0.0f;
        }
    }
    void Landing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
        {
            isJumping = false;
            CharacterAnimator.SetTrigger("Land");
        }
    }
}
