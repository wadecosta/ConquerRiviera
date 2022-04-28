using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private int health = 100;

    public void takedamage(int damage)
    {
        health -= damage;
        Debug.Log("Player's health is " + health);
    }
}
