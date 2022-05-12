using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskEnablerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject mask;
    // Start is called before the first frame update
    void Start()
    {
        mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            mask.SetActive(true);
        }

    }
}
