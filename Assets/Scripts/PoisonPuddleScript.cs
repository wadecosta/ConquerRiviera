using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPuddleScript : MonoBehaviour
{
    public float fallSpeed = 5;
    public float lifetime = 5;
    public GameObject target;
    public bool canhit = true;
    // Start is called before the first frame update
    void Start()
    {   
        Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayDir = Vector3.down;
        Vector3 raySource = this.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(raySource, rayDir, out hit, 0.1f))
        {
            //Debug.Log("landed on " + hit.transform.gameObject.name);
        } else
        {
            this.transform.position = this.transform.position + (Vector3.down * fallSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target && canhit)
        {
            Debug.Log("oof");
            target.gameObject.GetComponent<MoverScript>().hit(1);
            canhit = false;
            //StartCoroutine(SetHit());
            SetHit();
        }
    }

    IEnumerable SetHit()
    {
        yield return new WaitForSeconds(2f);
        canhit = true;
        //yield return null;
    }

    public void setTarget(GameObject t)
    {
        target = t;
    }
}
