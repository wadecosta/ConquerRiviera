using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class HealthScript : MonoBehaviour{
    
    private int health;
    public int MAXHEALTH;
    

    public void  decreaseHealth(int dam){
        health -= dam;
        if (health<0){
            health = 0;
        }
    }

    void increaseHealth(int heal){
        health += heal;

        if (health>MAXHEALTH){
            health = MAXHEALTH;
        }
    }

    public int getHealth(){
        return health;
    }

    public int getMaxHealth(){
        return MAXHEALTH;
    }
    

    // Start is called before the first frame update
    void Start(){
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update()
    {

        if (health<=0){
            Destroy(this.gameObject);
            
            //Some code should be here to handle the case when the player dies
            
        }
        
    }
}
