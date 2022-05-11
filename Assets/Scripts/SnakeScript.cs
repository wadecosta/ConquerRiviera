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

    public int health = 2;
    public GameObject arrow;
    //public GameObject bat;

    Animator iguanaAnimator;

    void Start()
    {
        iguanaAnimator = GetComponent<Animator>();
        target = GameObject.Find("player").transform;
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

        // make this code better
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 playerPostion = target.transform.position - transform.position;
            if (Physics.Raycast(transform.position, playerPostion, 3) && target.GetComponent<MoverScript>().weaponNum() == 0)
            {
                hit(2);
            }
        }

    }

    private void FixedUpdate()
    {
        //movement
        Vector3 rayDir = Vector3.down + (Vector3.left * 2f * direction);
        Vector3 raySource = this.transform.position + Vector3.up;
        if (Physics.Raycast(raySource, rayDir))
        {
            iguanaAnimator.SetFloat("Forward", speed);
        }
        else
        {
            Debug.Log("Iguana raycast lookahead failed");
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
        if (direction * (target.position.x - this.transform.position.x) > 0)
            return true;
        return false;
    }

    public void shoot()
    {
        GameObject shot = GameObject.Instantiate(poisonShot);
        //shot.transform.SetParent(this.transform);
        shot.transform.position = this.transform.position;
        shot.GetComponent<PoisonShotScript>().setTargetAndMom(target.gameObject, this.gameObject);

        iguanaAnimator.SetTrigger("Attack");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Debug.Log("smack");
            iguanaAnimator.SetTrigger("Attack");
            //reduce health of iguana
            target.gameObject.GetComponent<MoverScript>().hit(1);

            //make if statement better!!!
        } else if (collision.gameObject == arrow)
        {
            hit(1);
        } else if (this.transform.position.y - collision.transform.position.y <= 0.1)
        {
            Debug.Log("Iguana collided with " + collision.gameObject.name);
            turnAround();
        }
    }

    public void die()
    {
        iguanaAnimator.SetTrigger("Death");
        Destroy(this.gameObject, 3f);
    }

    public void hit(int damage)
    {
        Debug.Log("Iguana got hit for " + damage);
        health -= damage;
        if (health <= 0) die();
        iguanaAnimator.SetTrigger("Hit");
    }
}
