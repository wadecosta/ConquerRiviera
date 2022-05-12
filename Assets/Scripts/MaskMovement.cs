using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MaskMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bgSFX;
    public GameObject bossSFX;
    public GameObject fireballSFX;
    public GameObject heatwaveSFX;
    public GameObject deathScreamSFX;

    public GameObject healthBarUI;
    public Slider slider;
    
    public GameObject mask;
    public GameObject player;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public Vector3 origin;
    public Vector3 direction;
    public Vector3 wirePosition;
    private Vector3 newPosition;
    
    public float elapsedTime = 0f;
    public float countDown = 5f;

    public float health;
    private float maxHealth;

    public GameObject imgIndicator;
    public GameObject hwIndicator;
    public GameObject fbIndicator;

    public GameObject fireballPrefab;

    public ParticleSystem heatWaveParticles;

    public Transform fireballSpawner;
    private bool leavestate;
    
    public MoverScript MoverScriptCall;
    private bool playerRay;
    public Vector3 playerPostion;
    void Start()
    {
        sphereRadius = 5;
        health = 100;
        countDown = 5f;
        maxHealth = 100f;
        health = maxHealth;
        
        // find the player script
        MoverScriptCall = GameObject.Find("player").GetComponent<MoverScript>();
        bgSFX.SetActive(false);
        bossSFX.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(mask.transform.position + 2f * Vector3.right, mask.transform.TransformDirection(Vector3.left) * 5f, Color.yellow);

        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            //healthBarUI.SetActive(true);
        }
        int indicator = 2;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 4f)
        {
            elapsedTime = 0f;
            indicator = choseIndicator();
            StartCoroutine(chooseAttack(indicator));
        }
        countDown -= Time.deltaTime;

        if (countDown > 0)
        {
            mask.transform.position += Vector3.left * Time.deltaTime;
        }
        else if (countDown > -5.0f)
        {
            mask.transform.position += Vector3.right * Time.deltaTime;
        }
        else
        {
            countDown = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            int weaponCount = MoverScriptCall.weaponNum();

            if (weaponCount == 0)
            {
                playerPostion = MoverScriptCall.playerPosition();
                playerPostion -= transform.position;
                playerRay = Physics.Raycast(transform.position, playerPostion, 5);

                if (playerRay == true)
                {
                    takeDamage(10);
                }
            }
        }

        if (health <= 0)
        {
            die();
            SceneManager.LoadScene("End Menu");
        }
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(new Vector3((float) (mask.transform.position.x + 0.67), 
    //         (float) (mask.transform.position.y - 0.66),
    //         (float) (mask.transform.position.z -4.27)), sphereRadius);
    // }

    private void heatWave()
    {
        if (health < 0)
        {
            die();
        }
        imgIndicator.SetActive(false);
        heatWaveParticles.Play();
        heatwaveSFX.SetActive(true);
        ParticleSystem.EmissionModule em = heatWaveParticles.emission;
        em.enabled = true;
        origin = mask.transform.position;
        direction = mask.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(mask.transform.position + 2f * Vector3.right, mask.transform.TransformDirection(Vector3.left) * 5f, out hit, 5f))
        {
            Debug.Log("**************" + hit.collider.gameObject);
            if (hit.collider.gameObject.name == "player")
            {
                player.GetComponent<MoverScript>().hit(3);
            }
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }

    private void fireball()
    {
        imgIndicator.SetActive(false);
        fireballSFX.SetActive(true);
        GameObject ball = Instantiate(fireballPrefab, fireballSpawner.position, GameObject.Find("Fireball Spawner").transform.rotation);
        ball.GetComponent<FireballAttack>().setPlayer(player);

    }

    private IEnumerator chooseAttack(int i)
    {
        yield return new WaitForSeconds (2);
        {
            if (i == 0)
            {
                Debug.Log("Heat Wave!");
                heatWave();
            }

            if (i == 1)
            {
                Debug.Log("Fireball!");
                fireball();
            }
        }
    }

    private int choseIndicator()
    {
        fireballSFX.SetActive(false);
        heatwaveSFX.SetActive(false);
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            imgIndicator = hwIndicator;
            imgIndicator.SetActive(true);
        }
        if (i == 1)
        {
            imgIndicator = fbIndicator;
            imgIndicator.SetActive(true);
        }
        return i;
    }

    private void die()
    {
        deathScreamSFX.SetActive(true);
        Destroy(this);
    }
    
    float CalculateHealth()
    {
        return (health / maxHealth);
    }

    public void takeDamage(int damageNum)
    {
        health -= damageNum;
        Debug.Log("Boss has " + health +" health left.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ArrowPrefab(Clone)")
        {
            takeDamage(3);
        }
    }
}