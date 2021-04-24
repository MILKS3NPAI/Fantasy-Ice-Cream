using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Spawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject prefab1;
    [SerializeField]
    private GameObject prefab2;
    [SerializeField]
    private GameObject prefab3;
    [SerializeField]
    private float spawnDelay = 5;
    private int random;

    private void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {

        nextSpawnTime = Time.time + spawnDelay;
        random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                Instantiate(prefab1, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(prefab2, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(prefab3, transform.position, transform.rotation);
                break;
        }
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
