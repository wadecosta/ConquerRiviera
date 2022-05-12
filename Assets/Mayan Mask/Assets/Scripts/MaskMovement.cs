using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MaskMovement : MonoBehaviour
{
    // Start is called before the first frame update
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
    void Start()
    { 
        sphereRadius = 5;
        health = 100;
        countDown = 5f;
        maxHealth = 100f;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(mask.transform.position + 1.5f * Vector3.forward, mask.transform.TransformDirection(Vector3.forward) * 5f, Color.yellow);

        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        int indicator = 2;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 7f)
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
        if (Physics.Raycast(origin + 1.5f * Vector3.forward, mask.transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(origin, mask.transform.TransformDirection(Vector3.forward) * 5f, Color.yellow);
            Debug.Log("Did Hit");
            player.GetComponent<MoverScript>().hit(3);
        }
        else
        {
            Debug.DrawRay(origin, mask.transform.TransformDirection(Vector3.forward) * 5f, Color.white);
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
}
