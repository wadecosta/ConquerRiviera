using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
	Debug.Log("Position is " + pos);

	if(pos.x == 59) 
	{
		pos.x = 69;
		Debug.Log("YOYO");
	}
	if(pos.x == 110) 
	{
		pos.x = 141;
	}
	if(pos.x == 184) 
	{
		pos.x = 222;
	}
    }
}
