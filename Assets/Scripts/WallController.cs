using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject iguana;
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (iguana.GetComponent<SnakeScript>().health <= 0)
        {
            if (iguana.gameObject.name.Equals("1Iguana"))
            {
                GameObject.Find("Level1").SetActive(false);
            }
            if (iguana.gameObject.name.Equals("2Iguana"))
            {
                GameObject.Find("Level2").SetActive(false);
            }
            if (iguana.gameObject.name.Equals("3Iguana"))
            {
                GameObject.Find("Level3").SetActive(false);
            }
            if (iguana.gameObject.name.Equals("4Iguana"))
            {
                GameObject.Find("Level4").SetActive(false);
            }
            if (iguana.gameObject.name.Equals("5Iguana"))
            {
                GameObject.Find("Level5").SetActive(false);
            }
        }
    }
}
