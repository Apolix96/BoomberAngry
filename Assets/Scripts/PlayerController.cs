using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    private new Renderer renderer;
    private Color defaultColor;
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
    [SerializeField]
    private Camera camera;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<HeathManager>();
        defaultColor = renderer.material.color;
        
        
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
            other.gameObject.tag = "Untagged";
            Damage(1);
            renderer.material.DOColor(Color.blue,0.2f).OnComplete(test);
        }
        if(other.gameObject.tag == "Heart")
        {
            AddHealth(1);
            Destroy(other.gameObject);
        }
    }


    private void test()
    {
        if(renderer.material!=null)
            renderer.material.DOColor(defaultColor, 0.2f);
    }

    public void Damage(int damage)
    {
        healthManager.healthControl -= damage;
        healthManager.UpdateHealth();
        if (healthManager.healthControl <= 0)
        {
           
            var p = camera.GetComponent<PauseScript>();
            p.Pause();
            p.ReloadPauseGameDestroyObject();
            Destroy(gameObject);
           
        }
    }
    public void AddHealth(int hf)
    {
        healthManager.healthControl += hf;
        healthManager.UpdateHealth();
    }
}
