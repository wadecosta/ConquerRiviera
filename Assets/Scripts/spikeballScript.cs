using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeballScript : MonoBehaviour
{
    public int damage = 10;
    public MoverScript MoverScriptCall;
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
        // if it hits the player hurt the player
        if (collision.gameObject.name == "player")
        {
            MoverScriptCall.hit(damage);
        }
    }
}
