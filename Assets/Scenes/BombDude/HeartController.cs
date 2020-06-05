using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        int force = Random.Range(3, 15);
        rb2D.AddForce(transform.right * -force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
