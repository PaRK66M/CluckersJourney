using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 3f;
    public float destroyDelay = 15f;

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnPrefab();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnPrefab()
    {
        GameObject newPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        newPrefab.GetComponent<NewBubbleControls>().destroyTimer = destroyDelay;
    }
}
