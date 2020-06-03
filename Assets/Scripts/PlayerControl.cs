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
   

    private bool facingRight = true;
    



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bx2 = GetComponent<BoxCollider2D>();
    }

    void movementPlayer()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

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

    private bool isGrounded()
    {
        RaycastHit2D rc2D = Physics2D.BoxCast(bx2.bounds.center, bx2.bounds.size, 0f, Vector2.down * .1f, layerMask);
        return rc2D.collider != null;
    }

    private void Update()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            JumpPlayer();
        }
        movementPlayer();
    }
   

}
