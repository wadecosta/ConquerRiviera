using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{
    public GameObject player;
    private int damage;
    public MoverScript MoverScriptCall;
    private bool playerRay;
    public Vector3 playerPostion;
    
    // Start is called before the first frame update
    void Start()
    {
        
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //playerPostion = new Vector3(MoverScriptCall.playerPosition().x, MoverScriptCall.playerPosition().y, MoverScriptCall.playerPosition().z);
            playerPostion = new Vector3(MoverScriptCall.playerPosition().x - transform.position.x,
                MoverScriptCall.playerPosition().y - transform.position.y,
                MoverScriptCall.playerPosition().z - transform.position.z);
            playerRay = Physics.Raycast(transform.position, playerPostion, 10);

            if (playerRay == true)
            {
                damage = MoverScriptCall.DamageAmount();
                Debug.Log("Oh Dear, I've been struck for " + damage + " damage!");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log("Oh Dear, I've been struck!");
    }
}
