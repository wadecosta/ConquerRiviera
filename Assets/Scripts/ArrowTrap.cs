using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public float attackCooldown;
    public Transform firePoint;
    public GameObject[] arrows;
    private float cooldownTimer;

    public int other;

    private void Attack()
    {
        cooldownTimer = 0;

        arrows[FindArrows()].transform.position = firePoint.position;
        arrows[FindArrows()].GetComponent<Projectile>().ActivateProjectile();
    }

    private int FindArrows()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (arrows[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}
