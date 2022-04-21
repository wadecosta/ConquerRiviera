using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float runForce = 50f;
    public float maxRunSpeed = 6f;
    public float jumpForce = 50f;
    private float fallSpeed;
    private float maxFallSpeed = 12f;
    private float minFallSpeed = 4f;
    
    // array for weapons
    private int[] weapons;
    private int weaponCount = 3;
    private int currentWeapon;
    private bool swapWeapon = false;

    public bool feetInContactWithGround;
    private Rigidbody body;
    private Collider collider;

    private Animator animComp;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
        currentWeapon = 0;
        weapons = new int[weaponCount];
        
        // add values to weapons array
        for (int i = 0; i < 3; i++)
        {
            weapons[i] = (i + 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float castDistance = collider.bounds.extents.y + 0.2f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * runForce * axis, ForceMode.Force);

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

        if (Input.GetKeyDown(KeyCode.Space) && feetInContactWithGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

        if (axis < 0.1f)
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
        
        // swapping weapons
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            animComp.SetBool("SwapTrigger", true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentWeapon == 0)
                {
                    currentWeapon = weaponCount - 1;
                }

                else
                {
                    currentWeapon--;
                }
            }

            else
            {
                if (currentWeapon == (weaponCount - 1))
                {
                    currentWeapon = 0;
                }

                else
                {
                    currentWeapon++;
                }
            }
            Debug.Log("Selected Weapon is: " + currentWeapon);
        }

        else
        {
            animComp.SetBool("SwapTrigger", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animComp.SetBool("Attacking", true);

            for (int i = 0; i < weaponCount; i++)
            {
                if (currentWeapon == i)
                {
                    animComp.SetInteger("SelectedWeapon", i);
                }
            }
        }

        else
        {
            animComp.SetBool("Attacking", false);
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
        Debug.Log("Sorry. You Lost");
    }
}