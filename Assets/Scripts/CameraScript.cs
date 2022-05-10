using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the x position of the character
        Vector3 newPosition = new Vector3(character.position.x, character.position.y, transform.position.z);

        transform.position = newPosition;
    }
}