using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathManager : MonoBehaviour
{
    public int healthControl;
    private int maxHealth;
    [SerializeField] private Image [ ] healthImage;
    [SerializeField] private Sprite [ ] healthSprite;

    private void Start()
    {
        maxHealth = healthControl;
    }

    public void UpdateHealth()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            if (i < healthControl)
                healthImage[i].sprite = healthSprite[0];
            else
                healthImage[i].sprite = healthSprite[1];
        }
    }
}
