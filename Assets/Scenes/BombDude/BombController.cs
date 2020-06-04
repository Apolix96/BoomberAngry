﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private new Renderer renderer;
    [SerializeField]
    private float destroyTime;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer, true);
        int force = Random.Range(3,15);
        rb2D.AddForce(transform.right * -force, ForceMode2D.Impulse);
        renderer = gameObject.GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, destroyTime);
        renderer.material.DOColor(Color.red, destroyTime);
    }
}