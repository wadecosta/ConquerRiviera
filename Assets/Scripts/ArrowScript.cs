using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Rigidbody myRigidBody;
    public float speed = 2;
    public float direction;

    public float damage = 1f;
    
    
    // find the player script
    public GameObject player;
    public MoverScript MoverScriptCall;
    
    // Start is called before the first frame update
    void Start()
    {
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
        myRigidBody = GetComponent<Rigidbody>();
        Debug.Log("Arrow Spawned");
        Fire();
    }
    
    private void Fire()
    {
        if (MoverScriptCall.playerRotation() < 0)
        {
            myRigidBody.velocity = Vector3.left * speed;
        }

        else
        {
            myRigidBody.velocity = Vector3.right * speed;
        }

        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Arrow Destroyed");
        Destroy(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
