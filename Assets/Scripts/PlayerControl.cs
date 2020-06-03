using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bx2;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float moveInput;

    private Animator anim;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;

    public float checkRadius;
    public LayerMask whatIsGround;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bx2 = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    bool isActiveAnimator()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void movementPlayer()
    {
        moveInput = Input.GetAxis("Horizontal");
        anim.SetBool("isRunning", true) ;
        transform.Translate(transform.right * moveInput * speed * Time.fixedDeltaTime);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void JumpPlayer()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        movementPlayer();
    }
    private void Update()
    {
        if (isActiveAnimator())
        {
            movementPlayer();
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpPlayer();
            }
        }

       
    }
}
