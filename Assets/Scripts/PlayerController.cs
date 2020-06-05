using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    [SerializeField]
    private Animator anim;
    float speedX;
    public float JumpImpulse;
    Rigidbody2D rb;
    [SerializeField]
    bool isGrounded;
    [SerializeField] private int direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Walk()
    {
        speedX = horizontalSpeed;
        anim.SetBool("isRunning", true);
    }
    

    public void OnClickJump()
    {
        if(isGrounded)
            rb.AddForce(new Vector2(0, JumpImpulse), ForceMode2D.Impulse);
    }

   public void Stop()
   {
        speedX = 0;
        anim.SetBool("isRunning", false);
    }

    void FixedUpdate()
    {
       
        transform.Translate(speedX, 0, 0);
       
        Flip();
    }

    public void ChangeDirection(int buttonDirection)
    {
        print("DIRECTION: " + direction);
        direction = buttonDirection;
    }
    private void Flip()
    {
        if (direction > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (direction < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
