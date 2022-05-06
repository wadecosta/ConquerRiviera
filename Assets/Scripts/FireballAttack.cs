using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    public GameObject fireball;

    public GameObject player;
    // Start is called before the first frame update
    public float elapsedTime = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireball.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5f && fireball != null)
        {
           Destroy(fireball);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.name == "player")
        {
            Hit();
        }
    }

    private void Hit()
    {
        Debug.Log("Player got hit by a Fireball!!!");
        Destroy(fireball);
    }
}
