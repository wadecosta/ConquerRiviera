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
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            int dartRotation;
            float spawnDistanceX;
            spawnDistanceX = (shooter.position.x - shotSpawn.position.x);
            spawnDistanceX = Math.Abs(spawnDistanceX);
            float spawnDistanceY;
            spawnDistanceY = (shooter.position.y - shotSpawn.position.y);
            spawnDistanceY = Math.Abs(spawnDistanceY);

            if (spawnDistanceX > spawnDistanceY)
            {
                if ((shooter.position.x - shotSpawn.position.x) < 0)
                {
                    dartRotation = 0;
                }
                else
                {
                    dartRotation = 180;
                }
            }
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
            Quaternion rotation = Quaternion.Euler(0, 0, dartRotation);
            
            Transform dartStart = shotSpawn;
            //GameObject dart = Instantiate(this.dart, this.transform);
            GameObject dart = Instantiate(this.dart, Vector3.zero, rotation, this.transform);
            dart.transform.position = dartStart.position;
            Debug.Log("...click");
        }
    }

    public Transform shooterLocation()
    {
        return shooter;
    }

    public Transform spawnLocation()
    {
        return shotSpawn;
    }
    
}
