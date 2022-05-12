using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public Transform target;
    public GameObject poisonShot;
    public GameObject wall;
    
    public float lineOfSightDistance;
    public float speed;
    public float maxCooldown;
    public float cooldown = 0;
    public int direction = -1;

    public Vector3 targetPos;
    public int health = 2;
    public GameObject arrow;
    //public GameObject bat;
    public Vector3 playerPostion;
    public MoverScript MoverScriptCall;
    private bool playerRay;
    Animator iguanaAnimator;

    void Start()
    {
        iguanaAnimator = GetComponent<Animator>();
        target = GameObject.Find("player").transform;
        targetPos = target.position;
        // find the player script
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.position;

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
            playerPostion = MoverScriptCall.playerPosition();
            playerPostion -= transform.position;
            RaycastHit obj;
            if (Physics.Raycast(transform.position, playerPostion,out obj, 1f))
            {
                if (obj.collider.gameObject.name.Equals("player"))
                {
                    hit(2);
                }

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
        if ((targetPos - this.transform.position).magnitude > lineOfSightDistance)
            return false;
        if (direction * (targetPos.x - this.transform.position.x) > 0)
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
            iguanaAnimator.SetTrigger("Attack");
            //reduce health of iguana
            target.gameObject.GetComponent<MoverScript>().hit(1);

            //make if statement better!!!
        } else if (collision.gameObject == arrow)
        {
            hit(1);
        } else if (this.transform.position.y - collision.transform.position.y <= 0.1)
        {
            turnAround();
        }
    }

    public void die()
    {
        iguanaAnimator.SetTrigger("Death");
        Destroy(wall, 3f);
        Destroy(this.gameObject, 3f);
        
    }

    public void hit(int damage)
    {
        health -= damage;
        if (health <= 0) die();
        iguanaAnimator.SetTrigger("Hit");
    }
}
