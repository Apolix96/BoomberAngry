using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;
    private ControlGame player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlGame>();
    }

    private void Update()
    {
        
    }
}
