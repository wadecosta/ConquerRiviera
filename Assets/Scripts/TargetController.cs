using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Transform t;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.position += Vector3.forward * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(jump());
        }
    }

    IEnumerator jump()
    {
        for (int i=0; i<10; i++)
        {
            t.position += Vector3.up * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 10; i++)
        {
            t.position += Vector3.down * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
