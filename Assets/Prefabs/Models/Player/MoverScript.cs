using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverScript : MonoBehaviour
{
    private float elapsedTimeArrow;
    private float elapsedTimeBat;

    public float runForce = 50f;
    public float maxRunSpeed = 6f;
    public float jumpForce = 50f;
    private float fallSpeed;
    private float maxFallSpeed = 12f;
    private float minFallSpeed = 4f;
    private int health = 5;
    private int maxHealth = 7;


    // array for weapons
    private int[] weapons;
    public int[] weaponDamage;
    private int weaponCount = 2;
    public int currentWeaponCounter;
    private bool swapWeapon = false;
    private GameObject currentWeapon;

    // weapon prefabs
    public GameObject[] weaponWheel;
    public Transform weaponSpawnPoint;
    public Transform batSpawnPoint;

    public bool feetInContactWithGround;
    private Rigidbody body;
    private Collider collider;

    private Animator animComp;

    // shooting weapons
    public GameObject arrow;
    public Transform arrowSpawn;

    // weapon script call
    public WeaponDeleteScript weaponCall;

    // health us script call
    public HeartScript heartCall;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
        currentWeaponCounter = 0;
        weapons = new int[weaponCount];

        weaponDamage = new int[weaponCount];

        weaponDamage[0] = 2;
        weaponDamage[1] = 1;
        //weaponDamage[2] = 3;
        //weaponDamage[3] = 0;

        // add values to weapons array
        for (int i = 0; i < 2; i++)
        {
            weapons[i] = (i + 1);
        }


        GameObject weaponInstance = Instantiate(weaponWheel[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (feetInContactWithGround)
            {
                Debug.Log("Should be Jumping!");
                body.velocity = new Vector2( body.velocity.x, 0);
                body.velocity = new Vector2( body.velocity.x, jumpForce);

                body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("End Menu");
        }
        float castDistance = collider.bounds.extents.y + 0.5f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * runForce * axis, ForceMode.Force);

        // swapping weapons
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            // delete the current weapon
            weaponCall = GameObject.FindWithTag("1").GetComponent<WeaponDeleteScript>();
            weaponCall.deleteThis();

            animComp.SetBool("SwapTrigger", true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeaponCounter == (weaponCount - 1))
                {
                    currentWeaponCounter = 0;
                }

                else
                {
                    currentWeaponCounter++;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentWeaponCounter == (0))
                {
                    currentWeaponCounter = (weaponCount - 1);
                }

                else
                {
                    currentWeaponCounter--;
                }
            }

            // if the weapon is the bat
            if (currentWeaponCounter == 0)
            {
                GameObject weaponInstance = Instantiate(weaponWheel[currentWeaponCounter]);
                weaponInstance.transform.position = batSpawnPoint.position;
                weaponInstance.transform.parent = weaponSpawnPoint;
            }
            else
            {
                GameObject weaponInstance = Instantiate(weaponWheel[currentWeaponCounter]);
                weaponInstance.transform.position = weaponSpawnPoint.position;
                weaponInstance.transform.parent = weaponSpawnPoint;
            }



        }

        else
        {
            animComp.SetBool("SwapTrigger", false);
        }
        elapsedTimeArrow += Time.deltaTime;
        // attacking
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animComp.SetBool("Attacking", true);

            for (int i = 0; i < weaponCount; i++)
            {
                if (currentWeaponCounter == i)
                {
                    animComp.SetInteger("SelectedWeapon", i);
                }
            }

            // check for shooting bow
            
            if (currentWeaponCounter == 1)
            {
                int arrowRotation;

                if (this.transform.rotation.y >= 0)
                {
                    arrowRotation = 180;
                }
                else
                {
                    arrowRotation = 0;
                }

                if (elapsedTimeArrow >= 1f)
                {
                    //moveDirection = body.velocity.x;
                    elapsedTimeArrow = 0f;
                    Quaternion rotation = Quaternion.Euler(0, 0, arrowRotation);
                    Transform arrowlocation = arrowSpawn;
                    GameObject arrow = Instantiate(this.arrow, Vector3.zero, rotation);
                    arrow.transform.position = arrowlocation.position;
                }
            }
        }

        else
        {
            animComp.SetBool("Attacking", false);
        }

        // test for gaining and losing health

        // gain health
        if (Input.GetKeyDown(KeyCode.O))
        {
            // heal();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            hit(1);
        }

        if (health <= 0)
        {
            Death();
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxRunSpeed = 12f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxRunSpeed = 6f;
        }

        if (body.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (body.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        

        // if horizontal speed is too high
        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        // if vertical speed is too high
        if (Mathf.Abs(body.velocity.y) > maxFallSpeed)
        {
            float newY = maxFallSpeed * Mathf.Sign(body.velocity.y);
            body.velocity = new Vector3(body.velocity.x, newY, body.velocity.z);
        }

        if (axis < 0.15f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 3f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        // set values that animations will check
        animComp.SetFloat("Speed", body.velocity.magnitude);

        if (body.velocity.y < 0)
        {
            animComp.SetFloat("FallSpeed", body.velocity.y);
        }

        else
        {
            animComp.SetFloat("FallSpeed", 0);
        }

        if (body.velocity.y > 0)
        {
            animComp.SetFloat("JumpSpeed", body.velocity.y);
        }

        else
        {
            animComp.SetFloat("JumpSpeed", 0);
        }

        if (feetInContactWithGround == true)
        {
            animComp.SetBool("TouchingGround", true);
        }

        else
        {
            animComp.SetBool("TouchingGround", false);
        }

        
    }

    public void Death()
    {
        animComp.SetBool("isDead", true);
        //Destroy(this.gameObject);
    }

    public int DamageAmount()
    {
        return weaponDamage[currentWeaponCounter];
    }

    public Vector3 playerPosition()
    {
        return transform.position;
    }

    public int playerRotation()
    {
        if (transform.rotation.y < 0)
        {
            return -1;
        }

        else
        {
            return 1;
        }
    }

    // taking damage
    public void hit(int damageNum)
    {
        health -= damageNum;
        heartCall.loseHealth(damageNum);
    }

    // gaining health
    public void heal()
    {
        health += 2;
        heartCall.gainHealth();
        Debug.Log("I feel better");
    }

    // return weapon number
    public int weaponNum()
    {
        return currentWeaponCounter;
    }
}