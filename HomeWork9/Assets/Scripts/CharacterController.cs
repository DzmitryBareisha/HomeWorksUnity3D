using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{     
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    private float jumpForce = 7.0f;
    public bool isGrounded = false;
        
    private new Rigidbody2D rigidbody;
    public Vector2 direction;
    private Animator animator;
    private SpriteRenderer sprite;
    public Rigidbody2D Rigidbody { get { return rigidbody = rigidbody ?? GetComponent<Rigidbody2D>(); } }
    public Animator CharAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer Sprite { get { return sprite = sprite ?? GetComponentInChildren<SpriteRenderer>(); } }
    private CharState State
    {
        get { return (CharState)CharAnimator.GetInteger("State"); }
        set { CharAnimator.SetInteger("State", (int)value); }
    }

    // Start is called before the first frame update
    void Start()
    {               
    }

    private void FixedUpdate() 
    { 
        CheckGround();
    }
    // Update is called once per frame
    void Update()
    {   if (!CharAnimator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (isGrounded)
            {
                State = CharState.Idle;
            }

            if (Input.GetButton("Horizontal"))
            {
                Run();
            }
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }
    private void Run()
    {
        direction.x = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector2(direction.x * speed, Rigidbody.velocity.y);
        
        Sprite.flipX = direction.x < 0f;
        if (isGrounded)
        {
            State = CharState.Run;
        }
    }
    private void Jump()
    {
        Rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);        
    }
    private void CheckGround() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        isGrounded = colliders.Length > 1;       
        if (!isGrounded)
        {
            State = CharState.Jump;
        }
    }
    public virtual void RecieveDamage()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        Die();
    }
    public virtual void Die()
    {        
        Destroy(gameObject);
        LevelManager.instance.Respawn();
    }
}
public enum CharState
{
    Idle,
    Run,
    Jump
}
