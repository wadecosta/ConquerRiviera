using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public Transform target;
    public GameObject poisonShot;

    public float lineOfSightDistance;
    public float speed;
    public float maxCooldown;
    public float cooldown = 0;
    public int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //shooting
        if (cooldown <= 0 && hasLineOfSight())
        {
            shoot();
            cooldown = maxCooldown;
        } else
        {
            cooldown -= Time.deltaTime;
        }

        //movement
        Vector3 rayDir = Vector3.down + (Vector3.forward * direction);
        Vector3 raySource = this.transform.position + Vector3.up;
        if (Physics.Raycast(raySource, rayDir))
        {
            this.transform.position += Vector3.forward * direction * speed * Time.deltaTime;
        } else
        {
            direction *= -1;
        }
    }

    private bool hasLineOfSight()
    {
        if ((target.position - this.transform.position).magnitude > lineOfSightDistance)
            return false;
        if (direction * (target.position.z - this.transform.position.z) > 0)
            return true;
        return false;
    }

    public void shoot()
    {
        GameObject shot = GameObject.Instantiate(poisonShot);
        shot.transform.SetParent(this.transform);
        shot.GetComponent<PoisonShotScript>().setTarget(target.transform);
    }
}
