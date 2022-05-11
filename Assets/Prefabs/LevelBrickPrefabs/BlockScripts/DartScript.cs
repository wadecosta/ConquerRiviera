using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DartScript : MonoBehaviour
{
    // gets script from parent
    [FormerlySerializedAs("ParentScript")] public PressurePlateScript parentScript;
    
    private Rigidbody myRigidBody;
    public float speed = 8;
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


        // find the X and Y differences between the two points
        float shotDirectionX = Math.Abs(spawnLocation.x - shooterLocation.x);
        float shotDirectionY = Math.Abs(spawnLocation.y - shooterLocation.y);


        // find out which difference is the greatest
        if (shotDirectionX > shotDirectionY)
        {
            // if the dart should go in the negative direction
            if (spawnLocation.x - shooterLocation.x < 0)
            {
                myRigidBody.velocity = Vector3.left * speed;
            }
            // else go right
            else
            {
                myRigidBody.velocity = Vector3.right * speed;
            }
        }
        // darts will only go down not up
        else
        {
            myRigidBody.velocity = Vector3.down * speed;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // if it hits the player hurt the player
        if (collision.gameObject.name == "player")
        {
            MoverScriptCall.hit(damage);
        }
        Destroy(this.gameObject);
    }
}
