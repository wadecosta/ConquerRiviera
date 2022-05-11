using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    // find mover script
    public MoverScript MoverScriptCall;
    private bool playerRay;

    // find the spawn location for shooter
    public Transform shooter;
    public Transform shotSpawn;
    public GameObject dart;
    // Start is called before the first frame update
    void Start()
    {
        // find the player script
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // if the player steps on the plate
        if (collision.gameObject.name == "player")
        {
            // set the rotation of the dart
            int dartRotation;
            
            // find the x and y distances of the two points
            float spawnDistanceX;
            spawnDistanceX = (shooter.position.x - shotSpawn.position.x);
            spawnDistanceX = Math.Abs(spawnDistanceX);
            float spawnDistanceY;
            spawnDistanceY = (shooter.position.y - shotSpawn.position.y);
            spawnDistanceY = Math.Abs(spawnDistanceY);

            // if the x is greater the dart will face left or right
            if (spawnDistanceX > spawnDistanceY)
            {
                if ((shooter.position.x - shotSpawn.position.x) < 0)
                {
                    dartRotation = 180;
                }
                else
                {
                    dartRotation = 0;
                }
            }
            
            // else the dart will face up or down
            else
            {
                if ((shooter.position.y - shotSpawn.position.y) < 0)
                {
                    dartRotation = 270;
                }
                else
                {
                    dartRotation = 90;
                }
            }
            // sets degree rotation to quaternion
            Quaternion rotation = Quaternion.Euler(0, 0, dartRotation);
            
            Transform dartStart = shotSpawn;
            //GameObject dart = Instantiate(object, object position, quarternion rotation, parent);
            GameObject dart = Instantiate(this.dart, Vector3.zero, rotation, this.transform);
            dart.transform.position = dartStart.position;
        }
    }

    // return the two positions for the dart
    public Transform shooterLocation()
    {
        return shooter;
    }

    public Transform spawnLocation()
    {
        return shotSpawn;
    }
    
}
