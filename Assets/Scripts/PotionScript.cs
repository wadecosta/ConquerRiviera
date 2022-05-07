using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    // find mover script
    public MoverScript MoverScriptCall;
    private bool playerRay;


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
        if (collision.gameObject.name == "player")
        {
            ParticleSystem potionEffect = Instantiate(this.potionEffect);
            potionEffect.transform.position = this.transform.position;
            MoverScriptCall.heal();
            Destroy(this.gameObject);
        }
    }
}
