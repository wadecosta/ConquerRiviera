using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DartScript : MonoBehaviour
{
    [FormerlySerializedAs("ParentScript")] public PressurePlateScript parentScript;
    
    private Rigidbody myRigidBody;
    public float speed = 5;
    public int damage = 1;
    public MoverScript MoverScriptCall;
    // Start is called before the first frame update
    void Start()
    {
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
        parentScript = transform.parent.GetComponent<PressurePlateScript>();
        myRigidBody = GetComponent<Rigidbody>();
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        // get the spawn locations from the parent
        Vector3 shooterLocation = new Vector3(parentScript.shooterLocation().position.x, 
            parentScript.shooterLocation().position.y, parentScript.shooterLocation().position.z);
        
        Vector3 spawnLocation = new Vector3(parentScript.spawnLocation().position.x, 
            parentScript.spawnLocation().position.y, parentScript.spawnLocation().position.z);

        // calculate what direction the arrow should be going in
        //Vector3 shotDirection = spawnLocation - shooterLocation;
        float shotDirectionX = Math.Abs(spawnLocation.x - shooterLocation.x);
        float shotDirectionY = Math.Abs(spawnLocation.y - shooterLocation.y);
        //Vector3 shotDirection = shooterLocation - spawnLocation;
        //shotDirection.Normalize();

        if (shotDirectionX > shotDirectionY)
        {
            if (spawnLocation.x - shooterLocation.x < 0)
            {
                myRigidBody.velocity = Vector3.left * speed;
            }
            else
            {
                myRigidBody.velocity = Vector3.right * speed;
            }
        }
        else
        {
            myRigidBody.velocity = Vector3.down * speed;
        }
        //myRigidBody.velocity = shotDirection * speed;
        Debug.Log(myRigidBody.velocity);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            MoverScriptCall.hit(damage);
        }
        Destroy(this.gameObject);
    }
}
