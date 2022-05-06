using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform character;

    public Transform copy;

    private float cameraCap;
    // Start is called before the first frame update
    void Start()
    {
        copy = character;
       
    }

    // Update is called once per frame
    void Update()
    {
        // get the x position of the character
        Vector3 newPosition = new Vector3(copy.position.x + 8, copy.position.y + 3, transform.position.z);
        transform.position = newPosition;
    }
}