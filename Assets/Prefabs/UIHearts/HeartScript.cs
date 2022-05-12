using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    // tracks hearts
    public int health;
    
    // max hearts
    public int numHearts;

    // array to hold the images for UI hearts
    public Image[] hearts;
    public Sprite healthyHeart;
    public Sprite hurtHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numHearts)
        {
            health = numHearts;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            // display healthy or hurt hearts
            if (i < health)
            {
                hearts[i].sprite = healthyHeart;
            }
            else
            {
                hearts[i].sprite = hurtHeart;
            }
            
            
            // show the correct number of hearts
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void gainHealth()
    {
        health += 2;
        if (health > numHearts)
        {
            health = numHearts;
        }
    }

    public void loseHealth(int damage)
    {
        health -= damage;
    }
}
