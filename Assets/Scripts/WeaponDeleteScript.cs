using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDeleteScript : MonoBehaviour
{
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteThis()
    {
        Destroy(this.gameObject);
    }
}
