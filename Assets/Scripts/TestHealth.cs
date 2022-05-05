using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * whenever an object has health it should be using code simalar to this
 * some event occurs to change the amount of health of an object
 *  then call either decreaseHealth or IncreaseHealth.
 */
public class TestHealth : MonoBehaviour
{
    private int hitCooldown;
    public GameObject healthUI;
    private static GameObject healthbar;
    private static Vector3 scale;
    private float maxScaleX;
    private Vector3 hbPos;

    private HealthScript h;
    // Start is called before the first frame update
    void Start()
    {
        hitCooldown=50;
        healthbar = healthUI.transform.GetChild(1).gameObject;
        scale =healthbar.transform.localScale;
        maxScaleX = scale.x;
        h= this.gameObject.GetComponent<HealthScript>();
        hbPos = healthbar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKey(KeyCode.RightShift) && hitCooldown<0){
            h.decreaseHealth(5);
            hitCooldown = 50;
            scale.Set(maxScaleX*((float)h.getHealth()/h.getMaxHealth()),scale.y,scale.z); 
            healthbar.transform.localScale=scale;
            healthbar.transform.position= new Vector3((-maxScaleX + scale.x)/2,hbPos.y,hbPos.z);
        }
        
        hitCooldown--;
        
    }
    
    
}
