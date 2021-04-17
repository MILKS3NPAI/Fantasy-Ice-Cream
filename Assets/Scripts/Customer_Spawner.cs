using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Spawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnDelay = 5;
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
        Instantiate(prefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
