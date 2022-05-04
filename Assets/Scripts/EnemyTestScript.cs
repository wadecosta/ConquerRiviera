using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{
    public GameObject fistPrefab;
    public GameObject batPrefab;
    public GameObject spearPrefab;
    public GameObject bowPrefab;
    public GameObject player;
    
    public MoverScript MoverScriptCall;
    
    private Rigidbody body;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            float dist = Vector3.Distance(this.transform.position, player.transform.position);

            
            Debug.Log(MoverScriptCall.currentWeaponCounter);

            float weaponForce = 0f;

            if (MoverScriptCall.currentWeaponCounter == 0)
            {
                weaponForce = 3f;
                damage = 1;
            }

            if (MoverScriptCall.currentWeaponCounter == 1)
            {
                weaponForce = 18f;
                damage = 3;
            }

            if (MoverScriptCall.currentWeaponCounter == 2)
            {
                weaponForce = 10f;
                damage = 3;
            }

            if (MoverScriptCall.currentWeaponCounter == 3)
            {
                weaponForce = 5f;
                damage = 2;
            }

            print("Distance to other: " + dist);
            if (dist < 3)
            {
                body.AddForce(Vector3.up * weaponForce, ForceMode.Impulse);
            }
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.name == "BatPrefab(Clone)")
        {
            body.AddForce(Vector3.up * 24, ForceMode.Impulse);
        }*/
        Debug.Log("Oh Dear, I've been struck!");
    }
}
