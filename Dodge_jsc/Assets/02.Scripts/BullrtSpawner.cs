using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullrtSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {



        {
            timeAfterSpawn += Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject bullet
                    = Instantiate(bulletPrefab, transform.position, transform.rotation);

                bullet.transform.LookAt(target);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }

        }

        void OnTriggerEnter (Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerController playerController = other.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    playerController.Die();
                }
            }
        }      
    }
}
