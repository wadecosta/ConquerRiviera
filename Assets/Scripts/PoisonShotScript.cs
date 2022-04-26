using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShotScript : MonoBehaviour
{

    public Transform t;
    public float speed;
    public float lifetime;

    public float targetHeight;
    public float targetDirection;

    public GameObject poisonPuddle;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        t.position = t.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            end();

        t.position += Vector3.forward * targetDirection * speed * Time.deltaTime;

        float heightDiff = targetHeight - t.position.y;
        heightDiff = heightDiff / Mathf.Abs(heightDiff);
        t.position += Vector3.up * speed * 0.5f * heightDiff * Time.deltaTime;

    }
    public void setTarget(Transform target)
    {
        targetHeight = target.position.y;
        targetDirection = target.position.z - t.position.z;
        targetDirection = targetDirection / Mathf.Abs(targetDirection);
    }

    public void end()
    {
        GameObject p = GameObject.Instantiate(poisonPuddle);
        p.transform.position = t.position;
        //raycast down?
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("ouch");
        Destroy(this.gameObject);
    }
}
