using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShotScript : MonoBehaviour
{

    public Transform t;
    public float speed;
    public float lifetime;

    public GameObject target;
    public float targetHeight;
    public float targetDirection;

    public GameObject poisonPuddle;
    public GameObject mommy;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        t.position += Vector3.up * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            end();

        t.position += Vector3.left * targetDirection * speed * Time.deltaTime;

        float heightDiff = targetHeight - t.position.y;
        //heightDiff = heightDiff / Mathf.Abs(heightDiff);
        t.position += (Vector3.up * heightDiff).normalized * Time.deltaTime * speed * 0.5f;

    }
    public void setTargetAndMom(GameObject newTarget, GameObject newMommy)
    {
        mommy = newMommy;
        target = newTarget;
        targetHeight = target.transform.position.y + 0.75f;
        targetDirection = target.transform.position.x - t.position.x;
        targetDirection =  - targetDirection / Mathf.Abs(targetDirection);
        if (targetDirection > 0)
        {
            t.RotateAround(transform.position, transform.up, 180f);
        }
    }

    public void end()
    {
        GameObject p = GameObject.Instantiate(poisonPuddle);
        p.transform.position = t.position;
        p.GetComponent<PoisonPuddleScript>().setTarget(target);
        //raycast down?
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("ouch");
            target.gameObject.GetComponent<MoverScript>().hit(1);
            Destroy(this.gameObject);
        } else if (other.gameObject != mommy)
        {
            end();
        }
    }
}
