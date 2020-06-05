using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBomb : MonoBehaviour
{
    private ControlGame player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlGame>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
        }
    }
}
