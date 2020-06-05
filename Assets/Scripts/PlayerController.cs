using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    private Animator anim;
    float speedX;
    public float JumpImpulse;
    Rigidbody2D rb;
    [SerializeField]
    bool isGrounded;
    [SerializeField] private int direction;
    // Start is called before the first frame update

    // отнятие здоровья
    private HeathManager healthManager;
    private BombController bomich;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<HeathManager>();
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


        direction = buttonDirection;
    }
    private void Flip()
    {
        if (direction > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (direction < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "ground")
            isGrounded= true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "ground")
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Damage(1);

        }

    }


    public void Damage(int damage)
    {
        
        healthManager.healthControl -= damage;
        healthManager.UpdateHealth();
        if (healthManager.healthControl <= 0)
        {
            Destroy(gameObject);
        }
    }
}
