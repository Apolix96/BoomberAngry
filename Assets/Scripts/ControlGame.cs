﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private int direction;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        if (direction == 0)
            anim.SetBool("isRunning", true);
        else if (direction == 0)
            anim.SetBool("isRunnig", false);
        Flip();
    }
    public void Jump()
    {
        if (ground == true)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            //anim.SetTrigger("Jump");
        }
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
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Stay");
        if (other.gameObject.tag == "ground")
            ground = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        if (other.gameObject.tag == "ground")
            ground = false;
    }
}