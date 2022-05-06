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

    Animator iguanaAnimator;

    void Start()
    {
        iguanaAnimator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
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

       
    }

    private void FixedUpdate()
    {
        //movement
        Vector3 rayDir = Vector3.down + (Vector3.forward * direction);
        Vector3 raySource = this.transform.position + Vector3.up;
        if (Physics.Raycast(raySource, rayDir))
        {
            iguanaAnimator.SetFloat("Forward", speed);
        }
        else
        {
            turnAround();
        }
    }

    public void turnAround()
    {
        transform.RotateAround(transform.position, transform.up, 180f);
        direction *= -1;
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
        //shot.transform.SetParent(this.transform);
        shot.transform.position = this.transform.position;
        shot.GetComponent<PoisonShotScript>().setTarget(target.gameObject);

        iguanaAnimator.SetTrigger("Attack");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Debug.Log("smack");
            iguanaAnimator.SetTrigger("Attack");
        } else
        {
            turnAround();
        }
    }

    public void die()
    {
        iguanaAnimator.SetTrigger("Death");
        Destroy(this.gameObject, 3f);
    }
}
