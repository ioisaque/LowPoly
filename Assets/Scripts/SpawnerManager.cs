using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public bool debug = false;

    public GameObject[] ObjectToSpawn;
    public float spawnTime;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (!debug)
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        else
            Spawn();
    }

    void Spawn()
    {
        int spawnObjectIndex = Random.Range(0, ObjectToSpawn.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(ObjectToSpawn[spawnObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
