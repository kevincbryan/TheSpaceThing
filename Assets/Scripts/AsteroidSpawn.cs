using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    [SerializeField] float spawnRate = 1f;
    [SerializeField] float startDelay = 15f;

    [SerializeField] float spawnDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    void Spawn()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-1f,1f), 0f, Random.Range(-1f,1f)).normalized * spawnDistance;
        spawnLocation = new Vector3(spawnLocation.x, 1f, spawnLocation.z);

        GameObject newAsteriod = Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity, transform);
    }
}
