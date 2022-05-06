using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    // find mover script
    public MoverScript MoverScriptCall;
    private bool playerRay;
    public Vector3 playerPostion;

    public ParticleSystem potionEffect;
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
        /*playerPostion = new Vector3(MoverScriptCall.playerPosition().x - transform.position.x,
            MoverScriptCall.playerPosition().y - transform.position.y,
            MoverScriptCall.playerPosition().z - transform.position.z);
        playerRay = Physics.Raycast(transform.position, playerPostion, 3);*/

        /*if (playerRay == true)
        {
            MoverScriptCall.heal();
            Destroy(this.gameObject);
        }*/
        if (collision.gameObject.name == "player")
        {
            ParticleSystem potionEffect = Instantiate(this.potionEffect);
            potionEffect.transform.position = this.transform.position;
            MoverScriptCall.heal();
            Destroy(this.gameObject);
        }
    }
}
