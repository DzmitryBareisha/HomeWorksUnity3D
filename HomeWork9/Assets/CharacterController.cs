using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 10f;
    private float moveInput;
    private bool isFacingRight = true;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator animator;
    public Rigidbody2D Rb { get { return rb = rb ?? GetComponent<Rigidbody2D>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }
    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Rb.velocity = new Vector2 (moveInput * speed, Rb.velocity.y);
        if (isFacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (isFacingRight == true && moveInput < 0)  
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Rb.velocity = Vector2.up * jumpSpeed;
        }
        if (moveInput == 0)
        {
            CharacterAnimator.SetBool("Run", false);
        }
        else
        {
            CharacterAnimator.SetBool("Run", true);
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
