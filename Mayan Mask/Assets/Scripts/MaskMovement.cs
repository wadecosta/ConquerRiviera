using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MaskMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mask;
    public GameObject player;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public Vector3 origin;
    public Vector3 direction;
    public Vector3 wirePosition;
    
    public float elapsedTime = 0f;

    private int health;

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
    }

    // Update is called once per frame
    void Update()
    {
        int indicator = 2;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 7f)
        {
            elapsedTime = 0f;
            indicator = choseIndicator();
            StartCoroutine(chooseAttack(indicator));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3((float) (mask.transform.position.x + 0.67), 
            (float) (mask.transform.position.y - 0.66),
            (float) (mask.transform.position.z -4.27)), sphereRadius);
    }

    private void heatWave()
    {
        imgIndicator.SetActive(false);
        heatWaveParticles.Play();
        ParticleSystem.EmissionModule em = heatWaveParticles.emission;
        em.enabled = true;
        origin = mask.transform.position;
        direction = mask.transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask,
                QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log(hit.transform.gameObject);
        }
    }

    private void fireball()
    {
        imgIndicator.SetActive(false);
        Instantiate(fireballPrefab, fireballSpawner.position, GameObject.Find("Fireball Spawner").transform.rotation);
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
        int i = Random.Range(0, 2);
        Debug.Log("I picked " + i);
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
}
