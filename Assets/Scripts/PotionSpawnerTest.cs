    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerTest : MonoBehaviour
{
    public Transform potionSpawner;
    public GameObject potion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Transform potionLoction = potionSpawner;
            GameObject potion = Instantiate(this.potion);
            potion.transform.position = potionLoction.position;
        }
    }
}
